using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPickup : MonoBehaviour
{
    public int lightValue;
    public int moveSpeed;

    Transform target;
    bool pickingUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pickingUp)
        {
            transform.LookAt(target);
            transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    public int GetLightValue()
    {
        return lightValue;
    }
    
    public void StartPickup(Transform player)
    {
        target = player;
        pickingUp = true;
    }
}
