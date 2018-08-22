using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    //Movement
    Vector2 input;
    Vector2 inputDir;
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
    bool movingHorizontal = false;
    bool movingVertical = false;

    //Scale
    Vector3 startingScale;
    bool isStartingScale = true;

    void Start()
    {
        camera = Camera.main.transform;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        startingScale = transform.localScale;
    }


    void Update()
    {
        CheckAnimation();

        CheckInputs();

        CheckJump();

        CheckScale();

        CheckRotation();

        CheckSprint();

        ApplyGravity();

        controller.Move(velocity * Time.deltaTime);

        ResetGravity();
    }

    void ResetGravity()
    {
        if (controller.isGrounded)
        {
            velocityY = 0;
        }
    }

    void ApplyGravity()
    {
        velocityY += Time.deltaTime * -gravity;
    }

    void CheckSprint()
    {
        bool running = Input.GetKey(KeyCode.LeftShift);
        float speed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        velocity = transform.forward * speed + Vector3.up * velocityY;
    }

    void CheckInputs()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputDir = input.normalized;
    }

    void CheckJump()
    {
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocityY = jumpHeight;
        }
    }

    void CheckScale()
    {
        if (Input.GetKeyDown("c"))
        {
            if (isStartingScale)
            {
                transform.localScale = new Vector3(5f, 5f, 5f);
                isStartingScale = false;
            }
            else if (!isStartingScale)
            {
                transform.localScale = startingScale;
                isStartingScale = true;
            }
        }
    }

    void CheckRotation()
    {
        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + camera.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);

        }
    }

    //This method makes sense logically but is broken in game.
    void CheckAnimation()
    {
        //Checking inputs to determine animations
        if (Input.GetButtonDown("Horizontal"))
        {
            movingHorizontal = true;
        }
        if (Input.GetButtonDown("Vertical"))
        {
            movingVertical = true;
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            movingHorizontal = false;
        }
        if (Input.GetButtonUp("Vertical"))
        {
            movingVertical = false;
        }
    
        //Setting the animation based on the input
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            anim.SetTrigger("jump");
        }
        if (movingHorizontal == true || movingVertical == true)
        {
            anim.SetTrigger("run");
        }
        else if (movingHorizontal == false && movingVertical == false)
       {
            anim.SetTrigger("idle");
        }
    
    }

}
