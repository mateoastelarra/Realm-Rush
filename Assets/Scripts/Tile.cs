using UnityEngine;

public class Tile : MonoBehaviour
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
