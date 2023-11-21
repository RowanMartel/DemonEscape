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
    public const string pistolName = "Pistol";
    public static Gun.FiringType pistolFiringType = Gun.FiringType.rayCast;
    // shotgun
    public static float shotgunStartingAmmo = 15;
    public static float shotgunMaxAmmo = 30;
    public static float shotgunDamage = 20;
    public static float shotgunRange = 15;
    public static float shotgunFiringCooldown = 1;
    public const string shotgunName = "Shotgun";
    public static Gun.FiringType shotgunFiringType = Gun.FiringType.sphereCastAll;
    public static float shotgunRangeRadius = 1;
    // rocket launcher
    public static float rocketLauncherStartingAmmo = 8;
    public static float rocketLauncherMaxAmmo = 12;
    public static float rocketLauncherDamage = 10;
    public static float rocketLauncherFiringCooldown = 3;
    public const string rocketLauncherName = "RocketLauncher";
    public static Gun.FiringType rocketLauncherFiringType = Gun.FiringType.projectile;
    public static float rocketLauncherProjectileSpeed = 20;
    public static bool rocketLauncherExplodes = true;
    public static float rocketLauncherBlastDamage = 40;
    public static float rocketLauncherBlastRadius = 3;
    // machine gun
    public static float machineGunStartingAmmo = 30;
    public static float machineGunMaxAmmo = 60;
    public static float machineGunDamage = 7;
    public static float machineGunRange = 20;
    public static float machineGunFiringCooldown = .35f;
    public const string machineGunName = "MachineGun";
    public static bool machineGunAutomatic = true;
    public static Gun.FiringType machineGunFiringType = Gun.FiringType.rayCast;

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
    // plasma imp
    public static float plasmaImpHP = 25;
    public static float plasmaImpDamage = 15;
    public static float plasmaImpSpeed = 5;
    public static float plasmaImpAllowedProximity = 20;
    public static float plasmaImpAttackCooldown = 2;
    public static float plasmaImpFiringDistance = 20;
    public static float plasmaImpAttackRange = 20;
    public static int plasmaImpMoney = 10;
    public const string plasmaImpGunName = "PlasmaImp";
    public static float plasmaImpProjectileSpeed = 35;
    // slime slasher
    public static float slimeSlasherHP = 80;
    public static float slimeSlasherDamage = 50;
    public static float slimeSlasherSpeed = 5;
    public static float slimeSlasherAllowedProximity = 2;
    public static float slimeSlasherAttackCooldown = 5;
    public static float slimeSlasherFiringDistance = 1;
    public static float slimeSlasherAttackRange = 2;
    public static float slimeSlasherRangeRadius = 2;
    public static int slimeSlasherMoney = 50;

    // segment generation
    public const int segmentsAhead = 2;

    // scene build indexes
    public const int titleScreenSceneIndex = 0;
    public const int gameplaySceneIndex = 1;
    public const int savesMenuSceneIndex = 2;
    public const int upgradeScreenSceneIndex = 3;
    public const int endingScreenSceneIndex = 4;
    public const int singletonSceneIndex = 5;

    // volume
    public const float startingBGMVol = .5f;
    public const float startingSFXVol = .5f;

    // distance stats
    public const float maxDistance = 1000;
    public const float distanceStep = 5;

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
        // rocket launcher
        rocketLauncherStartingAmmo = 8;
        rocketLauncherMaxAmmo = 12;
        rocketLauncherDamage = 10;
        rocketLauncherFiringCooldown = 3;
        rocketLauncherProjectileSpeed = 20;
        rocketLauncherExplodes = true;
        rocketLauncherBlastDamage = 40;
        rocketLauncherBlastRadius = 3;
    }// resets non const variables
}