using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskFollow : MonoBehaviour
{
    public Transform playerTransform;

    public float shrinkSpeed = .5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 9, playerTransform.position.z - 9);

        if (Input.GetKey(KeyCode.I))
        {
            Vector3 newScale = transform.localScale;
            newScale.x += shrinkSpeed * Time.deltaTime;
            newScale.y += shrinkSpeed * Time.deltaTime;

            transform.localScale = newScale;
        }

        if (Input.GetKey(KeyCode.K))
        {
            Vector3 newScale = transform.localScale;
            newScale.x -= shrinkSpeed * Time.deltaTime;
            newScale.y -= shrinkSpeed * Time.deltaTime;

            transform.localScale = newScale;
        }
    }
}
