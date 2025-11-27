using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtons : MonoBehaviour
{
    public List<GameObject> buttons;

    public float delay;
    public float duration;

    private void Awake()
    {
        HideButtons();
        ShowButtons();
    }

    private void HideButtons()
    {
        foreach (var b in buttons)
        {
            b.transform.localScale = Vector2.zero;
            b.SetActive(false);
        }
    }

    private void ShowButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            var b = buttons[i];
            b.SetActive(true);
            b.transform.DOScale(1, duration).SetDelay(i*delay).SetEase(Ease.OutBack);
        }
    }
}
