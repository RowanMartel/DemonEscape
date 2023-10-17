using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun
{
    public enum FiringType
    {
        rayCast,
        sphereCastAll,
        projectile
    }

    public float startingAmmo;
    public float maxAmmo;
    public float damage;
    public float range;
    public float firingCooldown;
    public string name;
    public FiringType firingType;
    public float rangeRadius;
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
        name = Constants.pistolName;
        firingType = Constants.pistolFiringType;
    }
}
public class Shotgun : Gun
{
    public Shotgun()
    {
        startingAmmo = Constants.shotgunStartingAmmo;
        maxAmmo = Constants.shotgunMaxAmmo;
        damage = Constants.shotgunDamage;
        range = Constants.shotgunRange;
        firingCooldown = Constants.shotgunFiringCooldown;
        name = Constants.shotgunName;
        firingType = Constants.shotgunFiringType;
        rangeRadius = Constants.shotgunRangeRadius;
    }
}