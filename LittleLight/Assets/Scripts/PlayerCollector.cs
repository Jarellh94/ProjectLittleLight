using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    PlayerLight myLight;

    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<PlayerLight>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider oth)
    {
        if(oth.CompareTag("Light"))
        {
            oth.GetComponent<LightPickup>().StartPickup(transform);
        }
    }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Light"))
        {
            myLight.AddLight(col.gameObject.GetComponent<LightPickup>().GetLightValue());
            Destroy(col.gameObject);
        }
    }
}
