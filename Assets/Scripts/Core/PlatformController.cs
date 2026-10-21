using System.Collections;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [Header("Platform Settings")]
    [SerializeField] private Transform platform;
    [SerializeField] private float moveHeight = 20f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float waitTime = 3f;

    [Header("XR Player")]
    [SerializeField] private GameObject gravityObject;
    [SerializeField] private GameObject levelOne;
    [SerializeField] private GameObject levelTwo;
    [SerializeField] private Transform xrOrigin;

    private bool moving = false;
    private bool reachedLevel2 = false;

    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = platform.position + Vector3.up * moveHeight;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        // Parent XR Origin to Platform
        other.transform.root.SetParent(platform);

        // Disable gravity object
        gravityObject.SetActive(false);

        // Enable Level 2
        levelTwo.SetActive(true);

        if (!moving)
        {
            StartCoroutine(MovePlatform());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (reachedLevel2)
        {
            // Unparent XR Origin
            xrOrigin.SetParent(null);

            // Enable Gravity
            gravityObject.SetActive(true);

            // Destroy Level 1
            Destroy(levelOne);
        }
    }

    IEnumerator MovePlatform()
    {
        moving = true;

        yield return new WaitForSeconds(waitTime);

        while (Vector3.Distance(platform.position, targetPosition) > 0.01f)
        {
            platform.position = Vector3.MoveTowards(
                platform.position,
                targetPosition,
                moveSpeed * Time.deltaTime);

            yield return null;
        }

        platform.position = targetPosition;

        reachedLevel2 = true;
    }
}