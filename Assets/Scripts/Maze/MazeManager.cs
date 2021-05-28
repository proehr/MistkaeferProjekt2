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
            SetUpState.OnEnterSetUpEvent += StartMazeGeneration;
        }

        public void StartMazeGeneration()
        {
            mazeInstance = Instantiate(mazePrefab) as global::Maze.Maze;
            mazeInstance.GenerateMazeWithSize(mazeSize);
            ItemGenerator.Generate(mazeInstance, mazeItemPrefabList);
        }

        public void placePlayer()
        {
            ball.transform.position = mazeInstance.GetCell(0).transform.position;
        }
    }
}