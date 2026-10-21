using UnityEngine;

public class HighlightSlot : MonoBehaviour
{
    public ColorType expectedColor;

    [HideInInspector]
    public ColorCube currentCube;

    private void OnTriggerEnter(Collider other)
    {
        ColorCube cube = other.GetComponent<ColorCube>();

        if (cube == null)
            return;

        currentCube = cube;

        Level3Manager.Instance.CheckPuzzle();
    }

    private void OnTriggerExit(Collider other)
    {
        ColorCube cube = other.GetComponent<ColorCube>();

        if (cube == null)
            return;

        if (currentCube == cube)
        {
            currentCube = null;
            Level3Manager.Instance.CheckPuzzle();
        }
    }
}