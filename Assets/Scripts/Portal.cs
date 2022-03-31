using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && 
            player.transform.localPosition.x >= 14.4925f && 
            player.transform.localPosition.x <= 15.4772f)
        {
            if (player.transform.localPosition.y <= 0.75f)
            {
                player.transform.localPosition += 
                    new Vector3(0f, 5.5f, 0f);
            } 
            else if (player.transform.localPosition.y >= 6.75f)
            {
                player.transform.localPosition -= 
                    new Vector3(0f, 5.5f, 0f);
            }
        }
    }
}
