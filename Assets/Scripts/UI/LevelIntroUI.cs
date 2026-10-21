using System.Collections;
using UnityEngine;

public class LevelIntroUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject introPanel;

    [Header("Gameplay Objects")]
    [SerializeField] private GameObject highlightRings;
    [SerializeField] private GameObject targetScreen;

    [Header("Settings")]
    [SerializeField] private float displayTime = 3f;
    [SerializeField] private float fadeDuration = 1f;

    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = introPanel.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
            canvasGroup = introPanel.AddComponent<CanvasGroup>();

        // Gameplay objects initially hidden
        highlightRings.SetActive(false);
        targetScreen.SetActive(false);

        StartCoroutine(IntroSequence());
    }

    IEnumerator IntroSequence()
    {
        introPanel.SetActive(true);
        canvasGroup.alpha = 1f;

        yield return new WaitForSeconds(displayTime);

        float t = 0f;

        while (t < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            t += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0f;
        introPanel.SetActive(false);

        // Enable gameplay
        highlightRings.SetActive(true);
        targetScreen.SetActive(true);
    }
}