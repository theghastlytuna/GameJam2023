using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shinji : MonoBehaviour
{
    Image[] ShinjiLimbs = new Image[4];

    void Start()
    {
        for (int i = 0; i < ShinjiLimbs.Length; i++)
        {
            ShinjiLimbs[i] = transform.GetChild(i).GetComponent<Image>();
        }
    }

    public void SetLimb(int Limb, bool state)
    {
        Debug.Log("Gaming");
        ShinjiLimbs[Limb].enabled = !state;
    }
}
