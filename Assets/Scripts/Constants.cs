using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    private void Awake()
    {
        Reset();
    }

    // player stats
    public static float playerStartingHP;
    public static float playerMaxHP;

    // gun stats
    // pistol
    public static float pistolStartingAmmo;
    public static float pistolMaxAmmo;
    public static float pistolDamage;
    public static float pistolRange;
    public static float pistolFiringCooldown;
    public static string pistolName;
    public static Gun.FiringType pistolFiringType;
    // shotgun
    public static float shotgunStartingAmmo;
    public static float shotgunMaxAmmo;
    public static float shotgunDamage;
    public static float shotgunRange;
    public static float shotgunFiringCooldown;
    public static string shotgunName;
    public static Gun.FiringType shotgunFiringType;
    public static float shotgunRangeRadius;

    // enemy stats
    // slime gunner
    public static float slimeGunnerHP;
    public static float slimeGunnerDamage;
    public static float slimeGunnerSpeed;
    public static float slimeGunnerAllowedProximity;
    public static float slimeGunnerAttackCooldown;
    public static float slimeGunnerFiringDistance;
    public static float slimeGunnerAttackRange;

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
        pistolName = "Pistol";
        pistolFiringType = Gun.FiringType.rayCast;
        // shotgun
        shotgunStartingAmmo = 15;
        shotgunMaxAmmo = 30;
        shotgunDamage = 20;
        shotgunRange = 15;
        shotgunFiringCooldown = 1;
        shotgunName = "Shotgun";
        shotgunFiringType = Gun.FiringType.sphereCastAll;
        shotgunRangeRadius = 1;

        // enemy stats
        // slime gunner
        slimeGunnerHP = 20;
        slimeGunnerDamage = 5;
        slimeGunnerSpeed = 2;
        slimeGunnerAllowedProximity = 15;
        slimeGunnerAttackCooldown = 3;
        slimeGunnerFiringDistance = 20;
        slimeGunnerAttackRange = 20;
    }
}