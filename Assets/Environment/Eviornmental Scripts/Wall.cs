using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private bool Broken = false;
    [SerializeField] private string objectCollided;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

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
        gameObject.GetComponent<Collider2D>().enabled = false;
        Debug.Log("WallDropped");
    }
}
