using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour
{
    int floorMask;
    float camRayLength = 100f;
    Camera cam;

    Vector3 mouseWorldPosition;

    // Start is called before the first frame update
    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ScreenToWorld();
    }

    void ScreenToWorld()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point;
            playerToMouse.y = 0;
            playerToMouse.z -= 1;

            mouseWorldPosition = playerToMouse;
        }

    }

    public Vector3 GetPositionOfMouse()
    {
        return mouseWorldPosition;
    }
}
