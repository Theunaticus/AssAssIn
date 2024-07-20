using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] MeleeAttack MyMelee;

    private void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            MyMelee.Attack();
        }
    }
}
