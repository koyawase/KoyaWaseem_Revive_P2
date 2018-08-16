using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Transform player;
    float heading = 0;
    float tilt = 15;
    float cameraDistance = 10;
    float playerHeight = 1;

    void LateUpdate () {
        heading += Input.GetAxis("Mouse X") * Time.deltaTime * 200;

        //Vertical camera.
        tilt -= Input.GetAxis("Mouse Y") * Time.deltaTime * 200;
        //Max at 80 degrees
        tilt = Mathf.Clamp(tilt, -50f, 50f);

        transform.rotation = Quaternion.Euler(tilt, heading, 0);

        transform.position = player.position - transform.forward * cameraDistance + Vector3.up*playerHeight;
    }
}
