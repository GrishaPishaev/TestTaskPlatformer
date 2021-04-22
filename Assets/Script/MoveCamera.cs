using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject Player;

    void Update()
    {
        transform.position = new Vector3 { x = Player.transform.position.x, y = Player.transform.position.y, z = -10 };
    }
}
