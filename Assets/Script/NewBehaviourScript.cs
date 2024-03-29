using System.Collections;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cayenna Pepper") ||collision.gameObject.CompareTag("lemon") || collision.gameObject.CompareTag("potato") 
            || collision.gameObject.CompareTag("SalmonFillet") || collision.gameObject.CompareTag("potato1") || collision.gameObject.CompareTag("onion")
            || collision.gameObject.CompareTag("Dril Dried") || collision.gameObject.CompareTag("Salt.") || collision.gameObject.CompareTag("Thyme Dried") 
            || collision.gameObject.CompareTag("Horseria") || collision.gameObject.CompareTag("BlackPepper") || collision.gameObject.CompareTag("tomato") 
            || collision.gameObject.CompareTag("meat")|| collision.gameObject.CompareTag("fish"))
        

        {
            collision.transform.parent = transform;
            StartCoroutine(CheckRigidbodyAfterDelay(collision.transform.gameObject));
        }
    
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("lemon") || collision.gameObject.CompareTag("Cayenna Pepper") || collision.gameObject.CompareTag("potato") || collision.gameObject.CompareTag("potato1")
            || collision.gameObject.CompareTag("SalmonFillet") || collision.gameObject.CompareTag("onion")
            || collision.gameObject.CompareTag("Dril Dried") || collision.gameObject.CompareTag("Salt.") || collision.gameObject.CompareTag("Thyme Dried")
            || collision.gameObject.CompareTag("Horseria") || collision.gameObject.CompareTag("BlackPepper") || collision.gameObject.CompareTag("tomato") || collision.gameObject.CompareTag("meat") || collision.gameObject.CompareTag("fish"))
        {
            collision.transform.parent = null;
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
        if (rb.isKinematic)
        {
            Debug.Log(targetObject.name + " has a Kinematic Rigidbody.");
        }
        else
        {
            Debug.Log(targetObject.name + " does not have a Kinematic Rigidbody.");
            // rb.isKinematic = true;
            Destroy(rb);
        }
    }
}
