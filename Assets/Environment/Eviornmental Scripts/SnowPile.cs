using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SnowPile : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] float slowdownPercentage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            collision.attachedRigidbody.velocity = collision.attachedRigidbody.velocity - (collision.attachedRigidbody.velocity * (slowdownPercentage / 100));
        }
    }
}
