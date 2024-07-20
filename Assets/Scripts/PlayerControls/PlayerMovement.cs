using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D Rigid;
    bool FacingRight;
    bool IsJumping;
    bool IsJumpFalling;
    float GravityScale { get => Rigid.gravityScale; set => Rigid.gravityScale = value; }
	[SerializeField] float MoveSpeed;
    [SerializeField] Vector2 GroundCheckOffset;
    [SerializeField] Vector2 GroundCheckSize;
    [SerializeField] LayerMask GroundCheckMask;
    float CoyoteTime    =   0.1f;
    float LastTimeOnGround;
	float OnGroundAccellSpeed   =2.5f;
	float OnGroundDecellSpeed   =   5;
	float AirControlAccellSpeed =   0.65f;
	float AirControlDecellSpeed =   0.65f;
	float JumpHangTimeThreshold =   1;
	float JumpHangAccelerationMult  =   1.1f;
	float JumpHangMaxSpeedMult  =   1.3f;

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

		float accelRate;
		if (LastTimeOnGround > 0)
			accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? OnGroundAccellSpeed : OnGroundDecellSpeed;
		else
			accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? OnGroundAccellSpeed * AirControlAccellSpeed : OnGroundDecellSpeed * AirControlDecellSpeed;

		if ((IsJumping || IsJumpFalling) && Mathf.Abs(Rigid.velocity.y) < JumpHangTimeThreshold)
		{
			accelRate *= JumpHangAccelerationMult;
			targetSpeed *= JumpHangMaxSpeedMult;
		}

		if (Mathf.Abs(Rigid.velocity.x) > Mathf.Abs(targetSpeed) && Mathf.Sign(Rigid.velocity.x) == Mathf.Sign(targetSpeed) && Mathf.Abs(targetSpeed) > 0.01f && LastTimeOnGround < 0)
		{
			accelRate = 0;
		}

		float speedDif = targetSpeed - Rigid.velocity.x;

		float movement = speedDif * accelRate;

		Rigid.AddForce(movement * Vector2.right, ForceMode2D.Force);
	}

	private void Turn()
    {
        transform.localScale = Vector3.one + Vector3.right * (transform.localScale.x * -1);
        FacingRight = !FacingRight;
    }
}
