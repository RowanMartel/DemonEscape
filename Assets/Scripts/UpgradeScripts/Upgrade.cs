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
        for (int i = 0; i < playerStartingHP.Length; i++)
        {
            if (playerStartingHP[i] != 0)
                Constants.playerStartingHP = playerStartingHP[i];
        }
        for (int i = 0; i < playerMaxHP.Length; i++)
        {
            if (playerMaxHP[i] != 0)
                Constants.playerMaxHP = playerMaxHP[i];
        }
        for (int i = 0; i < pistolStartingAmmo.Length; i++)
        {
            if (pistolStartingAmmo[i] != 0)
                Constants.pistolStartingAmmo = pistolStartingAmmo[i];
        }
        for (int i = 0; i < pistolMaxAmmo.Length; i++)
        {
            if (pistolMaxAmmo[i] != 0)
                Constants.pistolMaxAmmo = pistolMaxAmmo[i];
        }
        for (int i = 0; i < pistolDamage.Length; i++)
        {
            if (pistolDamage[i] != 0)
                Constants.pistolDamage = pistolDamage[i];
        }
        for (int i = 0; i < pistolRange.Length; i++)
        {
            if (pistolRange[i] != 0)
                Constants.pistolRange = pistolRange[i];
        }
        for (int i = 0; i < pistolFiringCooldown.Length; i++)
        {
            if (pistolFiringCooldown[i] != 0)
                Constants.pistolFiringCooldown = pistolFiringCooldown[i];
        }
        for (int i = 0; i < shotgunStartingAmmo.Length; i++)
        {
            if (shotgunStartingAmmo[i] != 0)
                Constants.shotgunStartingAmmo = shotgunStartingAmmo[i];
        }
        for (int i = 0; i < shotgunMaxAmmo.Length; i++)
        {
            if (shotgunMaxAmmo[i] != 0)
                Constants.shotgunMaxAmmo = shotgunMaxAmmo[i];
        }
        for (int i = 0; i < shotgunDamage.Length; i++)
        {
            if (shotgunDamage[i] != 0)
                Constants.shotgunDamage = shotgunDamage[i];
        }
        for (int i = 0; i < shotgunRange.Length; i++)
        {
            if (shotgunRange[i] != 0)
                Constants.shotgunRange = shotgunRange[i];
        }
        for (int i = 0; i < shotgunFiringCooldown.Length; i++)
        {
            if (shotgunFiringCooldown[i] != 0)
                Constants.shotgunFiringCooldown = shotgunFiringCooldown[i];
        }
        for (int i = 0; i < shotgunRangeRadius.Length; i++)
        {
            if (shotgunRangeRadius[i] != 0)
                Constants.shotgunRangeRadius = shotgunRangeRadius[i];
        }
    }
}