using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public GameObject respawn;

    void OnTriggerEnter2D(Collider2D others)
    {
        if (others.tag == "Player")
        {
            others.transform.position = respawn.transform.position;
        }
    }
}
