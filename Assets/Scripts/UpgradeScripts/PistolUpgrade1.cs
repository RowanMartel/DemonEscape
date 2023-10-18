public class PistolUpgrade1 : Upgrade
{
    PistolUpgrade1()
    {
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
    }
}
