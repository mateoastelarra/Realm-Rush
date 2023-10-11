using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool isPlaceable;

    [SerializeField] private GameObject towerPrefab;
    public bool IsPlaceable { get => isPlaceable; }

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.Euler(0,0,0));
            isPlaceable = false;
        }    
    }
}
