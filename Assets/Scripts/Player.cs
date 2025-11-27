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
    private float jumpScaleY = 1.5f;
    private float jumpScaleX = 0.7f;
    public Ease ease = Ease.OutBack;

    void Update()
    {
        Jump();
        Walk();
    }

    private void Walk()
    {
        if (Input.GetKey(KeyCode.LeftControl))
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
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-currentSpeed, rb.velocity.y);
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
        rb.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rb.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
