using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Idea that different attacks can be handled by animations without need of dedicated functions

public class BossAttack : MonoBehaviour
{
    public float attackInterval;
    public float attackRange;
    public float phaseLength;

    [SerializeField]
    protected float attackTimer = 0;
    [SerializeField]
    protected float phaseTimer = 0;

    bool isAttacking = false;
    bool isAnimating = false;
    
    int currAttack = 1; //1 - Primary, 2 - Strong, 3 - Special then loop back

    // Update is called once per frame
    void Update()
    {
        if(isAttacking)
        {
            switch(currAttack)
            {
                case 1:
                    if (attackTimer == 0)
                    {
                        PrimaryAttack();
                        attackTimer = attackInterval;
                    }
                    break;
                case 2:
                    StrongAttack();
                    break;
                case 3:
                    SpecialAttack();
                    break;
                default:
                    break;
            }
        }

        attackTimer -= Time.deltaTime;
        phaseTimer -= Time.deltaTime;

        if (attackTimer < 0)
            attackTimer = 0;
        if (phaseTimer < 0)
        {
            phaseTimer = 0;
            NextPhase();
        }
    }

    public void StartAttack()
    {
        isAttacking = true;
    }

    public void StopAttack()
    {
        isAttacking = false;
    }

    public void NextPhase()
    {
        //Move to next phase
        phaseTimer = phaseLength;
    }

    public bool GetIsAttacking()
    {
        return isAttacking;
    }

    public bool GetIsAnimating()
    {
        return isAnimating;
    }

    public void StartAnimating()
    {
        isAnimating = true;
    }

    public void StopAnimating()
    {
        isAnimating = false;
    }

    public virtual void PrimaryAttack()
    {

    }

    public virtual void StrongAttack()
    {

    }

    public virtual void SpecialAttack()
    {

    }
}
