using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HateBossAttack : BossAttack
{
    Animator anim;

    bool rightPunch = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public override void PrimaryAttack()
    {
        if (rightPunch)
        {
            anim.SetTrigger("RightPunch");
            rightPunch = false;
        }
        else
        {
            anim.SetTrigger("LeftPunch");
            rightPunch = true;
        }
    }

    public override void SpecialAttack()
    {
        base.SpecialAttack();
    }

    public override void StrongAttack()
    {
        base.StrongAttack();
    }
}
