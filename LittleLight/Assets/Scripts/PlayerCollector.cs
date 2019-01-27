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
            myLight.AddLight(oth.GetComponent<LightPickup>().GetLightValue());
            Destroy(oth.gameObject);
        }
    }
}
