using System;

[Serializable]
public class RailGunUpgrade1 : Upgrade
{
    public RailGunUpgrade1(int level)
    {
        upgradeType = Upgrades.railGun1;
        upgradeNo = level;

        cost[0] = 50;
        cost[1] = 80;
        cost[2] = 180;
        railGunProjectileSpeed[0] = 70;
        railGunProjectileSpeed[1] = 100;
        railGunProjectileSpeed[2] = 150;
        railGunDamage[0] = 40;
        railGunDamage[1] = 60;
        railGunDamage[2] = 100;

        upgradeName[0] = "Javelin";
        upgradeName[1] = "Lancelot";
        upgradeName[2] = "The Impaler";
        description[0] = "Pierces enemies faster and harder";
        description[1] = "Spear travels even faster and does more damage";
        description[2] = "As the name implies";
    }
}