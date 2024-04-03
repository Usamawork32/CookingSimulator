using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPot3 : MonoBehaviour
{
    public float startValue = 100f;
    public float endValue = 50f;
    public float duration = 2f;
    public static BigPot3 Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void Startcoroutine()
    {
        StartCoroutine(LerpSkinnedMeshValue());
    }
    public void Stopcoroutine()
    {
        StopCoroutine(LerpSkinnedMeshValue());
    }

    public IEnumerator LerpSkinnedMeshValue()
    {
        SkinnedMeshRenderer skinnedMeshRenderer = transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>();

        if (skinnedMeshRenderer == null)
        {
            Debug.LogError("SkinnedMeshRenderer not found on child object.");
            yield break;
        }

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float currentValue = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            skinnedMeshRenderer.SetBlendShapeWeight(0, currentValue); // Assuming index 0

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the end value is set exactly
        skinnedMeshRenderer.SetBlendShapeWeight(0, endValue);
    }
}
