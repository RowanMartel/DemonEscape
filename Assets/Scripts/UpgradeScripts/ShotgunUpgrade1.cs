public class ShotgunUpgrade1 : Upgrade
{
    public ShotgunUpgrade1(int level)
    {
        upgradeType = Upgrades.shotgun1;
        upgradeNo = level;

        cost[0] = 50;
        cost[1] = 100;
        cost[2] = 225;
        shotgunRange[0] = 20;
        shotgunRange[1] = 27;
        shotgunRange[2] = 40;
        shotgunRangeRadius[0] = 1.5f;
        shotgunRangeRadius[1] = 2.5f;
        shotgunRangeRadius[2] = 4;

        upgradeName[0] = "Long-Range Shotgun";
        upgradeName[1] = "Sniper Shotgun";
        upgradeName[2] = "The Hunter";
        description[0] = "Increases range and spread";
        description[1] = "Even greater range and spread";
        description[2] = "No varmint can escape this hunting shotgun";
    }
}