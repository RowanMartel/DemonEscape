using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Upgrade;

public class RocketLauncherUpgrade1 : Upgrade
{
    public RocketLauncherUpgrade1(int level)
    {
        upgradeType = Upgrades.rocketLauncher1;
        upgradeNo = level;

        cost[0] = 50;
        cost[1] = 100;
        cost[2] = 225;


        upgradeName[0] = "TNT Launcher";
        upgradeName[1] = "Big Bertha";
        upgradeName[2] = "Fat Man";
        description[0] = "Bigger and stronger explosion";
        description[1] = "Even bigger and stronger";
        description[2] = "Leave your enemies looking like Hiroshima";
    }
}