using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float shootSpeed = 0f;
    public GameObject proj;
    public Transform firePoint;
    public int damage = 5;

    float shootCounter = 0;

    //private Camera cam;
    

    // Start is called before the first frame update
    void Awake()
    {
        //cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            if(shootCounter >= shootSpeed)
                Shoot();
        }

        if(shootCounter < shootSpeed)
        {
            shootCounter += Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject newProj = Instantiate(proj, firePoint.position, Quaternion.identity);
        shootCounter = 0;

        newProj.GetComponent<Projectile>().Fired(damage, transform.forward, transform);
    }
}
