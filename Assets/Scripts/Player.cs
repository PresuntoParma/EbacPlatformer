using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditorInternal;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    private float currentSpeed;
    public Animator anim;
    public Health health;

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;

    private void Awake()
    {
        if (health != null)
        {
            health.onKill += OnPlayerKill;
        }
    }
    private void OnPlayerKill()
    {
        health.onKill -= OnPlayerKill;

        anim.SetTrigger(soPlayerSetup.triggerDeath);
    }

    void Update()
    {
        Jump();
        Walk();
    }

    private void Walk()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = soPlayerSetup.speedRun;
        }
        else
        {
            currentSpeed = soPlayerSetup.speed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
            anim.SetBool("pRun", true);
            //rb.transform.localScale = new Vector2(1, 1);
            if (rb.transform.localScale.x != 1)
            {
                rb.transform.DOScaleX(1, 0.1f);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-currentSpeed, rb.velocity.y);
            anim.SetBool("pRun", true);
            //rb.transform.localScale = new Vector2(-1, 1);
            if (rb.transform.localScale.x != -1)
            {
                rb.transform.DOScaleX(-1, 0.1f);
            }
        }
        else
        {
            anim.SetBool("pRun", false);
        }

        if (rb.velocity.x > 0)
        {
            rb.velocity -= soPlayerSetup.friction;
        }
        else if (rb.velocity.x < 0)
        {
            rb.velocity += soPlayerSetup.friction;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * soPlayerSetup.jumpForce;
            rb.transform.localScale = Vector2.one;
            DOTween.Kill(rb.transform);
            ScaleJump();
        }
    }

    private void ScaleJump()
    {
        rb.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        rb.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
