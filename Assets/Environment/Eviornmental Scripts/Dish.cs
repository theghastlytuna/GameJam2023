using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    [SerializeField] Penguin[] penguins;
    [SerializeField] GameObject Fish;
    [SerializeField] Rigidbody2D rbFish;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Fish")
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
