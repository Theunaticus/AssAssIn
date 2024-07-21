using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCheck : IShape
{
    [SerializeField] float AttackRadius;
    [SerializeField] Vector2 Offset;
    [SerializeField] LayerMask HitMask;
    Vector2 HitPoint => transform.Position() + transform.Facing() * Offset;

    public override bool Check()
    {
        return Physics2D.OverlapCircle(HitPoint, AttackRadius, HitMask) != null;
    }

    public override Collider2D[] GetCols()
    {
        return Physics2D.OverlapCircleAll(HitPoint, AttackRadius, HitMask);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(HitPoint, AttackRadius);
    }
}
