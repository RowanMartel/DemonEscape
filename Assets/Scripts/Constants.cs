using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    // player stats
    public static float playerStartingHP = 100;
    public static float playerMaxHP = 150;

    // gun stats

    // pistols stats
    public static float pistolStartingAmmo = 30;
    public static float pistolMaxAmmo = 60;
    public static float pistolDamage = 10;
    public static float pistolRange = 20;
    public static float pistolFiringCooldown = 0.5f;

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
}