﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBox : MonoBehaviour
{
    public int damage;
    public float attackTime = 0.3f;

    float attackBoxTimer = 0;
    MeshRenderer mesh;
    BoxCollider coll;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        coll = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackBoxTimer > 0)
            attackBoxTimer -= Time.deltaTime;

        if (attackBoxTimer < 0)
        {
            attackBoxTimer = 0;
            mesh.enabled = false;
            coll.enabled = false;
        }
    }

    public void Attacking()
    {
        attackBoxTimer = attackTime;
        mesh.enabled = true;
        coll.enabled = true;
    }

    void OnTriggerEnter(Collider oth)
    {
        if(oth.CompareTag("Player"))
        {
            oth.GetComponent<PlayerHealth>().Damage(damage);
        }
    }
}
