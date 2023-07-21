using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 10f;

    [SerializeField] float jumpForce = 20f;

    float gravity = 10f;

    private Vector3 direction;


    int jumps;



    bool isGrounded; //переменная, которая будет указывать на земле мы или нет

    [SerializeField] float jumpSpeed; //высота прыжка

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 30f;
        }
         if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 10f;
        }


        if(isGrounded || jumps<2)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                jumps+=2;
            }
        }




        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        if (controller.isGrounded)
        {
            direction = new Vector3(moveHorizontal, 0, moveVertical);
            direction = transform.TransformDirection(direction) * speed;

            if(Input.GetKey(KeyCode.Space))
            {
                direction.y = jumpForce;
            }
        }





        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);
    }


}
