using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChild : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("lemon") || other.gameObject.CompareTag("tomato") || other.gameObject.CompareTag("potato")
           || other.gameObject.CompareTag("SalmonFillet") || other.gameObject.CompareTag("potato1") || other.gameObject.CompareTag("onion")
           || other.gameObject.CompareTag("fish"))
        {
            other.transform.parent = transform.parent;
            if (other.transform.gameObject.GetComponent<Outline>())
            {
                other.transform.gameObject.GetComponent<Outline>().enabled = false;
            }
            StartCoroutine(CheckRigidbodyAfterDelay(other.gameObject));
        }
    } 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("lemon") || other.gameObject.CompareTag("tomato") || other.gameObject.CompareTag("potato")
           || other.gameObject.CompareTag("SalmonFillet")  || other.gameObject.CompareTag("onion")
           || other.gameObject.CompareTag("fish"))
        {
            other.transform.parent = null;
            if (other.transform.gameObject.GetComponent<Outline>())
            {
                other.transform.gameObject.GetComponent<Outline>().enabled = false;
            }
            if (!other.gameObject.GetComponent<Rigidbody>())
            {
                other.gameObject.AddComponent<Rigidbody>();
            }
        }
    }
    IEnumerator CheckRigidbodyAfterDelay(GameObject targetObject)
    {
      
        // Wait for 4 seconds
        yield return new WaitForSeconds(1f);

        // Get the Rigidbody component from the target GameObject
        Rigidbody rb = targetObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Debug.LogWarning("Target GameObject does not have a Rigidbody component!");
            targetObject.transform.parent = transform.parent;
            Destroy(rb);
            yield break;
        }
    }
}
