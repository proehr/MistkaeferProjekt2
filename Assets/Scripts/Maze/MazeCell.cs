﻿using System.Collections.Generic;
using Maze;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    private MazeCellEdge[] edges = new MazeCellEdge[MazeDirections.Count];
    private Vector2Int coordinates;
    private bool visited;
    private int path;
    private bool hasItem;
    private bool hasHoles;
    public List<GameObject> buttresses = new List<GameObject>();
    public List<GameObject> groundPieces = new List<GameObject>();
    

    public void Initialize(int x, int y)
    {
        SetVisited(false);
        SetCoordinates(x, y);

        name = "Maze Cell" + x + "," + y;
    }

    //************** GETTERS & SETTERS ************//
    public void SetCoordinates(int x, int y)
    {
        coordinates = new Vector2Int(x,y);
    }

    public int GetX()
    {
        return coordinates.x;
    }

    public int GetY()
    {
        return coordinates.y;
    }

    public MazeCellEdge GetEdge (MazeDirection direction) {
        return edges[(int)direction];
    }

    public void SetEdge (MazeDirection direction, MazeCellEdge edge) {
        edges[(int)direction] = edge;
    }

    public void SetVisited(bool visited)
    {
        this.visited = visited;
    }

    public bool IsVisited()
    {
        return visited;
    }

    public bool HasItem
    {
        get => hasItem;
        set => hasItem = value;
    }
    
    public bool HasHoles
    {
        get => hasHoles;
        set => hasHoles = value;
    }

    public GameObject GetRandomGroundPiece()
    {
        return groundPieces[Random.Range(0, groundPieces.Count-1)];
    }
}