using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Wander : MonoBehaviour
{
    [SerializeField] IShape GroundCheck;
    [SerializeField] IShape EdgeCheck;
    [SerializeField] IShape WallCheck;
    Rigidbody2D MyRigid;
    [SerializeField] float Speed;
    [SerializeField] Vector2 PauseRange;
    [SerializeField] Vector2 WalkRange;
    float PauseLength => Random.Range(PauseRange.x,PauseRange.y);
    float WalkLength => Random.Range(WalkRange.x, WalkRange.y);
    Vector2 Dir;
    float NextWalk;
    float NextPause;
    bool Pausing;

    private void Start()
    {
        Dir.y = -9.8f;
        Dir = Vector2.right;
        MyRigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (GroundCheck.Check())
        {
            if (WallCheck.Check()   ||  !EdgeCheck.Check())
            {
                Flip();
            }
            if (Time.time>NextWalk && Time.time<NextPause)
            {
                Pausing = false;
                MyRigid.velocity = Dir * Speed;
            }else if (!Pausing)
            {
                MyRigid.velocity = Vector2.zero;
                Pausing = true;
                NextWalk = Time.time + PauseLength;
                NextPause = NextWalk + WalkLength;
            }
        }
    }

    void    Flip ()
    {
        Dir.x *= -1;
        transform.localScale = Vector3.up  + Vector3.right * Dir.x + Vector3.forward;
    }
}
