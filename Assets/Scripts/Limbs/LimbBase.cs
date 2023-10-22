using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class LimbBase : MonoBehaviour
{
    [SerializeField] bool Debug_Printing = false;

    public LimbSlot limbType;
    [SerializeField] bool Grabbable = true;
    [SerializeField] bool AttachedToBody;

    CircleCollider2D chupaShapedCollider;
    Rigidbody2D _rb;

    PlayerScript _player;

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
        if (Debug_Printing)
        {
            EditorApplication.isPaused = true;
            Debug.Log(forceDir);
        }

        transform.parent = null;
        AttachedToBody = false;
        _rb.angularVelocity = 0f;
        _rb.AddForce(forceDir);
        _rb.freezeRotation = false;
        _rb.AddTorque(10f);
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
        //_rb.freezeRotation = true;
        _player = player;
    }

    private void Update()
    {
        if (AttachedToBody)
        {
            //transform.localPosition = Vector3.zero;
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
    }
}
