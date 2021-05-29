using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GUICanvas : ACanvas
{
    [SerializeField] private List<GameObject> components = new List<GameObject>();

    protected override void Start()
    {
        HideCanvas();
        DisableComponents();
        SetUpState.OnEnterSetUpEvent += ShowCanvas;
        SetUpState.OnEnterSetUpEvent += EnableComponents;
        MainMenuState.OnEnterMainMenuEvent += HideCanvas;
        MainMenuState.OnEnterMainMenuEvent+= DisableComponents;
    }

    private void EnableComponents()
    {
        foreach (GameObject component in components)
        {
            component.SetActive(true);
        }
    }

    private void DisableComponents()
    {
        foreach (GameObject component in components)
        {
            component.SetActive(false);
        }
    }
}