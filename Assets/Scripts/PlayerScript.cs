using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Player Parameter
    [SerializeField] float ThrowForce = 200;

    //External Information Variables
    Vector3 mousePos;
    Vector3 playerToMouse;

    [SerializeField] LimbBase[] Limbs = new LimbBase[4];
    Rigidbody2D _rb;

    [SerializeField] Shinji _shinji;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        for (int i = 0; i < Limbs.Length; i++)
        {
            Limbs[i] = transform.GetChild(i).transform.GetChild(0).GetComponent<LimbBase>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, GetLookAtAngle()));

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Left Arm");
                NewThrowLimb(0);
            }
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Right Arm");
                NewThrowLimb(1);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Left Leg");
                NewThrowLimb(2);
            }
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Right Leg");
                NewThrowLimb(3);
            }
        }
    }

    private float GetLookAtAngle()
    {
        mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);

        playerToMouse = mousePos - transform.position;

        float angle = Mathf.Atan2(playerToMouse.y, playerToMouse.x) * Mathf.Rad2Deg - 90;

        return angle;
    }


    void NewThrowLimb(int selectedLimb)
    {
        if (Limbs[selectedLimb] == null)
        {
            return;
        }
        Debug.Log("Throwing Limb: " + selectedLimb);
        Vector3 dir = transform.up;
        Vector3 Force = new Vector3(dir.x * ThrowForce, dir.y * ThrowForce, dir.z * ThrowForce);
        Limbs[selectedLimb].Throw(Force);
        Limbs[selectedLimb] = null;
        _shinji.SetLimb(selectedLimb, false);

        _rb.AddForce(-Force);
    }

    public void AttachLimb(LimbBase limb)
    {
        if(limb.limbType == LimbSlot.ARM)
        {
            if (Limbs[0] == null)
            {
                Limbs[0] = limb;
                limb.transform.SetParent(transform.GetChild(0));
                _shinji.SetLimb(0, true);
            }
            else
            {
                Limbs[1] = limb;
                limb.transform.SetParent(transform.GetChild(1));
                _shinji.SetLimb(1, true);
            }
        }
        else
        {
            if (Limbs[2] == null)
            {
                Limbs[2] = limb;
                limb.transform.SetParent(transform.GetChild(2));
                _shinji.SetLimb(2, true);
            }
            else
            {
                Limbs[3] = limb;
                limb.transform.SetParent(transform.GetChild(3));
                _shinji.SetLimb(3, true);
            }
        }
    }

    public bool SlotsOpen(int type)
    {
        if(type == 0)
        {
            if (Limbs[0] == null || Limbs[1] == null)
            {
                return true;
            }
            return false;
        }
        else if(type == 1)
        {
            if (Limbs[2] == null || Limbs[3] == null)
            {
                return true;
            }
            return false;
        }
        return false;
    }
}
