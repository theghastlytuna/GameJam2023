using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PolarBear : MonoBehaviour
{
    [SerializeField] float forceMultiplier;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            GameObject player = collision.gameObject;
            float forceAmount = (0.5f * collision.rigidbody.mass * Mathf.Pow(collision.relativeVelocity.magnitude, 2)) * forceMultiplier;
            player.GetComponent<Rigidbody2D>().AddForce((player.transform.position - transform.position).normalized * forceAmount);
        }
    }
}
