using System;

[Serializable]
public class RocketLauncherUpgrade2 : Upgrade
{
    public RocketLauncherUpgrade2(int level)
    {
        upgradeType = Upgrades.rocketLauncher2;
        upgradeNo = level;

        cost[0] = 50;
        cost[1] = 90;
        cost[2] = 200;

        rocketLauncherProjectileSpeed[0] = 28;
        rocketLauncherProjectileSpeed[1] = 40;
        rocketLauncherProjectileSpeed[2] = 70;
        rocketLauncherDamage[0] = 20;
        rocketLauncherDamage[1] = 35;
        rocketLauncherDamage[2] = 60;
        rocketLauncherFiringCooldown[0] = 2;
        rocketLauncherFiringCooldown[1] = 1;
        rocketLauncherFiringCooldown[2] = .33f;

        upgradeName[0] = "Impact Rocket";
        upgradeName[1] = "Spearhead";
        upgradeName[2] = "Mjolnir";
        description[0] = "Rocket travels faster and does more direct damage";
        description[1] = "Rocket impales enemies with sheer impact force";
        description[2] = "The blast damage is irrelevant";
    }
}