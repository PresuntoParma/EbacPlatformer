using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditorInternal;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;


    [Header("Movement")]
    public Vector2 friction = new Vector2(0.1f, 0f);

    public float speed;
    public float speedRun;
    public float jumpForce;

    private float currentSpeed;

    [Header("Animation")]
    public float animationDuration = 0.3f;
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public SOFloat soJumpScaleY;
    public SOFloat soJumpScaleX;
    public SOFloat soAnimationDuration;
    public Ease ease = Ease.OutBack;

    [Header("Animator")]
    public string boolRun = "pRun";
    public string triggerDeath;
    public Animator anim;

    public Health health;

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

        anim.SetTrigger(triggerDeath);
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
            currentSpeed = speedRun;
        }
        else
        {
            currentSpeed = speed;
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
            rb.velocity -= friction;
        }
        else if (rb.velocity.x < 0)
        {
            rb.velocity += friction;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            rb.transform.localScale = Vector2.one;
            DOTween.Kill(rb.transform);
            ScaleJump();
        }
    }

    private void ScaleJump()
    {
        rb.transform.DOScaleY(soJumpScaleY.value, soAnimationDuration.value).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rb.transform.DOScaleX(soJumpScaleX.value, soAnimationDuration.value).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
