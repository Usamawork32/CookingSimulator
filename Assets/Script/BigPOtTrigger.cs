using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPOtTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cayenna Pepper") || other.gameObject.CompareTag("lemon") || other.gameObject.CompareTag("tomato") || other.gameObject.CompareTag("potato")
            || other.gameObject.CompareTag("SalmonFillet") || other.gameObject.CompareTag("potato1") || other.gameObject.CompareTag("onion")
          | other.gameObject.CompareTag("tomato")
            || other.gameObject.CompareTag("meat") || other.gameObject.CompareTag("fish"))
        {
            other.transform.parent = transform.parent;
            StartCoroutine(CheckRigidbodyAfterDelay(other.transform.gameObject));

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("lemon")  || other.gameObject.CompareTag("potato") || other.gameObject.CompareTag("potato1")
            || other.gameObject.CompareTag("SalmonFillet") || other.gameObject.CompareTag("onion") || other.gameObject.CompareTag("tomato")
             || other.gameObject.CompareTag("tomato") || other.gameObject.CompareTag("meat") || other.gameObject.CompareTag("fish"))
        {
            other.transform.parent = null;
        }

    }
    IEnumerator CheckRigidbodyAfterDelay(GameObject targetObject)
    {
        // Wait for 4 seconds
        yield return new WaitForSeconds(4f);

        // Get the Rigidbody component from the target GameObject
        Rigidbody rb = targetObject.GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogWarning("Target GameObject does not have a Rigidbody component!");
            yield break;
        }

        // Check the isKinematic property
        if (!rb.isKinematic)
        {
            Destroy(rb);
        }
    }
}
