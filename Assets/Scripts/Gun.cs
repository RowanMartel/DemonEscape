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
    public string gunName;
    public FiringType firingType;
    public float rangeRadius;
    public float projectileSpeed;
    public bool explodes;
    public float blastDamage;
    public float blastRadius;
    public bool automatic;
    public bool homing;
    public bool EDS;
    public int EDSAmount;

    public float currentAmmo;
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
        gunName = Constants.pistolName;
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
        gunName = Constants.shotgunName;
        firingType = Constants.shotgunFiringType;
        rangeRadius = Constants.shotgunRangeRadius;
    }
}
public class RocketLauncher : Gun
{
    public RocketLauncher()
    {
        startingAmmo = Constants.rocketLauncherStartingAmmo;
        maxAmmo = Constants.rocketLauncherMaxAmmo;
        damage = Constants.rocketLauncherDamage;
        firingCooldown = Constants.rocketLauncherFiringCooldown;
        gunName = Constants.rocketLauncherName;
        firingType = Constants.rocketLauncherFiringType;
        projectileSpeed = Constants.rocketLauncherProjectileSpeed;
        explodes = Constants.rocketLauncherExplodes;
        blastDamage = Constants.rocketLauncherBlastDamage;
        blastRadius = Constants.rocketLauncherBlastRadius;
    }
}
public class MachineGun : Gun
{
    public MachineGun()
    {
        startingAmmo = Constants.machineGunStartingAmmo;
        maxAmmo = Constants.machineGunMaxAmmo;
        damage = Constants.machineGunDamage;
        range = Constants.machineGunRange;
        firingCooldown = Constants.machineGunFiringCooldown;
        gunName = Constants.machineGunName;
        firingType = Constants.machineGunFiringType;
        automatic = Constants.machineGunAutomatic;
    }
}
public class RailGun : Gun
{
    public RailGun()
    {
        startingAmmo = Constants.railGunStartingAmmo;
        maxAmmo = Constants.railGunMaxAmmo;
        damage = Constants.railGunDamage;
        firingCooldown = Constants.railGunFiringCooldown;
        gunName = Constants.railGunName;
        firingType = Constants.railGunFiringType;
        projectileSpeed = Constants.railGunProjectileSpeed;
        EDS = Constants.railGunEDS;
        EDSAmount = Constants.railGunEDSAmount;
        homing = Constants.railGunHoming;
    }
}