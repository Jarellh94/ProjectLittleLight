using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;

    EnemyAttack myAttack;

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        myAttack = GetComponent<EnemyAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            agent.SetDestination(player.position);

            if (Vector3.Distance(transform.position, player.position) <= myAttack.GetRange())
            {
                myAttack.StartAttack();
                transform.LookAt(player);
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
