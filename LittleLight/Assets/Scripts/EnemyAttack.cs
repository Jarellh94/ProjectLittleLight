using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ATTACKTYPE { MELEE, RANGE}

public class EnemyAttack : MonoBehaviour
{
    public ATTACKTYPE attackType = ATTACKTYPE.MELEE;
    public float attackRange;
    public float attackSpeed;

    bool isAttacking;
    float attackTimer = 0;

    EnemyAttackBox attackBox;

    // Start is called before the first frame update
    void Start()
    {
        attackBox = GetComponentInChildren<EnemyAttackBox>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttacking)
        {
            if (attackTimer == 0)
            {
                if (attackType == ATTACKTYPE.MELEE)
                    Attack();
                else if (attackType == ATTACKTYPE.RANGE)
                    Shoot();
            }
        }
        
        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0)
                attackTimer = 0;
        }
        
    }

    public float GetAttackRange()
    {
        return attackRange;
    }

    public void StartAttack()
    {
        isAttacking = true;
    }

    public void StopAttack()
    {
        isAttacking = false;
    }

    void Attack()
    {
        attackTimer = attackSpeed;
        attackBox.Attacking();
    }

    void Shoot()
    {

    }
}
