public class BrainCan : Enemy
{
    private void Awake()
    {
        attackCooldown = Constants.brainCanAttackCooldown;
        attackRange = Constants.brainCanAttackRange;
        speed = Constants.brainCanSpeed;
        damage = Constants.brainCanDamage;
        firingDistance = Constants.brainCanFiringDistance;
        health = Constants.brainCanHP;
        allowedProximity = Constants.brainCanAllowedProximity;
        money = Constants.brainCanMoney;
        projectileGun = new BrainCanGunData();
        firingType = Gun.FiringType.projectile;
    }
}// set stats to the brain can stat constants

public class BrainCanGunData : Gun
{
    public BrainCanGunData()
    {
        damage = Constants.brainCanDamage;
        gunName = Constants.brainCanGunName;
        projectileSpeed = Constants.brainCanProjectileSpeed;
    }
}// gun data for the brain can's projectiles