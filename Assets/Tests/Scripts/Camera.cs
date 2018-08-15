﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Transform player;
    float heading = 0;
    float tilt = 15;
    float cameraDistance = 10;
    float playerHeight = 1;

    void Update () {
        heading += Input.GetAxis("Mouse X") * Time.deltaTime * 180;
        transform.rotation = Quaternion.Euler(tilt, heading, 0);

        transform.position = player.position - transform.forward * cameraDistance + Vector3.up*playerHeight;
    }
}
