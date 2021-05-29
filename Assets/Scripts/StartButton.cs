using System;
using System.Collections;
using System.Collections.Generic;
using Maze;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class StartButton : MonoBehaviour
{
    [SerializeField] private MazeManager mazeManager;
    [SerializeField] private Camera mainCamera;

    public void EasyMaze()
    {
        mazeManager.setMazeSize(new Vector2Int(5, 5));
        mainCamera.transform.position = new Vector3(0f, 14.5f, 0f);
        StartGame();
    }
    public void NormalMaze()
    {
        mazeManager.setMazeSize(new Vector2Int(7, 7));
        mainCamera.transform.position = new Vector3(0f, 19.5f, 0f);
        StartGame();
    }
    
    public void HardMaze()
    {
        mazeManager.setMazeSize(new Vector2Int(9,9));
        mainCamera.transform.position = new Vector3(0f, 24.5f, 0f);
        StartGame();
    }
    
    public void StartGame()
    {
        StateMachine.TriggerTransition(Transition.SetUpGame);
    }
    
}
