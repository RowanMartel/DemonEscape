using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun
{
    public float startingAmmo;
    public float maxAmmo;
    public float damage;
    public float range;
    public float firingCooldown;
    public string name;
}
public class Pistol : Gun
{
    public Pistol()
    {
        startingAmmo = Constants.pistolStartingAmmo;
        maxAmmo = Constants.pistolMaxAmmo;
        damage = Constants.pistolDamage;
        range = Constants.pistolRange;
        firingCooldown = Constants.pistolFiringCooldown;
        name = "Pistol";
    }
}