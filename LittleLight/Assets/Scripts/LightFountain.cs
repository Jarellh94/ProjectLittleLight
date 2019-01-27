using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFountain : MonoBehaviour
{
    public GameObject lightPrefab;
    public int spawnRange;
    public float spawnFrequency;

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

        Instantiate(lightPrefab, new Vector3(transform.position.x + x, 1, transform.position.z + z), Quaternion.identity);
    }
}
