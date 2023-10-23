using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    // player stats
    public static float playerStartingHP = 100;
    public static float playerMaxHP = 150;

    // gun stats
    // pistol
    public static float pistolStartingAmmo = 30;
    public static float pistolMaxAmmo = 60;
    public static float pistolDamage = 10;
    public static float pistolRange = 20;
    public static float pistolFiringCooldown = .5f;
    public static string pistolName = "Pistol";
    public static Gun.FiringType pistolFiringType = Gun.FiringType.rayCast;
    // shotgun
    public static float shotgunStartingAmmo = 15;
    public static float shotgunMaxAmmo = 30;
    public static float shotgunDamage = 20;
    public static float shotgunRange = 15;
    public static float shotgunFiringCooldown = 1;
    public static string shotgunName = "Shotgun";
    public static Gun.FiringType shotgunFiringType = Gun.FiringType.sphereCastAll;
    public static float shotgunRangeRadius = 1;

    // enemy stats
    // slime gunner
    public static float slimeGunnerHP = 20;
    public static float slimeGunnerDamage = 10;
    public static float slimeGunnerSpeed = 2;
    public static float slimeGunnerAllowedProximity = 15;
    public static float slimeGunnerAttackCooldown = 3;
    public static float slimeGunnerFiringDistance = 20;
    public static float slimeGunnerAttackRange = 20;
    public static int slimeGunnerMoney = 5;

    // segment generation
    public const int segmentsAhead = 2;

    // scene build indexes
    public const int singletonSceneIndex = 0;
    public const int gameplaySceneIndex = 1;
    public const int savesMenuSceneIndex = 2;
    public const int titleScreenSceneIndex = 3;
    public const int upgradeScreenSceneIndex = 4;

    // volume
    public const float startingBGMVol = .5f;
    public const float startingSFXVol = .5f;

    public static void Reset()
    {
        // player stats
        playerStartingHP = 100;
        playerMaxHP = 150;

        // gun stats
        // pistol
        pistolStartingAmmo = 30;
        pistolMaxAmmo = 60;
        pistolDamage = 10;
        pistolRange = 20;
        pistolFiringCooldown = .5f;
        // shotgun
        shotgunStartingAmmo = 15;
        shotgunMaxAmmo = 30;
        shotgunDamage = 20;
        shotgunRange = 15;
        shotgunFiringCooldown = 1;
        shotgunRangeRadius = 1;

        // enemy stats
        // slime gunner
        slimeGunnerHP = 20;
        slimeGunnerDamage = 10;
        slimeGunnerSpeed = 2;
        slimeGunnerAllowedProximity = 15;
        slimeGunnerAttackCooldown = 3;
        slimeGunnerFiringDistance = 20;
        slimeGunnerAttackRange = 20;
    }
}