﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Object references
    public Transform camera;
    CharacterController mover;

    //INPUT
    public float moveSpeed;
    Vector2 input;
    float accel = 11;
    public float turnSpeed = 5;
    public float turnSpeedLow = 7;
    public float turnSpeedHigh = 20;

    //CAMERA
    Vector3 camF;
    Vector3 camR;

    //PHYSICS
    Vector3 intent;
    Vector3 velocityXZ;
    Vector3 velocity;

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
        DoGravity();
        DoJump();

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
                velocity.y = moveSpeed;
            }
        }
    }
}
