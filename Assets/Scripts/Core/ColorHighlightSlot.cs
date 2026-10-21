using UnityEngine;

public class ColorHighlightSlot : MonoBehaviour
{
    public BlockColor expectedColor;

    private BlockColor currentColor;
    private bool occupied = false;

    [SerializeField] private Level2PuzzleManager puzzleManager;

    private void OnTriggerStay(Collider other)
    {
        ColorIdentifier block = other.GetComponent<ColorIdentifier>();

        if (block != null)
        {
            currentColor = block.blockColor;
            occupied = true;

            puzzleManager.CheckPuzzle();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ColorIdentifier block = other.GetComponent<ColorIdentifier>();

        if (block != null)
        {
            occupied = false;
        }
    }

    public bool IsCorrect()
    {
        return occupied && currentColor == expectedColor;
    }
}