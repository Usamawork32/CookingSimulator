using System.Collections;
using System.Linq;
using UnityEngine;

public class FishFried : MonoBehaviour
{
    public Material friedFishMaterial;
    public Material underfriedFishMaterial;
    public Material OverffriedFishMaterial;
    float elapsedtime = 0;
    private bool isFrying = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.gameObject.CompareTag("OVEN"))
        {
            bool parentHasFish = GetComponentsInChildren<Transform>().Any(child => child.CompareTag("fish"));
            if (parentHasFish)
            
            {
                
                if (!isFrying && PickNDrop.friedfish)
                {
                    isFrying = true; print(" start");
                    StartCoroutine(Fryfish());
                }
                elapsedtime += Time.deltaTime;
                if (elapsedtime >= 400)
                {
                    print("  Fish over Cooked");
                    foreach (Transform child in transform)
                    {
                        if (child.tag == "fish" && child.GetComponent<Renderer>().material == friedFishMaterial)
                        {
                            child.GetComponent<Renderer>().material = OverffriedFishMaterial;
                        }
                    }
                }

            }
        }
        if (other.transform.gameObject.CompareTag("OVEN"))
        {
            bool parentHasFish = GetComponentsInChildren<Transform>().Any(child => child.CompareTag("fish"));
            if (parentHasFish)

            {

                if (!isFrying && PickNDrop.friedfish)
                {
                    isFrying = true; print(" start");
                    StartCoroutine(Fryfish());
                }
                elapsedtime += Time.deltaTime;
                if (elapsedtime >= 400)
                {
                    print("  Fish over Cooked");
                    foreach (Transform child in transform)
                    {
                        if (child.tag == "fish" && child.GetComponent<Renderer>().material == friedFishMaterial)
                        {
                            child.GetComponent<Renderer>().material = OverffriedFishMaterial;
                        }
                    }
                }
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.CompareTag("OVEN"))
        {
            elapsedtime = 0;
            isFrying = false;
        }
    }

    IEnumerator Fryfish()
    {

        yield return new WaitForSeconds(60f);
        foreach (Transform child in transform)
        {
            if (child.tag == "fish")
            {
                child.GetComponent<Renderer>().material = underfriedFishMaterial;
                StartCoroutine(ChangeMat(child));
            }

        }
        yield return null;
    }

    private IEnumerator ChangeMat(Transform child)
    {
        Renderer childRenderer = child.GetComponent<Renderer>();
        Material originalMaterial = childRenderer.material;
        float elapsedTime = 0f;
        float duration = 1.3f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float lerpFactor = elapsedTime / duration;
            childRenderer.material.Lerp(originalMaterial, friedFishMaterial, lerpFactor);

            yield return new WaitForSeconds(1);
        }
        childRenderer.material = friedFishMaterial;
        child.GetComponent<Renderer>().material = friedFishMaterial;
        isFrying = false;
    }



}
