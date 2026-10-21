using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    public GameObject crystal1Glow;
    public GameObject crystal2Glow;
    public GameObject crystal3Glow;

    public GameObject completionUI;
    public GameObject platformHighlight;

    private bool puzzle1Completed;
    private bool puzzle2Completed;
    private bool puzzle3Completed;

    public void PuzzleCompleted(int puzzleNo)
    {
        switch (puzzleNo)
        {
            case 1:
                if (!puzzle1Completed)
                {
                    puzzle1Completed = true;
                    crystal1Glow.SetActive(true);
                }
                break;

            case 2:
                if (!puzzle2Completed)
                {
                    puzzle2Completed = true;
                    crystal2Glow.SetActive(true);
                }
                break;

            case 3:
                if (!puzzle3Completed)
                {
                    puzzle3Completed = true;
                    crystal3Glow.SetActive(true);
                }
                break;
        }

        CheckLevelCompleted();
    }

    void CheckLevelCompleted()
    {
        if (puzzle1Completed &&
            puzzle2Completed &&
            puzzle3Completed)
        {
            completionUI.SetActive(true);
            platformHighlight.SetActive(true);
        }
    }
}