using System;
using UnityEngine;
/*
 * Super class for all canvases
 */
public abstract class ACanvas : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    protected abstract void Start();

    protected void HideCanvas()
    {
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
    }

    protected void ShowCanvas()
    {
        canvasGroup.interactable = true;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    
    protected void PauseTime()
    {
        Time.timeScale = 0f;
    }
    
    protected void ResumeTime()
    {
        Time.timeScale = 1f;
    }
}