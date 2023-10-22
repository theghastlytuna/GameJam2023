using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LimbBase : MonoBehaviour
{
    [SerializeField] bool Debug_Printing = false;

    public LimbSlot limbType;
    [SerializeField] bool Grabbable = true;
    [SerializeField] bool AttachedToBody;

    CircleCollider2D chupaShapedCollider;
    Rigidbody2D _rb;

    SpriteRenderer _GlowieRenderer;
    Rigidbody myCock; //Hard and Rigid af;
    SoftJointLimitSpring yourCock; //Small, unimpressive.
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        chupaShapedCollider = GetComponent<CircleCollider2D>();
        _GlowieRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public virtual void Throw(Vector3 forceDir)
    {
        transform.parent = null;
        AttachedToBody = false;
        _rb.AddForce(forceDir);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Debug_Printing)
        {
            Debug.Log("Collided");
        }
        if (Grabbable && collision.gameObject.GetComponent<PlayerScript>())
        {
            if (Debug_Printing)
            {
                Debug.Log("Grabbable and hit Player");
            }
            if (collision.gameObject.GetComponent<PlayerScript>().SlotsOpen(((int)limbType)))
            {
                if (Debug_Printing)
                {
                    Debug.Log("Player has available slots");
                }
                AttachToBody(collision.gameObject.GetComponent<PlayerScript>());
            }
        }
    }

    void AttachToBody(PlayerScript player)
    {
        AttachedToBody = true;
        player.AttachLimb(this);
        Grabbable = false;
        chupaShapedCollider.excludeLayers = LayerMask.GetMask("Player");
        _GlowieRenderer.enabled = false;
    }

    private void Update()
    {
        if (AttachedToBody)
        {
            transform.localPosition = Vector3.zero;
        }
    }
}
