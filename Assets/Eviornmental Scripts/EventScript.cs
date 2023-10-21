using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EventScript : MonoBehaviour
{
    //public static event Action Event;
    [SerializeField] UnityEvent Triggered;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        { 
            //throw this in OnTriggerEnter2Ds
            //UnityEvent?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Triggered.Invoke();
    }
}
