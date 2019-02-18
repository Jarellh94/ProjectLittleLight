using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : EnemyAttack
{
    EnemyAttackBox attackBox;

    void Start()
    {
        attackBox = GetComponentInChildren<EnemyAttackBox>();
    }

    public override void Attack()
    {
        attackTimer = attackSpeed;
        attackBox.Attacking(damage);
    }
}
