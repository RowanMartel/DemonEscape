using System;

[Serializable]
public abstract class Upgrade
{
    public enum Upgrades
    {
        pistol1, pistol2,
        shotgun1, shotgun2,
        rocketLauncher1, rocketLauncher2,
        machineGun1, machineGun2,
        railGun1, railGun2
    }
    public Upgrades upgradeType;

    public float[] cost = new float[3];
    public int upgradeNo;

    // suit upgrades
    public float[] playerStartingHP = new float[3];
    public float[] playerMaxHP = new float[3];

    // gun upgrades
    // pistol
    public float[] pistolStartingAmmo = new float[3];
    public float[] pistolMaxAmmo = new float[3];
    public float[] pistolDamage = new float[3];
    public float[] pistolRange = new float[3];
    public float[] pistolFiringCooldown = new float[3];
    // shotgun
    public float[] shotgunStartingAmmo = new float[3];
    public float[] shotgunMaxAmmo = new float[3];
    public float[] shotgunDamage = new float[3];
    public float[] shotgunRange = new float[3];
    public float[] shotgunFiringCooldown = new float[3];
    public float[] shotgunRangeRadius = new float[3];
    // rocket launcher
    public float[] rocketLauncherStartingAmmo = new float[3];
    public float[] rocketLauncherMaxAmmo = new float[3];
    public float[] rocketLauncherDamage = new float[3];
    public float[] rocketLauncherFiringCooldown = new float[3];
    public float[] rocketLauncherProjectileSpeed = new float[3];
    public float[] rocketLauncherBlastDamage = new float[3];
    public float[] rocketLauncherBlastRadius = new float[3];
    // machine gun
    public float[] machineGunStartingAmmo = new float[3];
    public float[] machineGunMaxAmmo = new float[3];
    public float[] machineGunDamage = new float[3];
    public float[] machineGunRange = new float[3];
    public float[] machineGunFiringCooldown = new float[3];
    // rail gun
    public float[] railGunStartingAmmo = new float[3];
    public float[] railGunMaxAmmo = new float[3];
    public float[] railGunDamage = new float[3];
    public float[] railGunFiringCooldown = new float[3];
    public float[] railGunProjectileSpeed = new float[3];
    public bool[] railGunEDS = new bool[3];
    public int[] railGunEDSAmount = new int[3];
    public bool[] railGunHoming = new bool[3];

    // upgrade screen info
    public string[] upgradeName = new string[3];
    public string[] description = new string[3];

    public void Apply()
    {
        if (playerStartingHP[upgradeNo] != 0) Constants.playerStartingHP = playerStartingHP[upgradeNo];
        if (playerMaxHP[upgradeNo] != 0) Constants.playerMaxHP = playerMaxHP[upgradeNo];
        if (pistolStartingAmmo[upgradeNo] != 0) Constants.pistolStartingAmmo = pistolStartingAmmo[upgradeNo];
        if (pistolMaxAmmo[upgradeNo] != 0) Constants.pistolMaxAmmo = pistolMaxAmmo[upgradeNo];
        if (pistolDamage[upgradeNo] != 0) Constants.pistolDamage = pistolDamage[upgradeNo];
        if (pistolRange[upgradeNo] != 0) Constants.pistolRange = pistolRange[upgradeNo];
        if (pistolFiringCooldown[upgradeNo] != 0) Constants.pistolFiringCooldown = pistolFiringCooldown[upgradeNo];
        if (shotgunStartingAmmo[upgradeNo] != 0) Constants.shotgunStartingAmmo = shotgunStartingAmmo[upgradeNo];
        if (shotgunMaxAmmo[upgradeNo] != 0) Constants.shotgunMaxAmmo = shotgunMaxAmmo[upgradeNo];
        if (shotgunDamage[upgradeNo] != 0) Constants.shotgunDamage = shotgunDamage[upgradeNo];
        if (shotgunRange[upgradeNo] != 0) Constants.shotgunRange = shotgunRange[upgradeNo];
        if (shotgunFiringCooldown[upgradeNo] != 0) Constants.shotgunFiringCooldown = shotgunFiringCooldown[upgradeNo];
        if (shotgunRangeRadius[upgradeNo] != 0) Constants.shotgunRangeRadius = shotgunRangeRadius[upgradeNo];
        if (rocketLauncherStartingAmmo[upgradeNo] != 0) Constants.rocketLauncherStartingAmmo = rocketLauncherStartingAmmo[upgradeNo];
        if (rocketLauncherMaxAmmo[upgradeNo] != 0) Constants.rocketLauncherMaxAmmo = rocketLauncherMaxAmmo[upgradeNo];
        if (rocketLauncherDamage[upgradeNo] != 0) Constants.rocketLauncherDamage = rocketLauncherDamage[upgradeNo];
        if (rocketLauncherFiringCooldown[upgradeNo] != 0) Constants.rocketLauncherFiringCooldown = rocketLauncherFiringCooldown[upgradeNo];
        if (rocketLauncherProjectileSpeed[upgradeNo] != 0) Constants.rocketLauncherProjectileSpeed = rocketLauncherProjectileSpeed[upgradeNo];
        if (rocketLauncherBlastDamage[upgradeNo] != 0) Constants.rocketLauncherBlastDamage = rocketLauncherBlastDamage[upgradeNo];
        if (rocketLauncherBlastRadius[upgradeNo] != 0) Constants.rocketLauncherBlastRadius = rocketLauncherBlastRadius[upgradeNo];
        if (machineGunStartingAmmo[upgradeNo] != 0) Constants.machineGunStartingAmmo = machineGunStartingAmmo[upgradeNo];
        if (machineGunMaxAmmo[upgradeNo] != 0) Constants.machineGunMaxAmmo = machineGunMaxAmmo[upgradeNo];
        if (machineGunDamage[upgradeNo] != 0) Constants.machineGunDamage = machineGunDamage[upgradeNo];
        if (machineGunRange[upgradeNo] != 0) Constants.machineGunRange = machineGunRange[upgradeNo];
        if (machineGunFiringCooldown[upgradeNo] != 0) Constants.machineGunFiringCooldown = machineGunFiringCooldown[upgradeNo];
        if (railGunStartingAmmo[upgradeNo] != 0) Constants.railGunStartingAmmo = railGunStartingAmmo[upgradeNo];
        if (railGunMaxAmmo[upgradeNo] != 0) Constants.railGunMaxAmmo = railGunMaxAmmo[upgradeNo];
        if (railGunDamage[upgradeNo] != 0) Constants.railGunDamage = railGunDamage[upgradeNo];
        if (railGunFiringCooldown[upgradeNo] != 0) Constants.railGunFiringCooldown = railGunFiringCooldown[upgradeNo];
        if (railGunProjectileSpeed[upgradeNo] != 0) Constants.railGunProjectileSpeed = railGunProjectileSpeed[upgradeNo];
        if (railGunEDS[upgradeNo]) Constants.railGunEDS = railGunEDS[upgradeNo];
        if (railGunEDSAmount[upgradeNo] != 0) Constants.railGunEDSAmount = railGunEDSAmount[upgradeNo];
        if (railGunHoming[upgradeNo]) Constants.railGunHoming = railGunHoming[upgradeNo];
    }// if a value is not 0 or false, apply it to the constants
}