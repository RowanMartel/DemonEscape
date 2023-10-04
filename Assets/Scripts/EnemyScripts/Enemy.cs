using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    Image sprite;
    Canvas canvas;

    float cooldownTimer;
    float animTimer;

    bool dead;

    [SerializeField] protected AudioSource voiceAudio;
    [SerializeField] protected AudioSource gunAudio;
    [SerializeField] protected AudioClip clipHurt;
    [SerializeField] protected AudioClip clipDie;
    [SerializeField] protected AudioClip clipGun;

    [SerializeField] protected Sprite idleSprite;
    [SerializeField] protected Sprite attackingSprite;
    [SerializeField] protected Sprite hurtSprite;
    [SerializeField] protected Sprite deadSprite;

    protected float attackCooldown;
    protected float speed;
    protected float allowedProximity;
    protected float health;
    protected float damage;
    protected float firingDistance;
    protected float attackRange;

    void Start()
    {
        dead = false;
        sprite = GetComponentInChildren<Image>();
        canvas = GetComponentInChildren<Canvas>();
        agent = GetComponent<NavMeshAgent>();
        player = GameManager.player;
        cooldownTimer = attackCooldown;
    }

    void Update()
    {
        if (dead)
        {
            if (agent.isOnNavMesh)
                agent.SetDestination(transform.position);
            KillThis();
            return;
        }
        ResetSprite();
        Move();
        TryAttack();
    }

    void Move()
    {
        // try to stay 15 units away from the player
        if (Vector3.Distance(transform.position, player.transform.position) > allowedProximity)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            transform.LookAt(player.transform.position);
            agent.SetDestination(transform.position - transform.forward);
        }
    }

    void TryAttack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > firingDistance)
            return;
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
        {
            Attack();
            cooldownTimer = attackCooldown;
        }
    }

    protected virtual void Attack()
    {
        gunAudio.PlayOneShot(clipGun);
        ChangeSprite(attackingSprite);

        RaycastHit hit;
        transform.LookAt(player.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, attackRange, LayerMask.GetMask("Player")))
            player.GetComponent<Player>().TakeDamage(damage);
    }

    void ChangeSprite(Sprite newSprite)
    {
        animTimer = 0.5f;
        sprite.sprite = newSprite;
    }
    void ResetSprite()
    {
        if (animTimer <= 0) return;
        animTimer -= Time.deltaTime;
        if (animTimer > 0) return;
        sprite.sprite = idleSprite;
        if (dead) canvas.enabled = false;
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
            ChangeSprite(hurtSprite);
            if (!voiceAudio.isPlaying)
                voiceAudio.PlayOneShot(clipHurt);
        }
    }
    void Die()
    {
        voiceAudio.Stop();
        voiceAudio.PlayOneShot(clipDie);
        health = 0;
        dead = true;
        ChangeSprite(deadSprite);
        voiceAudio.PlayOneShot(clipDie);
    }

    void KillThis()
    {
        if (!voiceAudio.isPlaying)
            Destroy(gameObject);
    }
}