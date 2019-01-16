using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    int floorMask;
    float camRayLength = 100f;
    Camera cam;

    // Start is called before the first frame update
    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        Move(moveHor, moveVer);
        Turn();
    }

    void Turn()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if(Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0;
            playerToMouse.z -= 1;

            Quaternion newRot = Quaternion.LookRotation(playerToMouse); //Makes playerToMouse the forward direction of the player.
            transform.rotation = newRot;
        }
    }

    void Move(float horizontal, float vertical)
    {
        transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime * horizontal, Space.World);
        transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime * vertical, Space.World);

        /*
        if (horizontal > 0)
            MoveUp();

        if (horizontal < 0)
            MoveDown();

        if (vertical > 0)
            MoveLeft();

        if (vertical < 0)
            MoveRight();*/
    }

    void MoveUp()
    {
        transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime, Space.World);
    }

    void MoveDown()
    {
        transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime, Space.World);
    }

    void MoveLeft()
    {
        transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime, Space.World);
    }

    void MoveRight()
    {
        transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime, Space.World);
    }
}
