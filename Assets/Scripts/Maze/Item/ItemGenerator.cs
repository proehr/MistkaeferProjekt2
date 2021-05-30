using System.Collections.Generic;
using UnityEngine;

namespace Maze.Item
{

    public class ItemGenerator : MonoBehaviour
    {
        private static Maze maze;
        
        /**
         * Places all given Items in the given maze
         */
        public static void Generate(Maze generationMaze, List<PowerUp> mazeItemPrefabList)
        {
            ItemGenerator.maze = generationMaze;
            foreach (PowerUp mazeItemPrefab in mazeItemPrefabList)
            {
                switch (mazeItemPrefab)
                {
                    default:
                        GenerateRandomInMaze(mazeItemPrefab);
                        break;
                }
            }
        }
        
        private static void GenerateRandomInMaze(PowerUp mazeItemPrefab)
        {
            for (int i = 0; i < mazeItemPrefab.Count; i++)
            {
                MazeCell cell = GetRandomEmptyCell();
                Instantiate(mazeItemPrefab, cell.transform, false);
                cell.HasItem = true;
            }
        }

        private static MazeCell GetRandomEmptyCell()
        {
            MazeCell cell = null;                 // no item is spawned on the start and end positions
            while ((cell == null || cell.HasItem) || ((cell.GetY() == 0 && cell.GetX() == 0) 
                                                  || ((cell.GetY() == maze.Size.y-1 && cell.GetX() == maze.Size.x-1))))
            {
                cell = maze.GetRandomCell();
            }
            return cell;
        }
    }
}