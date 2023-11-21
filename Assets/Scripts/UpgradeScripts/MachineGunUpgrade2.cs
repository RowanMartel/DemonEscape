using System;

[Serializable]
public class MachineGunUpgrade2 : Upgrade
{
    public MachineGunUpgrade2(int level)
    {
        upgradeType = Upgrades.shotgun2;
        upgradeNo = level;

        cost[0] = 60;
        cost[1] = 110;
        cost[2] = 200;
        machineGunFiringCooldown[0] = .1f;
        machineGunFiringCooldown[1] = .05f;
        machineGunFiringCooldown[2] = .02f;
        machineGunStartingAmmo[0] = 60;
        machineGunStartingAmmo[1] = 120;
        machineGunStartingAmmo[2] = 240;
        machineGunMaxAmmo[0] = 90;
        machineGunMaxAmmo[1] = 180;
        machineGunMaxAmmo[2] = 360;
        machineGunRange[0] = 5;
        machineGunRange[1] = 3;
        machineGunRange[2] = 1;

        upgradeName[0] = "Nail Gun";
        upgradeName[1] = "Jackhammer";
        upgradeName[2] = "Flesh Borer";
        description[0] = "Insane firing speed at short range";
        description[1] = "Ridiculous damage directly in front of you";
        description[2] = "Drill through enemies with your barrel";
    }
}