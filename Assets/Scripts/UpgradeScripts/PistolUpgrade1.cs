public class PistolUpgrade1 : Upgrade
{
    public PistolUpgrade1(int level)
    {
        upgradeType = Upgrades.pistol1;
        upgradeNo = level;

        cost[0] = 50;
        cost[1] = 80;
        cost[2] = 180;
        pistolStartingAmmo[0] = 60;
        pistolStartingAmmo[1] = 120;
        pistolStartingAmmo[2] = 240;
        pistolMaxAmmo[0] = 90;
        pistolMaxAmmo[1] = 180;
        pistolMaxAmmo[2] = 360;
        pistolFiringCooldown[0] = .35f;
        pistolFiringCooldown[1] = .2f;
        pistolFiringCooldown[2] = .05f;

        upgradeName[0] = "Faster Pistol";
        upgradeName[1] = "Supercharge Pistol";
        upgradeName[2] = "Pistol la Vista";
        description[0] = "Increases firing speed and ammo";
        description[1] = "Try not to run out of bullets";
        description[2] = "How fast can you click?";
    }
}