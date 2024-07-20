using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] int CurrentHealth;
    public UnityEvent OnDeath;

    public  void    Damage (int Amount)
    {
        CurrentHealth -= Amount;
        if (CurrentHealth<=0)
        {
            Die();
        }
    }

    public  void    Die ()
    {
        OnDeath?.Invoke();
    }
}
