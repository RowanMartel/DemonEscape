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
    protected float rangeRadius;
    protected int money;

    protected Gun.FiringType firingType;
    protected Gun projectileGun;
    // gun variables for projectile initialization

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
                agent.SetDestination(transform.position); // stay still
            KillThis();
            return;
        }
        ResetSprite();
        Move();
        TryAttack();
    }

    void Move()
    {
        // try to stay [allowed proximity] units away from the player
        if (Vector3.Distance(transform.position, player.transform.position) > allowedProximity)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            transform.LookAt(player.transform.position);
            agent.SetDestination(transform.position - transform.forward);
        }// move away from the player if too close
    }

    void TryAttack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > firingDistance)
            return;// return if too far away

        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
        {
            Attack();
            cooldownTimer = attackCooldown;
        }// attack after a cooldown timer that ticks down every update
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
        bool didHit = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, attackRange, LayerMask.GetMask("Player"));
        if (didHit)
            hit.collider.GetComponentInParent<Player>().TakeDamage(damage);
    }// attack first collider in line of sight
    void SpherecastAttack()
    {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, rangeRadius, transform.forward, attackRange, LayerMask.GetMask("Player"));
        for (int i = 0; i < hits.Length; i++)
            hits[i].collider.GetComponentInParent<Player>().TakeDamage(damage);
        Debug.DrawRay(transform.position, transform.forward * attackRange, Color.red, 500);
    }// for shotgun spray types of attacks
    void ProjectileAttack()
    {
        GameObject proj = Instantiate(projectile, transform);
        proj.GetComponent<Projectile>().Init(projectileGun);
        proj.transform.Translate(0, 1, 2, Space.Self);
    }// create a projectile object

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
        if (dead) canvas.enabled = false;// dissapear if dead
    }// gets called every update. when the timer is finished swaps to the idle sprite

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
    }// kills the enemy and sets their sprite to their dead sprite

    void KillThis()
    {
        if (!voiceAudio.isPlaying)
            Destroy(gameObject);
    }
}