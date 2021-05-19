using System.Collections.Generic;
using Maze.Item;
using UnityEngine;

namespace Maze
{
    public class MazeManager : MonoBehaviour
    {
        [SerializeField] private Maze mazePrefab = null;
        [SerializeField] private List<MazeItem> mazeItemPrefabList = new List<MazeItem>();
        [SerializeField] private Vector2Int mazeSize = new Vector2Int(0, 0);

        private Maze mazeInstance;

        private void Start()
        {
            mazeInstance = Instantiate(mazePrefab) as global::Maze.Maze;
            mazeInstance.GenerateMazeWithSize(mazeSize);
            ItemGenerator.Generate(mazeInstance, mazeItemPrefabList);
        }
    }
}