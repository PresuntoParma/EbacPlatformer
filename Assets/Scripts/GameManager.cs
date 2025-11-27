using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using System.Xml.Serialization;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Enemies")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform startPoint;

    [Header("Animations")]
    public float duration;
    public float delay;
    public Ease ease = Ease.OutBack;

    private GameObject currentPlayer;

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        currentPlayer = Instantiate(playerPrefab);
        currentPlayer.transform.position = startPoint.transform.position;
        currentPlayer.transform.DOScale(0, duration).SetEase(ease).From().SetDelay(delay);
    }
}
