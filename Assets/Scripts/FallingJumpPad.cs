using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingJumpPad : MonoBehaviour
{

    PlayerController player;
    private Rigidbody rigidbody;
    public float power;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

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
            rigidbody.useGravity = true;
        }

    }

    private void Update()
    {
        if(rigidbody.position.y < -50)
        {
            Destroy(gameObject);
        }
    }

}
