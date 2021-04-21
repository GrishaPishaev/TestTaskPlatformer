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
            others.GetComponent<PlayerController>().Health -= 1;
            others.GetComponent<PlayerController>().HealthBar.SetHealth(others.GetComponent<PlayerController>().Health, others.GetComponent<PlayerController>().MaxHealth);
        }
    }
}
