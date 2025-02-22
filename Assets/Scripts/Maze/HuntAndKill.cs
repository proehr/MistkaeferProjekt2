﻿using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public static class HuntAndKillMazeGenerator
    {
        private static Maze maze;

        
        /**
         * The Hunt-And-Kill algorithm walks randomly from starting location (0,0) once
         * Then walks from random cells until all cells have been visited.
         */
        public static void HuntAndKill(Maze mazeInstance)
        {
            maze = mazeInstance;
            WalkFromCell(GetCell(0, 0));
            WalkFromRandomCells();
            EliminateIsolatedCells();
        }
        
        private static void WalkFromRandomCells()
        {
            for (int i = 1; i < maze.GetCellAmount()*2; i++)
            {
                MazeCell randomCell = maze.GetRandomCell();
                if (randomCell.IsVisited())
                {
                    WalkFromCell(randomCell);
                }
            }
        }
        
        /**
         * Walk algorithm chooses unvisited cell in random direction from current cell and
         * removes walls between cells to free the way for the player
         * until current cell has no unvisited neighbors
         */
        private static void WalkFromCell(MazeCell startingCell)
        {
            MazeCell currentCell = startingCell;
            List<MazeDirection> unvisitedNeighbors = FindUnvisitedNeighbors(currentCell);
            while (unvisitedNeighbors.Count > 0)
            {
                MazeDirection chosenDirection = unvisitedNeighbors[Random.Range(0, unvisitedNeighbors.Count)];
                MazeCell chosenCell = GetNeighborCellInDirection(currentCell, chosenDirection);
                
                DestroyWall(currentCell.GetEdge(chosenDirection));
                DestroyWall(chosenCell.GetEdge(chosenDirection.GetOpposite()));
                
                currentCell = chosenCell;
                currentCell.SetVisited(true);
                
                unvisitedNeighbors = FindUnvisitedNeighbors(currentCell);
            }
        }

        private static List<MazeDirection> FindUnvisitedNeighbors(MazeCell mazeCell)
        {
            int x = mazeCell.GetX();
            int y = mazeCell.GetY();
            List<MazeDirection> unvisitedNeighbors = new List<MazeDirection>();
            if (GetCell(x - 1, y) != null && !GetCell(x - 1, y).IsVisited())
            {
                unvisitedNeighbors.Add(MazeDirection.South);
            }

            if (GetCell(x, y + 1) != null && !GetCell(x, y + 1).IsVisited())
            {
                unvisitedNeighbors.Add(MazeDirection.West);
            }

            if (GetCell(x + 1, y) != null && !GetCell(x + 1, y).IsVisited())
            {
                unvisitedNeighbors.Add(MazeDirection.North);
            }

            if (GetCell(x, y - 1) != null && !GetCell(x, y - 1).IsVisited())
            {
                unvisitedNeighbors.Add(MazeDirection.East);
            }

            return unvisitedNeighbors;
        }

        private static MazeCell GetNeighborCellInDirection(MazeCell cell, MazeDirection direction)
        {
            return GetCell(cell.GetX() + MazeDirections.ToIntVector2(direction).x,
                cell.GetY() + MazeDirections.ToIntVector2(direction).y);
        }

        private static void DestroyWall(MazeCellEdge wall)
        {
            if (wall != null && !Application.isEditor)
            {
                wall.cell.SetEdge(wall.direction, null);
                GameObject.Destroy(wall.gameObject);
            }
            else if (wall != null && Application.isEditor)
            {
                GameObject.DestroyImmediate(wall.gameObject);
            }
        }
        
        /**
         * checks all cells and connects them if they havent been visited
         */
        private static void EliminateIsolatedCells()
        {
            for (int i = 1; i < maze.GetCellAmount(); i++)
            {
                MazeCell cell = maze.GetCell(i);
                if (!cell.IsVisited())
                {
                    ConnectCell(cell);
                }
            }
        }

        /**
         * chooses random direction to connect cell to and removes walls
         */
        private static void ConnectCell(MazeCell cell)
        {
            MazeDirection randomDirection = MazeDirections.RandomValue;
            MazeCell chosenCell = GetNeighborCellInDirection(cell, randomDirection);
            while (chosenCell == null)
            {
                randomDirection = MazeDirections.GetNext(randomDirection);
                chosenCell = GetNeighborCellInDirection(cell, randomDirection);
            }
            
            DestroyWall(cell.GetEdge(randomDirection));
            DestroyWall(chosenCell.GetEdge(randomDirection.GetOpposite()));
            
            cell.SetVisited(true);
            WalkFromCell(cell);
        }

        private static MazeCell GetCell(int x, int y)
        {
            return maze.GetCell(x, y);
        }
    }
}