using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JampPad : MonoBehaviour {

    PlayerController player;
    public float power;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.moveDirection.y = 0;
            player.moveDirection = player.moveDirection + (transform.up * power);
        }
        
    }
}
