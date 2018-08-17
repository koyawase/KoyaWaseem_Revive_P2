using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{

    PlayerControl player;
    public float power;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            player.velocity.y = 0;
            //player.velocity.y += power;
            player.velocity = player.velocity + (transform.up * power);
        }

    }
}
