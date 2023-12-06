using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public enum Powerups
    {
        invincible,
        infiniteAmmo,
        doubleDamage
    }
    [SerializeField] Powerups type;
    Player player;
    [SerializeField] AudioClip pickupSFX;

    private void OnTriggerEnter(Collider other)
    {
        Collect(other.gameObject);
    }

    public void Collect(GameObject other)
    {
        if (!other.CompareTag("PlayerCapsule") && !other.CompareTag("Projectile") && !other.CompareTag("Explosion")) return;

        Player player = FindObjectOfType<Player>();
        switch (type)
        {
            case Powerups.invincible:
                player.ActivatePowerup(Powerups.invincible);
                break;
            case Powerups.infiniteAmmo:
                player.ActivatePowerup(Powerups.infiniteAmmo);
                break;
            case Powerups.doubleDamage:
                player.ActivatePowerup(Powerups.doubleDamage);
                break;
        }
        player.PlayPickupSFX(pickupSFX);
        Destroy(gameObject);
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        transform.LookAt(player.transform.position);
    }
}