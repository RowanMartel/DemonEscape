public class SlimeSlasher : Enemy
{
    private void Awake()
    {
        attackCooldown = Constants.slimeSlasherAttackCooldown;
        attackRange = Constants.slimeSlasherAttackRange;
        rangeRadius = Constants.slimeSlasherRangeRadius;
        speed = Constants.slimeSlasherSpeed;
        damage = Constants.slimeSlasherDamage;
        firingDistance = Constants.slimeSlasherFiringDistance;
        health = Constants.slimeSlasherHP;
        allowedProximity = Constants.slimeSlasherAllowedProximity;
        money = Constants.slimeSlasherMoney;
        firingType = Gun.FiringType.sphereCastAll;
    }
}// set stats to the slime slasher stat constants