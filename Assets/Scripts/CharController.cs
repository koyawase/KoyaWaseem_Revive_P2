using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public CharacterController controller;

    private Vector3 moveDirection;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();	
	}
	
	// Update is called once per frame
	void Update () {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed,0f,Input.GetAxis("Vertical") * moveSpeed);

        if (Input.GetButton("Jump"))
        {
            moveDirection.y = jumpForce;
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
        controller.Move(moveDirection * Time.deltaTime);
	}
}
