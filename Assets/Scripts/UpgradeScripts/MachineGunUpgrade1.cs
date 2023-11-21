using System;

[Serializable]
public class MachineGunUpgrade1 : Upgrade
{
    public MachineGunUpgrade1(int level)
    {
        upgradeType = Upgrades.machineGun1;
        upgradeNo = level;

        cost[0] = 50;
        cost[1] = 90;
        cost[2] = 180;
        machineGunFiringCooldown[0] = .25f;
        machineGunFiringCooldown[1] = .15f;
        machineGunFiringCooldown[2] = .05f;
        machineGunStartingAmmo[0] = 60;
        machineGunStartingAmmo[1] = 120;
        machineGunStartingAmmo[2] = 240;
        machineGunMaxAmmo[0] = 120;
        machineGunMaxAmmo[1] = 240;
        machineGunMaxAmmo[2] = 480;

        upgradeName[0] = "Gatling Gun";
        upgradeName[1] = "Minigun";
        upgradeName[2] = "Danmaku";
        description[0] = "Faster firing rate and more bullets";
        description[1] = "Turn your enemies into swiss cheese";
        description[2] = "I need more boullets!";
    }
}