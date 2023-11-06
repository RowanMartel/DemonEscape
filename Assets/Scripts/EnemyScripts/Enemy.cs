using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    GameManager gameManager;
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

    [SerializeField] protected GameObject projectile;

    protected float attackCooldown;
    protected float speed;
    protected float allowedProximity;
    protected float health;
    protected float damage;
    protected float firingDistance;
    protected float attackRange;
    protected int money;
    protected Gun.FiringType firingType;
    protected float rangeRadius;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        dead = false;
        sprite = GetComponentInChildren<Image>();
        canvas = GetComponentInChildren<Canvas>();
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>().gameObject;
        cooldownTimer = attackCooldown;
    }

    void Update()
    {
        if (gameManager.Paused) return;
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

    void Attack()
    {
        gunAudio.Stop();
        gunAudio.PlayOneShot(clipGun);
        ChangeSprite(attackingSprite);

        switch (firingType)
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
        bool didHit = Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, attackRange, LayerMask.GetMask("Player"));
        if (didHit)
        {
            hit.collider.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
    void SpherecastAttack()
    {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, rangeRadius, Camera.main.transform.forward, attackRange, LayerMask.GetMask("Enemy"));
        for (int i = 0; i < hits.Length; i++)
        {
            hits[i].collider.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
    void ProjectileAttack()
    {
        GameObject proj = Instantiate(projectile, transform);
        proj.GetComponent<Projectile>().Init(currentGun);
        proj.transform.Translate(0, 1, 2, Space.Self);
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
        player.GetComponent<Player>().AddMoney(money);
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