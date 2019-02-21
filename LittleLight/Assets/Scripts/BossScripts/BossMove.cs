using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMove : MonoBehaviour
{
    Transform player;

    BossAttack myAttack;

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        myAttack = GetComponent<BossAttack>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player)
        {
            agent.SetDestination(player.position);

            if (Vector3.Distance(transform.position, player.position) <= myAttack.attackRange)
            {
                if (!myAttack.GetIsAttacking())
                    myAttack.StartAttack();

                if (!myAttack.GetIsAnimating())
                {
                    //Vector3 playerDirection = new Vector3(player.position.x, transform.position.y, player.position.z);
                    //transform.LookAt(playerDirection);

                    Vector3 playerDirection = player.position - transform.position;
                    Quaternion look = Quaternion.LookRotation(playerDirection);

                    transform.rotation = Quaternion.Lerp(transform.rotation, look, 5 * Time.deltaTime);
                }
            }
            else
            {
                myAttack.StopAttack();
            }
        }
    }

    public void SetTarget(Transform targetPlayer)
    {
        player = targetPlayer;
    }

}
