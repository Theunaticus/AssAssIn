using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] float AttackRadius;
    [SerializeField] Vector2 Offset;
    [SerializeField] LayerMask HitMask;
    [SerializeField] int Damage;
    [SerializeField] float AttackSpeed;
    float NextAttack;
    Vector2 HitPoint => transform.Position() + transform.Facing() * Offset;

    public  void    Attack ()
    {
        if (Time.time>NextAttack)
        {
            NextAttack = Time.time + AttackSpeed;
            Collider2D[] Cols = GetCols();
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

    Collider2D[]    GetCols ()
    {
        return Physics2D.OverlapCircleAll(HitPoint, AttackRadius,HitMask);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(HitPoint,AttackRadius);
    }
}
