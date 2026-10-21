using UnityEngine;

public class HighlightRing : MonoBehaviour
{
    [Header("Expected Shape")]
    public ShapeType expectedShape;

    
    public ShapeIdentifier currentShape;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Inside Trigger : " + other.name);

        ShapeIdentifier shape = other.GetComponent<ShapeIdentifier>();

        if (shape != null)
        {
            currentShape = shape;
            Debug.Log("Detected : " + shape.shapeType);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ShapeIdentifier shape = other.GetComponent<ShapeIdentifier>();

        if (shape != null && currentShape == shape)
        {
            currentShape = null;
        }
    }

    public bool IsCorrect()
    {
        if (currentShape == null)
            return false;

        return currentShape.shapeType == expectedShape;
    }
}