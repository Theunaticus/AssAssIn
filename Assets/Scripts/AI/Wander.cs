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
    bool Falling;
    Vector2 Dir;

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
            if (Falling)
            {
                Falling = false;
            }
            MyRigid.velocity = Dir * Speed;
        }
        else if (!Falling)
        {
            MyRigid.velocity = Vector2.up * MyRigid.velocity.y;
            Falling = true;
        }
    }

    void    Flip ()
    {
        Debug.Log("Flipping");
        Dir.x *= -1;
        transform.localScale = Vector3.up  + Vector3.right * Dir.x + Vector3.forward;
    }
}
