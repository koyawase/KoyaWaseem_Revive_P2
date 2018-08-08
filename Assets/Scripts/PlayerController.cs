﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public CharacterController controller;
    private float sprintSpeed;
    private float defaultSpeed;

    public Vector3 moveDirection;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        sprintSpeed = moveSpeed * 1.5f;
        defaultSpeed = moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        if (controller.isGrounded) {
            Jump();
            Sprint();
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
	}

    void Jump()
    {
        moveDirection.y = 0f;
        if (Input.GetButton("Jump"))
        {
            moveDirection.y = jumpForce;
        }
    }

    void Sprint()
    {
        if (Input.GetButton("LeftShift") && controller.isGrounded)
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = defaultSpeed;
        }
    }
}
