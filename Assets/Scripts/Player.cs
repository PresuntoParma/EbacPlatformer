using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditorInternal;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    public Vector2 friction = new Vector2(0.1f, 0f);

    public float speed;
    public float speedRun;
    public float jumpForce;

    private float currentSpeed;

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
        }
    }
}
