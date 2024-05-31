using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoardChild : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cayenna Pepper") || collision.gameObject.CompareTag("lemon") || collision.gameObject.CompareTag("potato")
            || collision.gameObject.CompareTag("SalmonFillet") || collision.gameObject.CompareTag("potato1") || collision.gameObject.CompareTag("onion")
            || collision.gameObject.CompareTag("Dril Dried") || collision.gameObject.CompareTag("Salt.") || collision.gameObject.CompareTag("Thyme Dried")
            || collision.gameObject.CompareTag("Horseria") || collision.gameObject.CompareTag("BlackPepper") || collision.gameObject.CompareTag("tomato")
            || collision.gameObject.CompareTag("meat") || collision.gameObject.CompareTag("fish"))


        {
            collision.transform.parent = transform;
 
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
}
