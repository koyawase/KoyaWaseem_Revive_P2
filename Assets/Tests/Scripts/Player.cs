using System.Collections;
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
    Vector3 velocity;

    private void Start()
    {
        mover = GetComponent<CharacterController>();
    }

    void Update () {
        DoInput();
        CalculateCamera();
        DoMove();
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

        velocity = Vector3.Lerp(velocity, transform.forward * input.magnitude * moveSpeed, accel * Time.deltaTime);

        mover.Move(velocity * Time.deltaTime);
    }
}
