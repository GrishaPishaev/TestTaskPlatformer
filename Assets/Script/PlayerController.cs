using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float Speed;
    public float NormalSpeed;
    public float JumpForce;
    private float moveInput;

    private bool FacingRight = true;
    public float CheckRadius;
    public LayerMask Ground;
    public bool OnGround;

    public Transform GroundCheck;
    private Rigidbody2D PlayerRigitbody;
    private Animator PlayerAnimator;

    private void Start()
    {
        Speed = 0f;
        PlayerAnimator = GetComponent<Animator>();
        PlayerRigitbody = GetComponent<Rigidbody2D>();
    }

    void CheckingGround()
    {
        OnGround = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, Ground);
    }


    public void RightMove()
    {
        if (Speed <= 0f) 
        {
            Speed = NormalSpeed;
            transform.eulerAngles = new Vector3
            {
                x = transform.localScale.x,
                y = 0,
                z = transform.localScale.z
            };
        }


    }
    public void LeftMove()
    {
        if (Speed >= 0f) 
        {
            Speed = -NormalSpeed;
            transform.eulerAngles = new Vector3
            {
                x = transform.localScale.x,
                y = 180,
                z = transform.localScale.z
            };
        }
 

    }
    public void OnButtonUp() 
    {
        Speed = 0f;
        FacingRight = !FacingRight;
        PlayerAnimator.SetBool("IsRunning", false);
    }

    private void Run()
    {
        PlayerRigitbody.velocity = new Vector2(Speed, PlayerRigitbody.velocity.y);
        if (OnGround)
        {
            if (Speed != 0f) PlayerAnimator.SetBool("IsRunning", true);
        }
        else
        {
            PlayerAnimator.SetBool("IsRunning", false);
            PlayerAnimator.SetTrigger("IsStartJump");
        }
    }
    public void Jump()
    {
        if (OnGround)
        {
            PlayerRigitbody.velocity = (Vector3.up * JumpForce);
            PlayerAnimator.SetTrigger("IsStartJump");
        }
    }
    private void Flip()
    {
        FacingRight = !FacingRight;
        transform.localScale = new Vector3
        {
            x = transform.localScale.x * -1,
            y = transform.localScale.y,
            z = transform.localScale.z
        };
    }
    private void Update()
    {
        CheckingGround();

        Run();
        if (OnGround)
        {
            PlayerAnimator.SetBool("IsJumping", false);

        }
        else
        {
            PlayerAnimator.SetBool("IsJumping", true);
        }
    }

}
