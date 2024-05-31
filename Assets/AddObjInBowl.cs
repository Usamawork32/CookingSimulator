using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObjInBowl : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CuttingBoard" || collision.gameObject.tag == "BakingTray" || collision.gameObject.tag == "FryPan"
            || collision.gameObject.tag == "PellaPan" || collision.gameObject.tag == "BigPot" 
            || collision.gameObject.tag == "cuttertry" || collision.gameObject.tag == "CuttingBoard" || collision.gameObject.tag == "PellaPan"
            || collision.gameObject.tag == "Casserole , Basic" || collision.gameObject.tag == "Small Bowl , Basic"
            || collision.gameObject.tag == "Square plate, Basic" || collision.gameObject.tag == "Small Plate,  Basic" ||
                collision.gameObject.tag == "Medium Plate,  Basic" || collision.gameObject.tag == "Large Bowl , Basic"
                || collision.gameObject.tag == "Small Deep PLate, Basic" || collision.gameObject.tag == "Deep Plate, Basic"
                || collision.gameObject.tag == "Medium Plate Basic" || collision.gameObject.name == "fryerBasket" || collision.gameObject.tag == "Large Plate Basic")
        {
            StartCoroutine(CheckRigidbodyAfterDelay(collision.collider.gameObject));
        }
        else if (collision.gameObject.CompareTag("lemon") || collision.gameObject.CompareTag("tomato") || collision.gameObject.CompareTag("potato")
        || collision.gameObject.CompareTag("SalmonFillet") || collision.gameObject.CompareTag("onion")
        || collision.gameObject.CompareTag("fish"))
        {
            Transform childTransform = collision.transform;
            Vector3 originalScale = childTransform.localScale;

            childTransform.parent = transform;
            childTransform.localScale = new Vector3(
                originalScale.x / transform.localScale.x,
                originalScale.y / transform.localScale.y,
                originalScale.z / transform.localScale.z
            );
        }
    }
    IEnumerator CheckRigidbodyAfterDelay(GameObject targetObject)
    {
        // Wait for 4 seconds
        yield return new WaitForSeconds(1f);

        // Get the Rigidbody component from the target GameObject
        Rigidbody rb = targetObject.GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogWarning("Target GameObject does not have a Rigidbody component!");
            yield break;
        }

        // Check the isKinematic property
        if (! rb.isKinematic)
        { 
            Destroy(rb);
            if (targetObject.tag == "Medium Plate,  Basic" || targetObject.tag == "Medium Plate Basic" || targetObject.tag == "Large Plate Basic")
            {
                if (targetObject.gameObject.GetComponent<MeshCollider>())
                {
                    targetObject.gameObject.GetComponent<MeshCollider>().convex = true;
                }
            }
            else
            {
                if (targetObject.gameObject.GetComponent<MeshCollider>())
                {
                    targetObject.gameObject.GetComponent<MeshCollider>().convex = false;
                }
            }
     
        }
    }
}
