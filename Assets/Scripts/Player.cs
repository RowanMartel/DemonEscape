using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float Health;
    float health
    {
        get { return Health; }
        set
        {
            Health = value;
            tmpHealth.text = "Health: " + value;
        }
    }
    private float Ammo;
    float ammo
    {
        get { return Ammo; }
        set
        {
            Ammo = value;
            tmpAmmo.text = "Ammo: " + value;
        }
    }

    [SerializeField] TMP_Text tmpHealth;
    [SerializeField] TMP_Text tmpAmmo;

    [SerializeField] AudioSource voiceAudio;
    [SerializeField] AudioSource gunAudio;
    [SerializeField] AudioClip clipHurt;
    [SerializeField] AudioClip clipDie;

    bool dead;

    bool canAttack;
    float attackCooldownTimer;

    Gun gun;
    Animator gunAnim;
    [SerializeField] Animator pistolAnim;

    [SerializeField] Image portrait;
    [SerializeField] Sprite idleSprite;
    [SerializeField] Sprite attackingSprite;
    [SerializeField] Sprite hurtSprite;
    [SerializeField] Sprite deadSprite;
    float portraitTimer;

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
        ResetPortrait();
        TryAttack();
    }

    public void TakeDamage(float damage)
    {
        if (dead) return;
        health -= damage;
        if (health <= 0)
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
        health = 0;
        Debug.Log("player died");
    }

    public void ResetStats()
    {
        health = Constants.playerStartingHP;
    }

    void Attack()
    {
        ChangePortrait(attackingSprite);
        gunAnim.SetTrigger("Fired");
        ammo--;
        RaycastHit hit;
        bool didHit = Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, gun.range, LayerMask.GetMask("Enemy"));
        if (didHit)
        {
            hit.collider.GetComponent<Enemy>().TakeDamage(gun.damage);
        }
    }
    void TryAttack()
    {
        CooldownAttack();
        if (!Input.GetMouseButtonDown(0)) return;
        if (ammo <= 0)
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
            ammo += newGun.startingAmmo;
            return;
        }
        gun = newGun;
        ammo = gun.startingAmmo;

        switch (gun.name)
        {
            case "Pistol":
                gunAnim = pistolAnim;
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
}