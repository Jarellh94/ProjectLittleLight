using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool playerBullet = true;
    public float projSpeed = 10f;
    public float destroyTime = 2f;
    public int damage = 1;
    Vector3 direction;

    Transform shooterTransform;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * projSpeed * Time.deltaTime);
    }

    public void Fired(int newDamage, Vector3 newDirection)
    {
        damage = newDamage;
        direction = newDirection;
    }

    //Alternate function for when fired by player
    public void Fired(int newDamage, Vector3 newDirection, Transform player)
    {
        damage = newDamage;
        direction = newDirection;
        shooterTransform = player;
    }

    void OnCollisionEnter(Collision col)
    {
        GameObject oth = col.gameObject;

        if (playerBullet)
        {
            if (oth.CompareTag("Enemy"))
            {
                oth.GetComponent<EnemyHealth>().Damage(damage);

                //Making enemy attack player when attacked.
                oth.GetComponent<EnemyMovement>().SetTarget(shooterTransform);
            }

            if (oth.CompareTag("Fountain"))
            {
                oth.GetComponent<LightFountain>().Open(damage);
            }

            if(oth.CompareTag("Trigger"))
            {
                oth.GetComponent<TriggerScript>().Trigger();
            }
        }

        if (oth.CompareTag("Player") && !playerBullet)
        {
            oth.GetComponent<PlayerLight>().LoseLight(damage);
            Destroy(gameObject);
        }
        
        if (!oth.CompareTag("Player"))
            Destroy(gameObject);
        
    }
}
