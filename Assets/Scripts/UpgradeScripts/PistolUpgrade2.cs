using System;

[Serializable]
public class PistolUpgrade2 : Upgrade
{
    public PistolUpgrade2(int level)
    {
        upgradeType = Upgrades.pistol2;
        upgradeNo = level;

        cost[0] = 50;
        cost[1] = 80;
        cost[2] = 180;
        pistolDamage[0] = 20;
        pistolDamage[1] = 35;
        pistolDamage[2] = 60;
        pistolRange[0] = 25;
        pistolRange[1] = 32;
        pistolRange[2] = 40;

        upgradeName[0] = "High-Cal Pistol";
        upgradeName[1] = "Bulldog";
        upgradeName[2] = "Hole-Punch";
        description[0] = "Higher damage and range";
        description[1] = "Damage and range are higher still";
        description[2] = "Punches holes in anything you can see";
    }
}