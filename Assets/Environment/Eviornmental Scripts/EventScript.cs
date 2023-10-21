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

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Triggered.Invoke();
    }
}
