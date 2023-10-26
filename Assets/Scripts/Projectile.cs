using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject explosion;

    [SerializeField] Sprite rocketSprite;
    [SerializeField] Image image;

    float speed;
    bool explodes;
    float directDamage;
    float blastDamage;
    float blastRadius;

    public void Init(Gun gun)
    {
        speed = gun.projectileSpeed;
        explodes = gun.explodes;
        directDamage = gun.damage;
        blastDamage = gun.blastDamage;
        blastRadius = gun.blastRadius;
        if (explodes)
        {
            blastDamage = gun.blastDamage;
            blastRadius = gun.blastRadius;
        }
        switch (gun.gunName)
        {
            case var _ when gun.gunName == Constants.rocketLauncherName:
                image.sprite = rocketSprite;
                break;
        }
    }

    public void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime), Space.Self);
        transform.Rotate(0, 0, Time.deltaTime * 15);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            collision.gameObject.GetComponent<Enemy>().TakeDamage(directDamage);
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            collision.gameObject.GetComponentInParent<Player>().TakeDamage(directDamage);

        if (explodes)
        {
            GameObject explosionObj = Instantiate(explosion);
            explosionObj.GetComponent<Explosion>().Init(blastDamage, blastRadius);
            explosionObj.transform.SetPositionAndRotation(transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}