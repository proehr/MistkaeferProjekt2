using System;
using UnityEngine;

public abstract class ACanvas : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    protected abstract void Start();

    protected void HideCanvas()
    {
        Time.timeScale = 1f;
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
    }

    protected void ShowCanvas()
    {
        Time.timeScale = 0f;
        canvasGroup.interactable = true;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}