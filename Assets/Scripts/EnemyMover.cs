using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0, 5)]float speed = 1;
    

    Enemy enemy;
    GridManager gridManager;
    PathFinder pathFinder;
    List<Node> path = new List<Node>();

    private void Awake()
    {
        gridManager = GameObject.FindWithTag("GridManager").GetComponent<GridManager>();
        pathFinder = GameObject.FindWithTag("ObjectPool").GetComponent<PathFinder>();
        enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        ReturnToStart();
        RecalculatePath(true);
        enemy.enabled = true;
    }

    void RecalculatePath(bool resetPath)
    {
        Vector2Int coordinates = new Vector2Int();

        if (resetPath)
        {
            coordinates = pathFinder.StartCoordinates;
        }
        else
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
        }

        StopAllCoroutines();

        path.Clear();
        path = pathFinder.GetNewPath(coordinates);

        StartCoroutine(FollowPath());
    }

    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathFinder.StartCoordinates);
    }

    void FinishPath()
    {
        enemy.StealGold();
        enemy.enabled = false;
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        for(int i = 1; i < path.Count; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercent = 0f;
            transform.LookAt(endPosition);

            while (travelPercent < 1)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        FinishPath();

    }
}
