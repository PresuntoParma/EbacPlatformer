using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 10;

    public Animator anim;
    public string attackTrigger;
    public string killTrigger;

    public Health healthBase;

    public float timeToDestroy;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.onKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthBase.onKill -= OnEnemyKill;
        PlayeKillAnimation();
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<Health>();

        if (health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        anim.SetTrigger(attackTrigger);
    }

    private void PlayeKillAnimation()
    {
        anim.SetTrigger(killTrigger);
    }

    public void Damage(int ammount)
    {
        healthBase.Damage(ammount);
    }
}
