using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int endCoordinates;

    Node startNode;
    Node destinationNode;
    Node currentSearchNode;

    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null) { grid = gridManager.Grid; }

        startNode = new Node(startCoordinates, true);
        destinationNode = new Node(endCoordinates, true);
    }
    void Start()
    {
        BreadthFirstSearch();
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
            }
        }

        foreach (Node neighbor in neighbors)
        {
            if (!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
            {
                frontier.Enqueue(neighbor);
                reached.Add(neighbor.coordinates, neighbor);
            }
        }
    }

    void BreadthFirstSearch()
    {
        bool isRunning = true;
        frontier.Enqueue(startNode);
        reached.Add(startCoordinates, startNode);
        while (frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            ExploreNeighbors();
            if (currentSearchNode.coordinates == endCoordinates)
            {
                isRunning = false;
            }
        }

    }
}
