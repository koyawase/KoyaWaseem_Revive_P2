using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    public Vector3 offset;

    public bool useOffsetValues;

    public float rotateSpeed;

	// Use this for initialization
	void Start () {
        if (!useOffsetValues) {
            this.offset = target.position - transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {

        //get X position of mouse & rotate the target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        //get Y position of mouse & rotate the target
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        target.Rotate(-vertical, 0, 0);

        //move camera base on current rotation of target and original offset
        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = target.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle,0);
        transform.position = target.position - (rotation * offset);

        //transform.position = target.position - offset;
        transform.LookAt(target);
	}
}
