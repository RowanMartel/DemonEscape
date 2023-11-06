public class SlimeGunner : Enemy
{
    private void Awake()
    {
        attackCooldown = Constants.slimeGunnerAttackCooldown;
        attackRange = Constants.slimeGunnerAttackRange;
        speed = Constants.slimeGunnerSpeed;
        damage = Constants.slimeGunnerDamage;
        firingDistance = Constants.slimeGunnerFiringDistance;
        health = Constants.slimeGunnerHP;
        allowedProximity = Constants.slimeGunnerAllowedProximity;
        money = Constants.slimeGunnerMoney;
    }
}// set stats to the slime gunner stat constants