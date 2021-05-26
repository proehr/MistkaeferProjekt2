using System;
using System.Collections.Generic;
using Maze.Item;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Maze
{
    public class Maze : MonoBehaviour
    {
        [SerializeField] protected Vector2Int size = Vector2Int.zero;
        [SerializeField] protected float sizeCells = 3;

        [SerializeField] protected MazeCell cellPrefab = null;
        [SerializeField] protected MazeCell startCellPrefab = null;
        [SerializeField] protected MazeCell finishCellPrefab = null;
        [SerializeField] protected MazeCellWall wallPrefab = null;
        [SerializeField] protected GameObject buttressPrefab = null;

        protected MazeCell[][] cells;

        public void GenerateMazeWithSize(Vector2Int vector2)
        {
            size = vector2;
            Generate();
        }

        public void Generate()
        {
            InitAllCells();
            InitAllWalls();

            MazeGenerator.HuntAndKill(this);
        }

        private void InitAllCells()
        {
            cells = new MazeCell[size.x][];
            for (int x = 0; x < size.x; x++)
            {
                cells[x] = new MazeCell[size.y];
                for (int y = 0; y < size.y; y++)
                {
                    if (x == 0 && y == 0)
                    {
                        CreateAndPlaceCell(x, y, startCellPrefab);
                    } else if (x == size.x - 1 && y == size.y - 1)
                    {
                        CreateAndPlaceCell(x, y, finishCellPrefab);
                    } else
                    {
                        CreateAndPlaceCell(x, y, cellPrefab);
                    }
                }
            }
        }

        private void InitAllWalls()
        {
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    CreateAndPlaceWall(GetCell(x, y), GetCell(x + 1, y), MazeDirection.North);
                    CreateAndPlaceWall(GetCell(x, y), GetCell(x - 1, y), MazeDirection.South);
                    CreateAndPlaceWall(GetCell(x, y), GetCell(x, y - 1), MazeDirection.East);
                    CreateAndPlaceWall(GetCell(x, y), GetCell(x, y + 1), MazeDirection.West);
                }
            }
        }

        public void CreateAndPlaceCell(int x, int y, MazeCell prefab)
        {
            MazeCell cell = Instantiate(prefab, transform, true) as MazeCell;
            cell.Initialize(x, y);

            cell.transform.localPosition = new Vector3(sizeCells * (x - size.x / 2), 0f, sizeCells * (y - size.y / 2));
            cell.transform.GetChild(0).localScale = new Vector3(sizeCells, sizeCells, sizeCells);

            AddButtresses(cell);

            cells[x][y] = cell;
        }

        public void CreateAndPlaceWall(MazeCell cell, MazeCell otherCell, MazeDirection direction)
        {
            MazeCellWall wall = Instantiate(wallPrefab) as MazeCellWall;

            wall.Initialize(cell, otherCell, direction);

            wall.transform.GetChild(0).localScale = new Vector3(1, 1, sizeCells);
            wall.transform.GetChild(0).localPosition = new Vector3(sizeCells * 0.5f - 0.16666f, 0, 0);
        }

        protected void AddButtresses(MazeCell cell)
        {
            for (int i = 0; i < MazeDirections.Count; i++)
            {
                GameObject buttress = Instantiate(buttressPrefab, cell.transform, false);
                buttress.transform.GetChild(0).localPosition =
                    new Vector3(sizeCells * 0.5f - 0.16666f, 0, sizeCells * 0.5f - 0.16666f);
                buttress.transform.localRotation = MazeDirections.ToRotation((MazeDirection) i);
                cell.buttresses.Add(buttress);
            }
        }

        public int GetCellAmount()
        {
            return size.x * size.y;
        }

        public MazeCell GetCell(int x, int y)
        {
            if (x >= size.x || x < 0 || y >= size.y || y < 0)
            {
                return null;
            }

            return cells[x][y];
        }
        
        public MazeCell GetCell(int cellNumber)
        {
            int cellY = cellNumber / size.x;
            int cellX = cellNumber - cellY * size.x;
            return GetCell(cellX, cellY);
        }

        public MazeCell GetRandomCell()
        {
            return GetCell(Random.Range(0, size.x - 1), Random.Range(0, size.y - 1));
        }

        public Vector2Int Size => size;
    }
}