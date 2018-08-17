using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Transform target;
    public float distanceFromTarget = 10;
    public float mouseSensitivity = 5;

    float yaw;
    float pitch;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update () {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, 0, 80);


        Vector3 targetRotation = new Vector3(pitch, yaw);
        transform.eulerAngles = targetRotation;

        transform.position = target.position - transform.forward * distanceFromTarget;
	}
}
