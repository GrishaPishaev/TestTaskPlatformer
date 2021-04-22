using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float Speed;
    public float NormalSpeed;
    public float JumpForce;

    public int MaxHealth;
    public int Health;
    public HealthBarBehaviorForPlayer HealthBar;
    public EndGameUIController EndGameMenuUI;

    public float CheckRadius;
    public LayerMask Ground;
    public bool OnGround;

    public Transform GroundCheck;
    private Rigidbody2D PlayerRigitbody;
    private Animator PlayerAnimator;

    private float TimeBtwAttack;
    public float startTimeBtwAttack;

    public Transform AttackPos;
    public LayerMask Enemy;
    public float AttackRange;
    public int Damage;

    void OnTriggerEnter2D(Collider2D others)
    {
        if (others.tag == "Finish")
        {
            EndGameMenuUI.ShowEndgGameMenu("Ого! Вы нашли трудовой договор. Это победа!");
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;
        Speed = 0f;
        PlayerAnimator = GetComponent<Animator>();
        PlayerRigitbody = GetComponent<Rigidbody2D>();
        HealthBar.SetHealth(Health, MaxHealth);
    }

    void CheckingGround()
    {
        OnGround = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, Ground);
    }

    public void TakeDamage(int damage)
    {
        if (Speed <= 0f)
        {
            Speed = NormalSpeed;
        }
        else if (Speed >= 0f)
        {
            Speed = -NormalSpeed;
        }
        PlayerRigitbody.velocity = new Vector2(Speed, PlayerRigitbody.velocity.y);
        Jump();
        Health -= damage;
        HealthBar.SetHealth(Health, MaxHealth);
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
            PlayerAnimator.SetBool("IsJumping", true);
        }
    }
    public void Jump()
    {
        if (OnGround)
        {
            PlayerRigitbody.velocity = (Vector3.up * JumpForce);
            PlayerAnimator.SetBool("IsJumping", true);
        }
    }
    public void OnAttack()
    {
        if (TimeBtwAttack<=0)
        {
            PlayerAnimator.SetBool("IsAttacking", true);
            PlayerAnimator.SetTrigger("Attacking");
            PlayerAnimator.SetBool("IsJumping", false);

            PlayerAnimator.SetBool("IsRunning", false);
            Collider2D[] enemies = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, Enemy);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyController>().TakeDamage(Damage);
            }
            TimeBtwAttack = startTimeBtwAttack;
        } 
    }

    private void Death()
    {
        if (Health<=0)
        {
            EndGameMenuUI.ShowEndgGameMenu("Вы погибли!");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange);
    }

    private void Update()
    {
        CheckingGround();

        Run();

        Death();

        if (TimeBtwAttack >= 0)
        {
            TimeBtwAttack -= Time.deltaTime;
            PlayerAnimator.SetBool("IsAttacking", false);
            return;
        }

        if (OnGround)
        {
            PlayerAnimator.SetBool("IsJumping", false);
        }
        else
        {
            if (PlayerAnimator.GetBool("IsAttacking") == false)
            {
                PlayerAnimator.SetBool("IsJumping", true);
            }
        }
    }

}
