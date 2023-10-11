using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeller : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.grey;
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake() 
    {
        label = GetComponent<TextMeshPro>();
        DisplayCurrentCoordinates();
        waypoint = GetComponentInParent<Waypoint>();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCurrentCoordinates();
            UpdateObjectName();
        }

        ColorCoordinates();
    }

    void ColorCoordinates()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void DisplayCurrentCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x) ;
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
