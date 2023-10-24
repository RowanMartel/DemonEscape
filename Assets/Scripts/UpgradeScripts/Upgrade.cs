using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public abstract class Upgrade
{
    public enum Upgrades
    {
        pistol1, pistol2,
        shotgun1, shotgun2
    }

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
    }
}