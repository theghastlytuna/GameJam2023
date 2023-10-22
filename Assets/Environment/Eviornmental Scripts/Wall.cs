using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private bool Broken = false;
    [SerializeField] private string objectCollided;
    [SerializeField] private GameObject self;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Broken = true;
        if (Broken)
        {
            if (collision.gameObject.tag == "Limb")
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
    }

    public void DropWall()
    {
        self.GetComponent<Collider2D>().enabled = false;
        self.GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("WallDropped");
    }
}
