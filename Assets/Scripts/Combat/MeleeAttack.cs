using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] IShape AttackShape;
    [SerializeField] int Damage;
    [SerializeField] float AttackSpeed;
    float NextAttack;


    public  void    Attack ()
    {
        if (Time.time>NextAttack)
        {
            NextAttack = Time.time + AttackSpeed;
            Collider2D[] Cols = AttackShape.GetCols();
            foreach (Collider2D col in Cols)
            {
                if (col!=this.gameObject)
                {
                    Health hitHealth = col.gameObject.GetComponent<Health>();
                    if (hitHealth != null)
                    {
                        hitHealth.Damage(Damage);
                        return;
                    }
                }
            }
        }
    }
}
