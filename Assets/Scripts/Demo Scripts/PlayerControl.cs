using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    //Object references
    public Transform camera;
    public CharacterController mover;

    //INPUT
    public float moveSpeed;
    Vector2 input;
    float accel = 11;
    public float turnSpeed = 5;
    public float turnSpeedLow = 7;
    public float turnSpeedHigh = 20;
    public float jumpHeight;

    //CAMERA
    Vector3 camF;
    Vector3 camR;

    //PHYSICS
    Vector3 intent;
    Vector3 velocityXZ;
    public Vector3 velocity;

    //GRAVITY
    float gravity = 10f;
    bool grounded = false;

    private void Start()
    {
        mover = GetComponent<CharacterController>();
    }

    void Update () {
        DoInput();
        CalculateCamera();
        CalculateGround();
        DoMove();
        //DoGravity();
        //DoJump();

        mover.Move(velocity * Time.deltaTime);
        //Gravity and jump implementent after movement to allow for use of jump pad.
        //If gravity is applied before using jump pad, it will not work properly.
        DoGravity();
        DoJump();
        //need to be able to move after calculating jump and gravity.
        //NOTE: since move is being called twice is same method, player move 2x faster. Fix by halving movespeed variable. 
        mover.Move(velocity * Time.deltaTime);
    }

    void DoInput()
    {
        
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);
    }

    void CalculateCamera()
    {
        camF = camera.forward;
        camR = camera.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;
    }

    void CalculateGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 0.1f, -Vector3.up, out hit, 0.2f))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    void DoMove()
    {
        intent = (camF * input.y + camR * input.x);

        float ts = velocity.magnitude/5;
        turnSpeed = Mathf.Lerp(turnSpeedHigh, turnSpeedLow, ts);
        if (input.magnitude > 0)
        {
            Quaternion rot = Quaternion.LookRotation(intent);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }

        velocityXZ = velocity;
        velocityXZ.y = 0;
        velocityXZ = Vector3.Lerp(velocityXZ, transform.forward * input.magnitude * moveSpeed, accel * Time.deltaTime);
        velocity = new Vector3(velocityXZ.x, velocity.y, velocityXZ.z);

    }

    void DoGravity()
    {
        if (grounded)
        {
            velocity.y = -0.5f;
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime;
            velocity.y = Mathf.Clamp(velocity.y, -2 * moveSpeed, moveSpeed * 2);
        }
    }

    void DoJump()
    {
        if (grounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //this.transform.parent = null;
                velocity.y = jumpHeight;
            }
        }
    }
}
