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

        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        CheckJump();

        CheckScale();

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

    void CheckJump()
    {
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocityY = jumpHeight;
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

    //Changes the scale based off input
    //Player may only be able to access certain areas or do certain things when a certain scale
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

    //Player can change colour.
    //Can access certain areas of not be attacked by certain enemies when certain colour
    void CheckColour()
    {

    }

    //Player is able to attack the enemy
    void Attack()
    {

    }

    //Player is able to double jump
    void DoubleJump()
    {

    }

    //Player is able to wall jump
    void WallJump()
    {

    }

    //Player has health and lives. Loses life when dies
    //And loses health when attacked or in fog/smoke etc.
    void CalculateHealth()
    {

    }
}