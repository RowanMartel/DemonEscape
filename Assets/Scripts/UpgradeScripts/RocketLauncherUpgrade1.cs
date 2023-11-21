using System;

[Serializable]
public class RocketLauncherUpgrade1 : Upgrade
{
    public RocketLauncherUpgrade1(int level)
    {
        upgradeType = Upgrades.rocketLauncher1;
        upgradeNo = level;

        cost[0] = 60;
        cost[1] = 130;
        cost[2] = 300;

        rocketLauncherBlastDamage[0] = 60;
        rocketLauncherBlastDamage[1] = 100;
        rocketLauncherBlastDamage[2] = 180;
        rocketLauncherBlastRadius[0] = 5;
        rocketLauncherBlastRadius[1] = 7;
        rocketLauncherBlastRadius[2] = 10;
        rocketLauncherProjectileSpeed[2] = 25;

        upgradeName[0] = "TNT Launcher";
        upgradeName[1] = "Big Bertha";
        upgradeName[2] = "Fat Man";
        description[0] = "Bigger and stronger explosion";
        description[1] = "Even bigger and stronger";
        description[2] = "Nuclear devestation";
    }
}