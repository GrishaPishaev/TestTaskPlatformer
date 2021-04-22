using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int MaxHealth;
    public int CurrentHealth;
    public HealthBarBehaviorForEnemy HealthBar;
    private float TimeStop;
    public float startStop;

    public int Damage;
    public int ScoreOfEnemy;
    private Animator RockAnimator;
    private ScoreManager ScoreManager;

    private void Start()
    {
        RockAnimator = GetComponent<Animator>();
        ScoreManager = FindObjectOfType<ScoreManager>();
        HealthBar.SetHealth(CurrentHealth, MaxHealth);
    }
    public void TakeDamage(int damage)
    {
        RockAnimator.SetBool("IsTakeDamage", true);
        CurrentHealth -= damage;
        TimeStop = startStop;
    }

    public void OnTriggerEnter2D(Collider2D others)
    {
        if (others.tag == "Player")
        {
            others.GetComponent<PlayerController>().TakeDamage(Damage);
        }
    }

    void Update()
    {
        if (TimeStop >= 0) TimeStop -= Time.deltaTime;
        else RockAnimator.SetBool("IsTakeDamage", false);

        HealthBar.SetHealth(CurrentHealth, MaxHealth);
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
            ScoreManager.Kill(ScoreOfEnemy);
        }
    }      
}
