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

    public bool dead;

    bool canAttack;
    float attackCooldownTimer;

    Gun gun;
    [SerializeField] GameObject[] guns;
    Animator gunAnim;
    [SerializeField] Animator pistolAnim;
    [SerializeField] Animator shotgunAnim;

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
        EquipGun(new Pistol());
    }

    void Update()
    {
        if (gameManager.Paused) return;
        ResetPortrait();
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

        Ammo--;
        canAttack = false;
        attackCooldownTimer = gun.firingCooldown;

        switch (gun.firingType)
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
        bool didHit = Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, gun.range, LayerMask.GetMask("Enemy"));
        if (didHit)
        {
            hit.collider.GetComponent<Enemy>().TakeDamage(gun.damage);
        }
    }
    void SpherecastAttack()
    {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, gun.rangeRadius, Camera.main.transform.forward, gun.range, LayerMask.GetMask("Enemy"));
        for (int i = 0; i < hits.Length; i++)
        {
            hits[i].collider.GetComponent<Enemy>().TakeDamage(gun.damage);
        }
    }
    void ProjectileAttack()
    {

    }
    void TryAttack()
    {
        if (dead) return;
        CooldownAttack();
        if (!Input.GetMouseButtonDown(0)) return;
        if (!canAttack) return;
        if (Ammo <= 0)
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
        if (gun == null)
        {
            // don't check else-if
        }
        else if (gun.GetType() == newGun.GetType())
        {
            Ammo += newGun.startingAmmo;
            return;
        }
        gun = newGun;
        Ammo = gun.startingAmmo;

        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
            if (guns[i].name == gun.gunName)
                guns[i].SetActive(true);
        }
        switch (gun.gunName)
        {
            case var _ when gun.gunName == Constants.pistolName:
                gunAnim = pistolAnim;
                break;
            case var _ when gun.gunName == Constants.shotgunName:
                gunAnim = shotgunAnim;
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
        this.Money += money;
    }
}