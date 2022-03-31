using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject[] portals;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            foreach (GameObject portal in portals)
            {
                portal.gameObject.SetActive(true);
            }
        }
    }
}
