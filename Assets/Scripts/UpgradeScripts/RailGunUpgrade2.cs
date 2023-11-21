using System;

[Serializable]
public class RailGunUpgrade2 : Upgrade
{
    public RailGunUpgrade2(int level)
    {
        upgradeType = Upgrades.railGun2;
        upgradeNo = level;

        cost[0] = 55;
        cost[1] = 95;
        cost[2] = 205;
        railGunFiringCooldown[0] = 1.25f;
        railGunFiringCooldown[1] = .1f;
        railGunFiringCooldown[2] = .6f;
        railGunEDS[1] = true;
        railGunEDS[2] = true;
        railGunEDSAmount[1] = 3;
        railGunEDSAmount[2] = 10;
        railGunHoming[0] = true;
        railGunHoming[1] = true;
        railGunHoming[2] = true;

        upgradeName[0] = "Homing Spearhead";
        upgradeName[1] = "EDS";
        upgradeName[2] = "Holy Avenger";
        description[0] = "Shoots faster and projectiles home in on targets";
        description[1] = "Emergency Defense System releases spears at low health";
        description[2] = "They can run but they can't hide";
    }
}