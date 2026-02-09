using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    [Header("Movement")]
    public Vector2 friction = new Vector2(0.1f, 0f);
    public float speed;
    public float speedRun;
    public float jumpForce;


    [Header("Animation")]
    public float animationDuration = 0.3f;
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public Ease ease = Ease.OutBack;

    [Header("Animator")]
    public string boolRun = "pRun";
    public string triggerDeath = "pDeath";
    public float playerSwipeDuration = 0.1f;
}
