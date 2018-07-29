using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    public Vector3 offset;

    public bool useOffsetValues;

    public float rotateSpeed;

    public Transform pivot;

    public float maxViewAngle;

    public float minViewAngle;

	// Use this for initialization
	void Start () {
        if (!useOffsetValues)
        {
            this.offset = target.position - transform.position;
        }

        //move pivot to where player is then make pivot a child of player when started.
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        //get X position of mouse & rotate the target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        //get Y position of mouse & rotate the pivot
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.Rotate(-vertical, 0, 0);

        //Limit up/down camera rotation
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 360 + minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
        }

        //move camera base on current rotation of target and original offset
        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle,0);
        transform.position = target.position - (rotation * offset);

        //transform.position = target.position - offset;
        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x,target.position.y - .5f,transform.position.z);
        }

        transform.LookAt(target);
	}
}
