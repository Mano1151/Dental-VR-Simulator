using UnityEngine;

public class Level2PuzzleManager : MonoBehaviour
{
    [SerializeField] private ColorHighlightSlot[] slots;
    [SerializeField] private int puzzleNumber;
    [SerializeField] private Level2Manager level2Manager;

    private bool completed = false;

    public void CheckPuzzle()
    {
        if (completed)
            return;

        // Check if every slot is filled correctly
        foreach (ColorHighlightSlot slot in slots)
        {
            if (!slot.IsCorrect())
                return;
        }

        completed = true;

        level2Manager.PuzzleCompleted(puzzleNumber);
    }
}