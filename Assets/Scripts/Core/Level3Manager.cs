using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    public static Level3Manager Instance;

    [Header("Slots")]
    public HighlightSlot[] slots;

    [Header("UI")]
    public GameObject levelCompleteUI;

    private bool completed = false;

    private void Awake()
    {
        Instance = this;

        if (levelCompleteUI != null)
            levelCompleteUI.SetActive(false);
    }

    public void CheckPuzzle()
    {
        if (completed)
            return;

        foreach (HighlightSlot slot in slots)
        {
            // Empty slot
            if (slot.currentCube == null)
                return;

            // Wrong cube
            if (slot.currentCube.cubeColor != slot.expectedColor)
                return;
        }

        completed = true;

        Debug.Log("LEVEL COMPLETE");

        levelCompleteUI.SetActive(true);
    }
}