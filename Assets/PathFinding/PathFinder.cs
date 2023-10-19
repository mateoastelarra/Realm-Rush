using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null) { grid = gridManager.Grid; }
    }
    void Start()
    {
        ExploreNeighbors();
    }

    private void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();
        for (int i = 0; i < directions.Length; i++)
        {
            Vector2Int neighborCoordinates = currentSearchNode.coordinates + directions[i];
            Node neighbor = gridManager.GetNode(neighborCoordinates);
            if (neighbor != null)
            {
                neighbors.Add(neighbor);
                // Remove Later, only for testing
                neighbor.isExplored = true;
                neighbor.isPath = true;
                Debug.Log(neighbor.coordinates);
            }
        }
    }
}
