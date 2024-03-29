using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObjInBowl : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag== "CuttingBoard" ||collision.gameObject.tag== "BakingTray" || collision.gameObject.tag== "FryPan"
            || collision.gameObject.tag== "PellaPan" || collision.gameObject.tag== "BigPot" || collision.gameObject.tag== "fryerBasket")
        {
            StartCoroutine(CheckRigidbodyAfterDelay(collision.gameObject));
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
        if (rb.isKinematic)
        {
            Debug.Log(targetObject.name + " has a Kinematic Rigidbody.");
        }
        else
        {
            Debug.Log(targetObject.name + " does not have a Kinematic Rigidbody.");
            Destroy(rb);
        }
    }
}
