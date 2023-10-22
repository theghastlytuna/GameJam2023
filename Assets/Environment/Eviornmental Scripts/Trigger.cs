using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] Wall wall;
    [SerializeField] string LimbType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == LimbType)
        {
            wall.DropWall();
        }

    }
}
