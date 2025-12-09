using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 10;

    public Animator anim;
    public string attackTrigger;

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
}
