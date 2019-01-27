using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    public int maxLightRange;
    public float fadeSpeed;

    Light myLight;
    
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        LoseLight(fadeSpeed * Time.deltaTime);
    }

    public void AddLight(int amt)
    {
        myLight.range += amt;

        if (myLight.range > maxLightRange)
            myLight.range = maxLightRange;
    }

    public void LoseLight(float amt)
    {
        myLight.range -= amt;

        if (myLight.range <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("You Died");
        myLight.range = maxLightRange;
    }
}
