using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLaunchPad : MonoBehaviour {

    PlayerControl player;
    public float power;
    public Rigidbody rigidbody;
    private Vector3 startPosition;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
        startPosition = this.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.velocityY = 0;
            player.velocityY += power;
            rigidbody.useGravity = true;
        }

        if (other.gameObject.tag == "Water")
        {
            Debug.Log("Hit");
            rigidbody.useGravity = false;
            
        }
    }
}
