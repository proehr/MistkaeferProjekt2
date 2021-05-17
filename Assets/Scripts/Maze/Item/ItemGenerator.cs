using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Maze.Item
{
    public class ItemGenerator : MonoBehaviour
    {
        private static Maze maze;
        
        public static void Generate(Maze maze, List<MazeItem> mazeItemPrefabList)
        {
            ItemGenerator.maze = maze;
            foreach (MazeItem mazeItemPrefab in mazeItemPrefabList)
            {
                switch (mazeItemPrefab)
                {
                    default:
                        GenerateRandomInMaze(mazeItemPrefab);
                        break;
                }
            }
        }
        
        private static void GenerateRandomInMaze(MazeItem mazeItemPrefab)
        {
            for (int i = 0; i < mazeItemPrefab.Count; i++)
            {
                MazeCell cell = GetRandomEmptyCell();
                Instantiate(mazeItemPrefab, cell.transform, false);
                cell.HasItem = true;
            }
        }

        public static MazeCell GetRandomEmptyCell()
        {
            MazeCell cell = null;
            while (cell == null || cell.HasItem)
            {
                cell = maze.GetRandomCell();
            }
            return cell;
        }
    }
}