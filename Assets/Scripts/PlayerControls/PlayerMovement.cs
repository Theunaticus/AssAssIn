using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D Rigid;
    bool FacingRight;
    bool IsJumping;
    float GravityScale { get => Rigid.gravityScale; set => Rigid.gravityScale = value; }
	[SerializeField] float MoveSpeed;
    [SerializeField] Vector2 GroundCheckOffset;
    [SerializeField] Vector2 GroundCheckSize;
    [SerializeField] LayerMask GroundCheckMask;
    float CoyoteTime;
    float LastTimeOnGround;
	float OnGroundAccellSpeed;
	float AirControlAccellSpeed;
    Vector2 GroundCheckPoint => transform.Position() + GroundCheckOffset;
	Vector2 InputVel;


    private void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        InputVel.x = Input.GetAxisRaw("Horizontal");

        LastTimeOnGround -= Time.deltaTime;

        if (!IsJumping)
        {
            if (Physics2D.OverlapBox(GroundCheckPoint, GroundCheckSize, 0, GroundCheckMask))
            {
                LastTimeOnGround = CoyoteTime;
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(GroundCheckPoint, GroundCheckSize);
    }

	private void Move()
	{
		float targetSpeed = InputVel.x * MoveSpeed;
		Rigid.AddForce(targetSpeed * Vector2.right, ForceMode2D.Force);
	}

	private void Turn()
    {
        transform.localScale = Vector3.one + Vector3.right * (transform.localScale.x * -1);
        FacingRight = !FacingRight;
    }
}
