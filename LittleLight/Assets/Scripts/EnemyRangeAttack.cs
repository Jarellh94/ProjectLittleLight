using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : EnemyAttack
{
    public GameObject proj;
    public Transform firePoint;

    public override void Attack()
    {
        GameObject newProj = Instantiate(proj, firePoint.position, Quaternion.identity);
        attackTimer = attackSpeed;

        newProj.GetComponent<Projectile>().Fired(damage, transform.forward);
    }
}
