using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFountain : MonoBehaviour
{
    public GameObject lightPrefab;
    public int spawnRange;
    public float spawnFrequency;
    public float spawnForce;
    public float spawnHeight;
    public Transform spawnPoint;
    public Material lightMat;

    float spawnTimer;

    bool isActive = false;
    int hitNum = 2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (spawnTimer > 0)
                spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0)
            {
                SpawnLight();
                spawnTimer = spawnFrequency;
            }
        }
    }

    void SpawnLight()
    {
        float x = Random.Range(-spawnRange * spawnForce, spawnRange * spawnForce);
        float z = Random.Range(-spawnRange * spawnForce, spawnRange * spawnForce);
        
        GameObject newLight = Instantiate(lightPrefab, spawnPoint.position, Quaternion.identity);

        newLight.GetComponent<Rigidbody>().AddForce(x, spawnHeight * spawnForce, z);
    }

    public void Open(int value)
    {
        hitNum -= value;

        if(hitNum <= 0)
        {
            isActive = true;
            GetComponent<MeshRenderer>().material = lightMat;
            GetComponent<Light>().enabled = true;
        }
    }
}
