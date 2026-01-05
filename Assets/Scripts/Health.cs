using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Action onKill;

    public int maxHealth = 10;

    private int currentHealth;
    private bool isDead;

    public bool destroyOnKill = false;
    public float delayToKill;

    public FlashColor flashColor;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        currentHealth = maxHealth;
        isDead = false;
    }

    public void Damage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        flashColor.Flash();

        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        isDead = true;

        if (destroyOnKill == true)
        {
            Destroy(this.gameObject, delayToKill);
        }

        onKill?.Invoke();
    }
}
