using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LimbBase : MonoBehaviour
{
    public LimbSlot limbType;
    [SerializeField] bool Grabbable = true;
    [SerializeField] bool AttachedToBody;

    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Throw(Vector3 forceDir)
    {
        transform.parent = null;
        AttachedToBody = false;
        _rb.AddForce(forceDir);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Grabbable && collision.gameObject.GetComponent<PlayerScript>())
        {
            if (collision.gameObject.GetComponent<PlayerScript>().SlotsOpen(((int)limbType)))
            {
                AttachToBody(collision.gameObject.GetComponent<PlayerScript>());
            }
        }
    }

    void AttachToBody(PlayerScript player)
    {
        AttachedToBody = true;
        player.AttachLimb(this);
        Grabbable = false;
    }

    private void Update()
    {
        if (AttachedToBody)
        {
            transform.localPosition = Vector3.zero;
        }
    }
}
