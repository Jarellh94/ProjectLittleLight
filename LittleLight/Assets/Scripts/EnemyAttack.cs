using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ATTACKTYPE { MELEE, RANGE}

public class EnemyAttack : MonoBehaviour
{
    public ATTACKTYPE attackType = ATTACKTYPE.MELEE;
    public float attackRange;
    public float attackSpeed;
    public int damage;

    protected bool isAttacking;
    protected float attackTimer = 0;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttacking)
        {
            if (attackTimer == 0)
            {
                Attack();
            }
        }
        
        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0)
                attackTimer = 0;
        }
        
    }

    public float GetRange()
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

    public virtual void Attack()
    {

    }
}
