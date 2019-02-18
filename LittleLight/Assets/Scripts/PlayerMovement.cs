using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;

    float speed;

    PointerScript pointerInfo;

    // Start is called before the first frame update
    void Start()
    {
        pointerInfo = FindObjectOfType<PointerScript>();
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift)) //Will probably need to change this to regular input
            speed = sprintSpeed;

        if (Input.GetKeyUp(KeyCode.LeftShift))
            speed = walkSpeed;

        Move(moveHor, moveVer);
        Turn();
    }

    void Turn()
    {
        Vector3 playerToMouse = pointerInfo.GetPositionOfMouse();

        playerToMouse.y = transform.position.y;

        transform.LookAt(playerToMouse);
    }

    void Move(float horizontal, float vertical)
    {
        Vector3 moveDir = new Vector3(horizontal, 0, vertical) * speed;
        transform.Translate(Vector3.ClampMagnitude(moveDir, speed) * Time.deltaTime, Space.World);

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
