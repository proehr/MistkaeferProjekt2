using System;
using System.Collections.Generic;
using Maze.Item;
using UnityEditor;
using UnityEngine;
using UnityTemplateProjects;

namespace Maze
{
    public class MazeManager : MonoBehaviour
    {
        [SerializeField] private Maze mazePrefab = null;
        [SerializeField] private List<MazeItem> mazeItemPrefabList = new List<MazeItem>();
        [SerializeField] private Vector2Int mazeSize = new Vector2Int(0, 0);
        [SerializeField] private GameObject ball;

        private Maze mazeInstance;

        public void Start()
        {
            SetUpState.OnEnterSetUpEvent += GenerateMaze;
            SetUpState.OnExitSetUpEvent += PlacePlayer;

            MainMenuState.OnEnterMainMenuEvent += RemoveMaze;
            MainMenuState.OnEnterMainMenuEvent += DeactivatePlayer;
        }

        public void GenerateMaze()
        {
            if (mazeInstance != null)
            {
                RemoveMaze();
            }
            mazeInstance = Instantiate(mazePrefab) as global::Maze.Maze;
            mazeInstance.GenerateMazeWithSize(mazeSize);
            ItemGenerator.Generate(mazeInstance, mazeItemPrefabList);
            StateMachine.TriggerTransition(Transition.PlayGame);
        }

        public void PlacePlayer()
        {
            ball.SetActive(true);
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            ball.transform.position = mazeInstance.GetCell(0).transform.position + new Vector3(0,3,0);
        }
        
        
        private void DeactivatePlayer()
        {
            ball.SetActive(false);
        }
        
        private void RemoveMaze()
        {
            Destroy(mazeInstance.gameObject);
        }

        public void setMazeSize(Vector2Int size)
        {
            mazeSize = size;
        }

    }
}