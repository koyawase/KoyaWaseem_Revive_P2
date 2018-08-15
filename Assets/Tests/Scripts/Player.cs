using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Object references
    public Transform cameraPivot;
    float heading = 0;
    public Transform camera;
    CharacterController mover;

    //INPUT
    public float moveSpeed;
    Vector2 input;
    public float accel;
    public float turnSpeed = 5;

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
        heading += Input.GetAxis("Mouse X") * Time.deltaTime * 180;
        cameraPivot.rotation = Quaternion.Euler(0, heading, 0);

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

        if (input.magnitude > 0)
        {
            Quaternion rot = Quaternion.LookRotation(intent);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }

        velocity = Vector3.Lerp(velocity, transform.forward * input.magnitude * moveSpeed, accel * Time.deltaTime);

        mover.Move(velocity * Time.deltaTime);
    }
}
