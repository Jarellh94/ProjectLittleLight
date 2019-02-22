using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackBox : MonoBehaviour
{
    float knockback;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetKnockback(float value)
    {
        knockback = value;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            GameObject player = col.gameObject;

            player.GetComponent<Rigidbody>().AddForce(knockback * transform.parent.forward);
        }
    }
}
