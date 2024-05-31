using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableCollision : MonoBehaviour
{
    public static bool vegetableColision = true;
    private void Start()
    {
        vegetableColision = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (vegetableColision)
        {
            if ((collision.gameObject.CompareTag("lemon") || collision.gameObject.CompareTag("tomato") || collision.gameObject.CompareTag("potato")
                 || collision.gameObject.CompareTag("SalmonFillet")
                 || collision.gameObject.CompareTag("fish") || collision.gameObject.CompareTag("onion")) && (collision.transform.parent != null) && (transform.tag != "potato1"))
            {
                if (transform.gameObject.GetComponent<Rigidbody>() && (collision.collider.transform.parent.tag == "BigPot"
                     || collision.collider.transform.parent.name == "fryerBasket") && transform.parent == null)
                {
                    transform.parent = collision.transform.parent;
                    CheckRigidbodyAfterDelay(gameObject);
                }
            }
            else if (collision.gameObject.CompareTag("potato1") && collision.transform.parent != null)
            {
                if (transform.gameObject.GetComponent<Rigidbody>() && transform.parent == null &&
                    (collision.transform.parent.tag == "Medium Plate,  Basic" || collision.transform.parent.tag == "Medium Plate Basic" ||
                    collision.transform.parent.tag == "Large Plate Basic" || collision.collider.transform.parent.name == "fryerBasket"
                    || collision.collider.transform.parent.tag == "cuttertry"))
                {

                    transform.parent = collision.transform.parent;
                    CheckRigidbodyAfterDelay(gameObject);
                }
            }
            else if ((collision.gameObject.CompareTag("Dril Dried") || collision.gameObject.CompareTag("Salt.") || collision.gameObject.CompareTag("Thyme Dried")
           || collision.gameObject.CompareTag("Horseria") || collision.gameObject.CompareTag("BlackPepper") || collision.gameObject.CompareTag("Cayenna Pepper"))&& collision.transform.parent == null)
            {
                collision.transform.parent = transform.parent;
                if (collision.gameObject.GetComponent<Rigidbody>())
                {
                    Destroy(collision.gameObject.GetComponent<Rigidbody>());
                }
            }
        }
    }
    IEnumerator CheckRigidbodyAfterDelay(GameObject targetObject)
    {
        // Wait for 4 seconds
        yield return new WaitForSeconds(2f);

        // Get the Rigidbody component from the target GameObject
        Rigidbody rb = targetObject.GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogWarning("Target GameObject does not have a Rigidbody component!");
            yield break;
        }
        Destroy(rb);
        // Check the isKinematic property

    }
}
