using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    // player stats
    public static float playerStartingHP = 100;
    public static float playerMaxHP = 150;

    // gun stats
    // pistol stats
    public static float pistolStartingAmmo = 30;
    public static float pistolMaxAmmo = 60;
    public static float pistolDamage = 10;
    public static float pistolRange = 20;
    public static float pistolFiringCooldown = .5f;
    public static string pistolName = "Pistol";
    public static Gun.FiringType pistolFiringType = Gun.FiringType.rayCast;
    // shotgun stats
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
    public static float slimeGunnerDamage = 5;
    public static float slimeGunnerSpeed = 2;
    public static float slimeGunnerAllowedProximity = 15;
    public static float slimeGunnerAttackCooldown = 3;
    public static float slimeGunnerFiringDistance = 20;
    public static float slimeGunnerAttackRange = 20;

    // segment generation
    public static int segmentsAhead = 2;

    // scene build indexes
    public static int singletonSceneIndex = 0;
    public static int gameplaySceneIndex = 1;
    public static int savesMenuSceneIndex = 2;
    public static int titleScreenSceneIndex = 3;
    public static int upgradeScreenSceneIndex = 4;

    // volume
    public static float startingBGMVol = .5f;
    public static float startingSFXVol = .5f;
}