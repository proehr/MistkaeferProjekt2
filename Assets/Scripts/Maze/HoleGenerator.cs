using UnityEngine;

namespace Maze.Holes
{
    public class HoleGenerator : MonoBehaviour
    {
        
        // Removes a random floor piece in given amount of random Maze Cells
        public static void Generate(Maze maze, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                MazeCell randomCell = maze.GetRandomCell();
                while (randomCell.HasHoles || randomCell.groundPieces.Count < 4)
                {
                    randomCell = maze.GetRandomCell();
                }
                randomCell.GetRandomGroundPiece().SetActive(false);
                randomCell.HasHoles = true;
            }
        }
    }
}