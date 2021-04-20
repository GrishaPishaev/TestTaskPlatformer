using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private float moveInput;

    private MoveState CurrentMoveState = MoveState.Idle;
    private bool facingRight = true;

    private Rigidbody2D PlayerRigitbody;
    private Animator PlayerAnimator;

    private void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        PlayerRigitbody = GetComponent<Rigidbody2D>();
    }

    public void Run()
    {
        moveInput = Input.GetAxis("Horizontal");
        PlayerRigitbody.velocity = new Vector2(moveInput * Speed, PlayerRigitbody.velocity.y);

        if (!facingRight && moveInput > 0) Flip();
        else if (facingRight && moveInput < 0) Flip();

        if (moveInput == 0) PlayerAnimator.SetBool("IsRunning", false);
        else PlayerAnimator.SetBool("IsRunning", true);
    }
    public void Jump()
    {
        if (CurrentMoveState != MoveState.Jump )
        {
            PlayerRigitbody.velocity = (Vector3.up * JumpForce);
            CurrentMoveState = MoveState.Jump;
            PlayerAnimator.SetBool("IsJumping", true);
            PlayerAnimator.SetTrigger("IsStartJump");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            return;
        }
        if (CurrentMoveState == MoveState.Jump)
        {
           
            if (PlayerRigitbody.velocity == Vector2.zero)
            {
                PlayerAnimator.SetBool("IsJumping", false);
                CurrentMoveState = MoveState.Idle;
            }
        }
        else if (CurrentMoveState == MoveState.Run)
        {
            Run();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3
        {
            x = transform.localScale.x * -1,
            y = transform.localScale.y,
            z = transform.localScale.z
        };
    }
    enum MoveState
    {
        Idle,
        Run,
        Jump
    }
}
