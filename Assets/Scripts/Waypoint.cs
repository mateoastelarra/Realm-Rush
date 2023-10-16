using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool isPlaceable;

    [SerializeField] private Tower towerPrefab;

    public bool IsPlaceable { get => isPlaceable; }

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = towerPrefab.BuildTower(transform.position);
            isPlaceable = !isPlaced;
        }    
    }
}
