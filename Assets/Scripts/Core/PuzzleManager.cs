using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [Header("Puzzle")]
    [SerializeField] private HighlightRing[] rings;

    [Header("UI")]
    [SerializeField] private GameObject correctScreenUI;
    [SerializeField] private GameObject wrongScreenUI;

    [Header("Platform")]
    [SerializeField] private GameObject platformHighlight;

    public bool IsPuzzleCompleted { get; private set; }

    private void Start()
    {
        correctScreenUI.SetActive(false);
        wrongScreenUI.SetActive(false);
        platformHighlight.SetActive(false);

        IsPuzzleCompleted = false;
    }

    public void CheckPuzzle()
    {
        bool allCorrect = true;

        foreach (HighlightRing ring in rings)
        {
            Debug.Log($"{ring.name} -> Expected : {ring.expectedShape} | Current : {(ring.currentShape != null ? ring.currentShape.shapeType.ToString() : "NULL")}");

            if (!ring.IsCorrect())
            {
                allCorrect = false;
            }
        }

        if (allCorrect)
        {
            IsPuzzleCompleted = true;

            correctScreenUI.SetActive(true);
            wrongScreenUI.SetActive(false);

            platformHighlight.SetActive(true);

            Debug.Log("MISSION PASSED");
        }
        else
        {
            IsPuzzleCompleted = false;

            correctScreenUI.SetActive(false);
            wrongScreenUI.SetActive(true);

            platformHighlight.SetActive(false);

            Debug.Log("WRONG ARRANGEMENT");
        }
    }
}