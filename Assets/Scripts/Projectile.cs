using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject explosion;

    Sprite rocketSprite;
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
        transform.Translate(speed * Time.deltaTime * transform.forward, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            collision.gameObject.GetComponent<Enemy>().TakeDamage(directDamage);

        if (explodes)
        {
            GameObject explosionObj =  Instantiate(explosion);
            explosionObj.GetComponent<Explosion>().Init(blastDamage, blastRadius);
            explosion.transform.SetPositionAndRotation(transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}