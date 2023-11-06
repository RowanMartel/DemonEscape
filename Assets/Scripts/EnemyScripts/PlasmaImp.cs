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
    }
}

public class PlasmaImpGunData : Gun
{
    public PlasmaImpGunData()
    {
        damage = Constants.plasmaImpDamage;
        gunName = Constants.plasmaImpGunName;
        projectileSpeed = Constants.plasmaImpProjectileSpeed;
    }
}