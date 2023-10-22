using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    [SerializeField] Penguin[] penguins;
    [SerializeField] GameObject Fish;
    [SerializeField] Rigidbody2D rbFish;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //delete this and add the fish into the editor
        Fish = collision.gameObject;
        rbFish = collision.GetComponent<Rigidbody2D>();

        if (collision.gameObject.tag == "Limb")
        {
            rbFish.simulated = false;
            Fish.transform.position = gameObject.transform.position;

            foreach (Penguin penguin in penguins)
            {
                penguin.isLerping = true;
            }

        }
    }
}
