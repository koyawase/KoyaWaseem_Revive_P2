using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    //Movement
    Vector2 input;
    public float walkSpeed = 7;
    public float runSpeed = 14;
    public float gravity = 15f;
    public float jumpSpeed = 8.0F;
    public float jumpHeight = 10;
    public Vector3 velocity;
    public float velocityY;

    //Rotation
    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    //Controllers
    Transform camera;
    CharacterController controller;

    //Animator
    Animator anim;
    bool jump = false;
    bool running = false;

    void Start()
    {
        camera = Camera.main.transform;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        CheckAnimation();

        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        //Rotating the character
        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + camera.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);

        }

        bool running = Input.GetKey(KeyCode.LeftShift);
        float speed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;

        velocityY += Time.deltaTime * -gravity;

        velocity = transform.forward * speed + Vector3.up * velocityY;
        controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded)
        {
            velocityY = 0;
        }
    }

    void Jump()
    {
        if (controller.isGrounded)
        {
            velocityY = jumpHeight;
        }
    }

    void CheckAnimation(){
        if(Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")){
            anim.SetTrigger("run");
            running = true;
            jump = false;
        }
        if(Input.GetButtonDown("Jump")){
            anim.SetTrigger("jump");
            jump = true;
        }
        else if(Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical")){
            anim.SetTrigger("idle");
            running = false;
            jump = false;
        }
        if(jump == true && running == false ){
            anim.SetTrigger("idle");
            jump = false;
            running = false;
        }
        else if(jump == true && running == true){
            anim.SetTrigger("run");
            jump = false;
        }
;
        }


}
