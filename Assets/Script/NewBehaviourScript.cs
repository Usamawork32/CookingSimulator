using System.Collections;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public  bool Childmaking;
    private void Start()
    {
        Childmaking = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("lemon") || collision.gameObject.CompareTag("tomato") || collision.gameObject.CompareTag("potato")
            || collision.gameObject.CompareTag("SalmonFillet") || collision.gameObject.CompareTag("potato1") || collision.gameObject.CompareTag("onion")
            || collision.gameObject.CompareTag("fish") || collision.gameObject.CompareTag("Dril Dried") || collision.gameObject.CompareTag("Salt.") || collision.gameObject.CompareTag("Thyme Dried")
           || collision.gameObject.CompareTag("Horseria") || collision.gameObject.CompareTag("BlackPepper") || collision.gameObject.CompareTag("Cayenna Pepper"))
        {
            if (collision.transform.parent != null)
            {
                if (Childmaking && (collision.transform.parent.tag != "Place" || collision.transform.parent.tag != "Casserole , Basic"
            || collision.transform.parent.tag != "Square plate, Basic" || collision.transform.parent.tag != "Small Plate,  Basic" ||
                collision.transform.parent.tag != "Medium Plate,  Basic" || collision.transform.parent.tag != "Large Bowl , Basic"
                || collision.transform.parent.tag != "Small Deep PLate, Basic" || collision.transform.parent.tag != "Deep Plate, Basic"
                || collision.transform.parent.tag != "Medium Plate Basic" || collision.transform.parent.tag != "Small Bowl , Basic"||
              collision.transform.parent.tag != "BakingTray" || collision.transform.parent.tag != "Large Plate Basic" || collision.transform.parent.tag != "FryPan"||
                  collision.transform.parent.tag != "CuttingBoard" || collision.transform.parent.tag != "PellaPan"))
                {

                    collision.transform.parent = transform;
                    if (collision.transform.gameObject.GetComponent<Outline>())
                    {
                        collision.transform.gameObject.GetComponent<Outline>().enabled = false;
                    }
                    StartCoroutine(CheckRigidbodyAfterDelay(collision.transform.gameObject));
                }
            }
            else
            {
                if (Childmaking)
                {
                    print("Masala............"+ transform.name);
                    // Get the first contact point of the collision
                    collision.transform.parent = transform;
                    if (collision.transform.gameObject.GetComponent<Outline>())
                    {
                        collision.transform.gameObject.GetComponent<Outline>().enabled = false;
                    }
                    StartCoroutine(CheckRigidbodyAfterDelay(collision.transform.gameObject));

                }
            }
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("lemon") || collision.gameObject.CompareTag("potato") || collision.gameObject.CompareTag("potato1")
            || collision.gameObject.CompareTag("SalmonFillet") || collision.gameObject.CompareTag("onion") || collision.gameObject.CompareTag("tomato")
           || collision.gameObject.CompareTag("tomato") || collision.gameObject.CompareTag("meat") || collision.gameObject.CompareTag("fish"))
        {
            collision.transform.parent = null;
            if (!collision.transform.gameObject.GetComponent<Rigidbody>())
            {
                collision.transform.gameObject.AddComponent<Rigidbody>();
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
        else
        {
            Destroy(rb);
        }
    }
}
