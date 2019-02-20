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
    void Update()
    {
        if (player)
        {
            agent.SetDestination(player.position);

            if (Vector3.Distance(transform.position, player.position) <= myAttack.attackRange && !myAttack.GetIsAttacking())
            {
                myAttack.StartAttack();
                Vector3 playerDirection = new Vector3(player.position.x, transform.position.y, player.position.z);
                transform.LookAt(playerDirection);
            }
            else if(myAttack.GetIsAttacking())
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
