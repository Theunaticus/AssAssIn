using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerController : MonoBehaviour
{
    public Collider2D LastCollider { get; set; }
    public UnityEvent OnTriggerEnterEvent;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerEnterEvent?.Invoke();
    }
}
