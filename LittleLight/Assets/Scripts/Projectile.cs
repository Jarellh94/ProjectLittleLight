using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projSpeed = 10f;
    int damage = 1;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
