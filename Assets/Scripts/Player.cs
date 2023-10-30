using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
        }
    }
    private float ammo;
    float Ammo
    {
        get { return ammo; }
        set
        {
            ammo = value;
            tmpAmmo.text = "Ammo: " + value;
        }
    }
    private float money;
    public float Money
    {
        get { return money; }
        set
        {
            money = value;
            tmpMoney.text = "Money:\n" + value;
        }
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

    [SerializeField] Image portrait;
    [SerializeField] Sprite idleSprite;
    [SerializeField] Sprite attackingSprite;
    [SerializeField] Sprite hurtSprite;
    [SerializeField] Sprite deadSprite;
    float portraitTimer;

    public GameManager gameManager;
    public Results results;

    void Start()
    {
        dead = false;
        canAttack = true;
        attackCooldownTimer = 0;
        ResetStats();
        currentGun = gun1;
        EquipGun(new Pistol());
    }

    void Update()
    {
        if (gameManager.Paused) return;
        ResetPortrait();
        TrySwitchGun();
        TryAttack();
    }

    public void TakeDamage(float damage)
    {
        if (dead) return;
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
        else
        {
            ChangePortrait(hurtSprite);
            if (!voiceAudio.isPlaying)
                voiceAudio.PlayOneShot(clipHurt);
        }
    }

    public void Die()
    {
        voiceAudio.Stop();
        voiceAudio.PlayOneShot(clipDie);
        ChangePortrait(deadSprite);
        dead = true;
        Health = 0;
        gameManager.money += Money;
        gameManager.Paused = true;
        results.Open();
    }

    public void ResetStats()
    {
        Health = Constants.playerStartingHP;
    }

    void Attack()
    {
        gunAudio.PlayOneShot(clipGun);
        ChangePortrait(attackingSprite);
        gunAnim.SetTrigger("Fired");

        UseAmmo();
        canAttack = false;
        attackCooldownTimer = currentGun.firingCooldown;

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
        RaycastHit hit;
        bool didHit = Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, currentGun.range, LayerMask.GetMask("Enemy"));
        if (didHit)
        {
            hit.collider.GetComponent<Enemy>().TakeDamage(currentGun.damage);
        }
    }
    void SpherecastAttack()
    {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, currentGun.rangeRadius, Camera.main.transform.forward, currentGun.range, LayerMask.GetMask("Enemy"));
        for (int i = 0; i < hits.Length; i++)
        {
            hits[i].collider.GetComponent<Enemy>().TakeDamage(currentGun.damage);
        }
    }
    void ProjectileAttack()
    {
        GameObject proj = Instantiate(projectile, transform);
        proj.GetComponent<Projectile>().Init(currentGun);
        proj.transform.Translate(0, 1, 2, Space.Self);
    }
    void TryAttack()
    {
        if (dead) return;
        CooldownAttack();
        if (!Input.GetMouseButtonDown(0)) return;
        if (!canAttack) return;
        if (currentGun.currentAmmo <= 0)
        {
            // click SFX
            return;
        }

        Attack();
    }
    void CooldownAttack()
    {
        if (canAttack) return;
        attackCooldownTimer -= Time.deltaTime;
        if (attackCooldownTimer <= 0)
            canAttack = true;
    }

    public void EquipGun(Gun newGun)
    {
        if (gun1 == newGun)
        {
            currentGun = gun1;
        }
        else if (gun2 == newGun || gun2 == null)
        {
            currentGun = gun2;
        }
        else if (gun3 == newGun || gun3 == null)
        {
            currentGun = gun3;
        }

        if (currentGun == null)
        {
            // don't check else-if
        }
        else if (currentGun.GetType() == newGun.GetType())
        {
            Debug.Log(currentGun.currentAmmo);
            currentGun.currentAmmo += newGun.startingAmmo;
            Ammo = currentGun.currentAmmo;
            return;
        }
        else ChangePortrait(attackingSprite);

        currentGun = newGun;
        currentGun.currentAmmo = currentGun.startingAmmo;
        Ammo = currentGun.currentAmmo;

        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
            if (guns[i].name == currentGun.gunName)
                guns[i].SetActive(true);
        }
        switch (currentGun.gunName)
        {
            case var _ when currentGun.gunName == Constants.pistolName:
                gunAnim = pistolAnim;
                break;
            case var _ when currentGun.gunName == Constants.shotgunName:
                gunAnim = shotgunAnim;
                break;
            case var _ when currentGun.gunName == Constants.rocketLauncherName:
                gunAnim = rocketLauncherAnim;
                break;
        }
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
    }

    public void AddMoney(int money)
    {
        Money += money;
    }

    void UseAmmo()
    {
        Ammo--;
    }
    void TrySwitchGun()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchGun(gun1);
        else if (gun2 != null && Input.GetKeyDown(KeyCode.Alpha2)) SwitchGun(gun2);
        else if (gun3 != null && Input.GetKeyDown(KeyCode.Alpha3)) SwitchGun(gun3);
    }
    void SwitchGun(Gun newGun)
    {
        currentGun = newGun;
        Ammo = currentGun.currentAmmo;

        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
            if (guns[i].name == currentGun.gunName)
                guns[i].SetActive(true);
        }
        switch (currentGun.gunName)
        {
            case var _ when currentGun.gunName == Constants.pistolName:
                gunAnim = pistolAnim;
                break;
            case var _ when currentGun.gunName == Constants.shotgunName:
                gunAnim = shotgunAnim;
                break;
            case var _ when currentGun.gunName == Constants.rocketLauncherName:
                gunAnim = rocketLauncherAnim;
                break;
        }
    }
}