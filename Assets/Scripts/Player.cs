using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float health;
    float Health
    {
        get { return health; }
        set
        {
            health = value;
            tmpHealth.text = "Health: " + value;
        }// update UI on set
    }
    private float ammo;
    float Ammo
    {
        get { return ammo; }
        set
        {
            ammo = value;
            tmpAmmo.text = "Ammo: " + value;
        }// update UI on set
    }
    private float money;
    public float Money
    {
        get { return money; }
        set
        {
            money = value;
            tmpMoney.text = "Money:\n" + value;
        }// update UI on set
    }
    private float distance;
    public float Distance
    {
        get { return distance; }
        set
        {
            if (value > Constants.maxDistance) value = Constants.maxDistance;
            distance = value;
            distanceManager.MoveTracker(distance);
        }// update UI and distanceManager on set
    }

    [SerializeField] TMP_Text tmpHealth;
    [SerializeField] TMP_Text tmpAmmo;
    [SerializeField] TMP_Text tmpMoney;

    [SerializeField] AudioSource voiceAudio;
    [SerializeField] AudioSource gunAudio;
    [SerializeField] AudioClip clipHurt;
    [SerializeField] AudioClip clipDie;
    [SerializeField] AudioClip clipGun;

    [SerializeField] GameObject projectile;

    public bool dead;

    bool canAttack;
    float attackCooldownTimer;

    Gun gun1;
    Gun gun2;
    Gun gun3;
    Gun currentGun;
    [SerializeField] GameObject[] guns;
    Animator gunAnim;
    [SerializeField] Animator pistolAnim;
    [SerializeField] Animator shotgunAnim;
    [SerializeField] Animator rocketLauncherAnim;
    [SerializeField] Animator machineGunAnim;
    [SerializeField] Animator railGunAnim;

    [SerializeField] Image portrait;
    [SerializeField] Sprite idleSprite;
    [SerializeField] Sprite attackingSprite;
    [SerializeField] Sprite hurtSprite;
    [SerializeField] Sprite deadSprite;
    float portraitTimer;

    [SerializeField] Image gun1Img;
    [SerializeField] Image gun2Img;
    [SerializeField] Image gun3Img;
    [SerializeField] Sprite pistolSprite;
    [SerializeField] Sprite shotgunSprite;
    [SerializeField] Sprite rocketLauncherSprite;
    [SerializeField] Sprite machineGunSprite;
    [SerializeField] Sprite railGunSprite;

    public GameManager gameManager;
    public Results results;

    [SerializeField] DistanceManager distanceManager;

    public bool invincible;
    public bool infiniteAmmo;
    public bool doubleDamage;
    float invincibleTimer;
    float infiniteAmmoTimer;
    float doubleDamagetimer;

    [SerializeField] ScreenVFX screenVFX;

    void Start()
    {
        dead = false;
        canAttack = true;
        attackCooldownTimer = 0;
        ResetStats();
        currentGun = gun1;
        EquipGun(new Pistol());// starting gun
    }

    void Update()
    {
        if (gameManager.Paused) return;
        ResetPortrait();
        TrySwitchGun();
        TryAttack();
        PowerupTimer();
    }

    public void TakeDamage(float damage)
    {
        if (dead || invincible) return;
        Health -= damage;
        if (Health <= 0)
            Die();
        else
        {
            ChangePortrait(hurtSprite);
            if (!voiceAudio.isPlaying)
                voiceAudio.PlayOneShot(clipHurt);
        }
        if (health <= Constants.playerStartingHP / 4)
        {
            screenVFX.SetVFX(ScreenVFX.VFX.lowHealth);

            if (currentGun.EDS)
                EDS(); // if health is low call EDS
        }
    }

    void EDS()
    {
        for (int i = 0; i < currentGun.EDSAmount; i++)
        {
            Attack();
            currentGun.currentAmmo++;
            Ammo++;
        }
    } // Emergency Defense System sends out attacks without consuming ammo

    public void Die()
    {
        voiceAudio.Stop();
        voiceAudio.PlayOneShot(clipDie);
        ChangePortrait(deadSprite);
        dead = true;
        Health = 0;
        GameManager.money += Money;
        gameManager.Paused = true;
        results.Open();
    }// update portrait and money on death, then open results screen

    public void ResetStats()
    {
        Health = Constants.playerStartingHP;
    }

    void Attack()
    {
        gunAudio.Stop();
        gunAudio.PlayOneShot(clipGun);
        ChangePortrait(attackingSprite);
        gunAnim.SetTrigger("Fired");// set animator state to firing

        UseAmmo();
        canAttack = false;
        attackCooldownTimer = currentGun.firingCooldown;// set the cooldown timer based on the current gun

        switch (currentGun.firingType)
        {
            case Gun.FiringType.rayCast:
                RaycastAttack();
                break;
            case Gun.FiringType.sphereCastAll:
                SpherecastAttack();
                break;
            case Gun.FiringType.projectile:
                ProjectileAttack();
                break;
        }
    }
    void RaycastAttack()
    {
        bool didHit = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward - transform.TransformDirection(new Vector3(0, .1f, 0)), out RaycastHit hit, currentGun.range, LayerMask.GetMask("Enemy"));
        if (didHit && !doubleDamage)
            hit.collider.GetComponent<Enemy>().TakeDamage(currentGun.damage);
        else if (didHit && doubleDamage)
            hit.collider.GetComponent<Enemy>().TakeDamage(currentGun.damage * 2);
    }// attack the first collider in a straight line
    void SpherecastAttack()
    {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(Camera.main.transform.position, currentGun.rangeRadius, Camera.main.transform.forward - transform.TransformDirection(new Vector3(0, .1f, 0)), currentGun.range, LayerMask.GetMask("Enemy"));
        for (int i = 0; i < hits.Length; i++)
        {
            if (!doubleDamage)
                hits[i].collider.GetComponent<Enemy>().TakeDamage(currentGun.damage);
            else
                hits[i].collider.GetComponent<Enemy>().TakeDamage(currentGun.damage * 2);
        }
    }// for shotgun spray like attacks
    void ProjectileAttack()
    {
        GameObject proj = Instantiate(projectile, transform);
        proj.GetComponent<Projectile>().Init(currentGun, doubleDamage);
        proj.transform.Translate(0, 1, 2, Space.Self);
    }// initializes a projectile object
    void TryAttack()
    {
        if (dead) return;
        CooldownAttack();
        if (!Input.GetMouseButtonDown(0) && !(currentGun.automatic && Input.GetMouseButton(0))) return;
        if (!canAttack) return;
        if (currentGun.currentAmmo <= 0 && !infiniteAmmo)
        {
            // click SFX
            return;
        }

        Attack();
    }// ticks down the attack timer, then checks if the player is attempting to fire. Is called every frame
    void CooldownAttack()
    {
        if (canAttack) return;
        attackCooldownTimer -= Time.deltaTime;
        if (attackCooldownTimer <= 0)
            canAttack = true;
    }// ticks down the attack timer

    public void EquipGun(Gun newGun)
    {
        Image gunImg = gun1Img;
        if (gun1 != null && gun1.gunName == newGun.gunName)
        {
            SwitchGun(gun1, true);
            return;
        }
        else if (gun2 != null && gun2.gunName == newGun.gunName)
        {
            SwitchGun(gun2, true);
            return;
        }
        else if (gun3 != null && gun3.gunName == newGun.gunName)
        {
            SwitchGun(gun3, true);
            return;
        }// first if-else chain for if the player already has this gun
        else if (gun1 != null && gun2 != null && gun3 != null)
        {
            if (currentGun == gun1)
            {
                gun1 = newGun;
                gunImg = gun1Img;
                SwitchGun(gun1);
            }
            else if (currentGun == gun2)
            {
                gun2 = newGun;
                gunImg = gun2Img;
                SwitchGun(gun2);
            }
            else if (currentGun == gun3)
            {
                gun3 = newGun;
                gunImg = gun3Img;
                SwitchGun(gun3);
            }
            currentGun.currentAmmo = newGun.startingAmmo;
            ChangePortrait(attackingSprite);
        }// if there are no empty slots, replace the current gun
        else if (gun1 == null)
        {
            gun1 = newGun;
            currentGun = gun1;
            currentGun.currentAmmo = newGun.startingAmmo;
            ChangePortrait(attackingSprite);
            gunImg = gun1Img;
        }
        else if (gun2 == null)
        {
            gun2 = newGun;
            currentGun = gun2;
            currentGun.currentAmmo = newGun.startingAmmo;
            ChangePortrait(attackingSprite);
            gunImg = gun2Img;
        }
        else if (gun3  == null)
        {
            gun3 = newGun;
            currentGun = gun3;
            currentGun.currentAmmo = newGun.startingAmmo;
            ChangePortrait(attackingSprite);
            gunImg = gun3Img;
        }// second if-else chain for if the player has an empty gun slot

        Ammo = currentGun.currentAmmo;

        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
            if (guns[i].name == currentGun.gunName)
                guns[i].SetActive(true);
        }// enable the right gun image
        switch (currentGun.gunName)
        {
            case Constants.pistolName:
                gunAnim = pistolAnim;
                gunImg.sprite = pistolSprite;
                break;
            case Constants.shotgunName:
                gunAnim = shotgunAnim;
                gunImg.sprite = shotgunSprite;
                break;
            case Constants.rocketLauncherName:
                gunAnim = rocketLauncherAnim;
                gunImg.sprite = rocketLauncherSprite;
                break;
            case Constants.machineGunName:
                gunAnim = machineGunAnim;
                gunImg.sprite = machineGunSprite;
                break;
            case Constants.railGunName:
                gunAnim = railGunAnim;
                gunImg.sprite = railGunSprite;
                break;
        }// enable the right gun animation
    }

    void ChangePortrait(Sprite newPortrait)
    {
        portraitTimer = 0.3f;
        portrait.sprite = newPortrait;
    }
    void ResetPortrait()
    {
        if (portraitTimer <= 0 || dead) return;
        portraitTimer -= Time.deltaTime;
        if (portraitTimer > 0) return;
        portrait.sprite = idleSprite;
    }// ticks down and then resets the portrait to the idle sprite. Calls every frame

    public void AddMoney(int money)
    {
        Money += money;
    }

    void UseAmmo()
    {
        if (infiniteAmmo) return;
        currentGun.currentAmmo--;
        Ammo--;
    }
    void TrySwitchGun()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchGun(gun1);
        else if (gun2 != null && Input.GetKeyDown(KeyCode.Alpha2)) SwitchGun(gun2);
        else if (gun3 != null && Input.GetKeyDown(KeyCode.Alpha3)) SwitchGun(gun3);
    }// tries to swap the gun if the player is inputting to do so
    void SwitchGun(Gun newGun, bool addAmmo = false)
    {
        currentGun = newGun;
        if (addAmmo) currentGun.currentAmmo = currentGun.startingAmmo;
        if (currentGun.currentAmmo > currentGun.maxAmmo) currentGun.currentAmmo = currentGun.maxAmmo;
        Ammo = currentGun.currentAmmo;

        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
            if (guns[i].name == currentGun.gunName)
                guns[i].SetActive(true);
        }
        switch (currentGun.gunName)
        {
            case Constants.pistolName:
                gunAnim = pistolAnim;
                break;
            case Constants.shotgunName:
                gunAnim = shotgunAnim;
                break;
            case Constants.rocketLauncherName:
                gunAnim = rocketLauncherAnim;
                break;
            case Constants.machineGunName:
                gunAnim = machineGunAnim;
                break;
            case Constants.railGunName:
                gunAnim = railGunAnim;
                break;
        }
    }// switches the current gun. Follows much of the same logic as EquipGun

    public void ActivatePowerup(Powerup.Powerups powerup)
    {
        switch (powerup)
        {
            case Powerup.Powerups.invincible:
                invincibleTimer = 0;
                invincible = true;
                screenVFX.SetVFX(ScreenVFX.VFX.invincible);
                break;
            case Powerup.Powerups.infiniteAmmo:
                infiniteAmmoTimer = 0;
                infiniteAmmo = true;
                screenVFX.SetVFX(ScreenVFX.VFX.infiniteAmmo);
                break;
            case Powerup.Powerups.doubleDamage:
                doubleDamagetimer = 0;
                doubleDamage = true;
                screenVFX.SetVFX(ScreenVFX.VFX.doubleDamage);
                break;
        }
    }
    public void PowerupTimer()
    {
        if (invincible)
        {
            invincibleTimer += Time.deltaTime;
            if (invincibleTimer >= Constants.invincibleTime)
            {
                invincible = false;
                screenVFX.DisableVFX(ScreenVFX.VFX.invincible);
            }
        }
        if (infiniteAmmo)
        {
            infiniteAmmoTimer += Time.deltaTime;
            if (infiniteAmmoTimer >= Constants.infiniteAmmoTime)
            {
                infiniteAmmo = false;
                screenVFX.DisableVFX(ScreenVFX.VFX.infiniteAmmo);
            }
        }
        if (doubleDamage)
        {
            doubleDamagetimer += Time.deltaTime;
            if (doubleDamagetimer >= Constants.doubleDamageTime)
            {
                doubleDamage = false;
                screenVFX.DisableVFX(ScreenVFX.VFX.doubleDamage);
            }
        }
    }
}