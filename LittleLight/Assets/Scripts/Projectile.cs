using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projSpeed = 10f;
    public float destroyTime = 2f;
    public int damage = 1;
    Vector3 direction;

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

    void OnCollisionEnter(Collision col)
    {
        GameObject oth = col.gameObject;

        if(oth.CompareTag("Enemy"))
        {
            Debug.Log("Dealing: " + damage);
            oth.GetComponent<EnemyHealth>().Damage(damage);
        }
        
        if (!oth.CompareTag("Player"))
            Destroy(gameObject);
        
    }
}
