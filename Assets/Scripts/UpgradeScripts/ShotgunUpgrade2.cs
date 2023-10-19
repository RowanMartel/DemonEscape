public class ShotgunUpgrade2 : Upgrade
{
    public ShotgunUpgrade2(int level)
    {
        upgradeNo = level;

        cost[0] = 55;
        cost[1] = 110;
        cost[2] = 260;
        shotgunDamage[0] = 30;
        shotgunDamage[1] = 50;
        shotgunDamage[2] = 100;
        shotgunRange[1] = 12;
        shotgunRange[2] = 8;
        shotgunRangeRadius[2] = 10;

        upgradeName[0] = "Super Shotgun";
        upgradeName[1] = "Machete";
        upgradeName[2] = "Bullet Wall";
        description[0] = "Increases damage";
        description[1] = "Trades range for massive damage";
        description[2] = "Everything near you dies";
    }
}