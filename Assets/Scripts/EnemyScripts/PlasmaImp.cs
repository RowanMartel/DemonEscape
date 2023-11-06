public class PlasmaImp : Enemy
{
    private void Awake()
    {
        attackCooldown = Constants.plasmaImpAttackCooldown;
        attackRange = Constants.plasmaImpAttackRange;
        speed = Constants.plasmaImpSpeed;
        damage = Constants.plasmaImpDamage;
        firingDistance = Constants.plasmaImpFiringDistance;
        health = Constants.plasmaImpHP;
        allowedProximity = Constants.plasmaImpAllowedProximity;
        money = Constants.plasmaImpMoney;
        projectileGun = new PlasmaImpGunData();
    }
}// set stats to the plasma imp stat constants

public class PlasmaImpGunData : Gun
{
    public PlasmaImpGunData()
    {
        damage = Constants.plasmaImpDamage;
        gunName = Constants.plasmaImpGunName;
        projectileSpeed = Constants.plasmaImpProjectileSpeed;
    }
}// gun data for the plasma imp's projectiles