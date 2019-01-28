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

    float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > 0)
            spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0)
        {
            SpawnLight();
            spawnTimer = spawnFrequency;
        }
    }

    void SpawnLight()
    {
        float x = Random.Range(-spawnRange, spawnRange);
        float z = Random.Range(-spawnRange, spawnRange);
        
        GameObject newLight = Instantiate(lightPrefab, spawnPoint.position, Quaternion.identity);

        newLight.GetComponent<Rigidbody>().AddForce(x * spawnForce, spawnHeight * spawnForce, z * spawnForce);
    }
}
