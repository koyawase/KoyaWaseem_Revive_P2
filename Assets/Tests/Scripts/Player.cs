using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform cameraPivot;
    float heading = 0;
    public Transform camera;

    public float moveSpeed;
    Vector2 input;

	void Update () {
        heading += Input.GetAxis("Mouse X") * Time.deltaTime * 180;
        cameraPivot.rotation = Quaternion.Euler(0, heading, 0);

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        Vector3 camF = camera.forward;
        Vector3 camR = camera.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;
        //transform.position += new Vector3(input.x, 0, input.y) * Time.deltaTime * moveSpeed;
        transform.position += (camF*input.y + camR*input.x) * Time.deltaTime * moveSpeed;
    }
}
