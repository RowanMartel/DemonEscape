using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}