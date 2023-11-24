using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject explosion;

    [SerializeField] Sprite rocketSprite;
    [SerializeField] Sprite plasmaSprite;
    [SerializeField] Sprite railSprite;
    [SerializeField] Image image;

    float speed;
    bool explodes;
    float directDamage;
    float blastDamage;
    float blastRadius;
    bool homing;
    bool collided = false;
    bool dontCollide = false;// for EDS

    public void Init(Gun gun, bool doubleDamage = false)
    {
        transform.SetParent(null);
        speed = gun.projectileSpeed;
        explodes = gun.explodes;
        directDamage = gun.damage;
        if (doubleDamage) directDamage *= 2;
        if (explodes)
        {
            blastDamage = gun.blastDamage;
            if (doubleDamage) blastDamage *= 2;
            blastRadius = gun.blastRadius;
        }
        homing = gun.homing;
        switch (gun.gunName)
        {
            case Constants.rocketLauncherName:
                image.sprite = rocketSprite;
                break;
            case Constants.plasmaImpGunName:
            case Constants.brainCanGunName:
                image.sprite = plasmaSprite;
                break;
            case Constants.railGunName:
                image.sprite = railSprite;
                dontCollide = true;
                break;
        }// determine which projectile sprite to use
    }

    public void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime), Space.Self);
        transform.Rotate(0, 0, Time.deltaTime * 15);

        if (homing) Home();
    }

    void Home()
    {
        Debug.Log("homing in");
        Collider[] hits = Physics.OverlapSphere(transform.position + transform.forward * 2, 2, LayerMask.GetMask("Enemy"));
        float shortestDistance = float.MaxValue;
        Transform closestTarget = null;
        foreach (Collider c in hits)
        {
            float distance = Vector3.Distance(transform.position, c.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestTarget = c.transform;
            }
        }// determine the closest enemy
        if (closestTarget != null) transform.LookAt(closestTarget);
    }// point towards the closest enemy

    private void OnCollisionEnter(Collision collision)
    {
        if (collided) return;

        // code to make EDS projectiles not collide with each other
        Projectile otherProj = collision.gameObject.GetComponent<Projectile>();
        if (otherProj != null && otherProj.dontCollide && dontCollide) return;

        collided = true;

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            collision.gameObject.GetComponent<Enemy>().TakeDamage(directDamage);
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            collision.gameObject.GetComponentInParent<Player>().TakeDamage(directDamage);

        if (explodes)
        {
            GameObject explosionObj = Instantiate(explosion);
            explosionObj.GetComponent<Explosion>().Init(blastDamage, blastRadius);
            explosionObj.transform.SetPositionAndRotation(transform.position, transform.rotation);
        }// create an explosion object if the projectile is explosive

        Destroy(gameObject);
    }
}