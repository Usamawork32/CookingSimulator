using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterChild : MonoBehaviour
{
    private void OnTriggerEnter(Collider  other)
    {
        if (other.gameObject.CompareTag("Cayenna Pepper") || other.gameObject.CompareTag("lemon") || other.gameObject.CompareTag("potato")
           || other.gameObject.CompareTag("SalmonFillet") || other.gameObject.CompareTag("potato1") || other.gameObject.CompareTag("onion")
           || other.gameObject.CompareTag("Dril Dried") || other.gameObject.CompareTag("Salt.") || other.gameObject.CompareTag("Thyme Dried")
           || other.gameObject.CompareTag("Horseria") || other.gameObject.CompareTag("BlackPepper") || other.gameObject.CompareTag("tomato")
           || other.gameObject.CompareTag("meat") || other.gameObject.CompareTag("fish"))
        {
            other.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider  other)
    {
        if (other.gameObject.CompareTag("lemon") || other.gameObject.CompareTag("Cayenna Pepper") || other.gameObject.CompareTag("potato") || other.gameObject.CompareTag("potato1")
           || other.gameObject.CompareTag("SalmonFillet") || other.gameObject.CompareTag("onion")
           || other.gameObject.CompareTag("Dril Dried") || other.gameObject.CompareTag("Salt.") || other.gameObject.CompareTag("Thyme Dried")
           || other.gameObject.CompareTag("Horseria") || other.gameObject.CompareTag("BlackPepper") || other.gameObject.CompareTag("tomato") || other.gameObject.CompareTag("meat") || other.gameObject.CompareTag("fish"))
        {
            other.transform.parent = null;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cayenna Pepper") || collision.gameObject.CompareTag("lemon") || collision.gameObject.CompareTag("tomato") || collision.gameObject.CompareTag("potato")
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
            || collision.gameObject.CompareTag("SalmonFillet") || collision.gameObject.CompareTag("onion") || collision.gameObject.CompareTag("tomato")
            || collision.gameObject.CompareTag("Dril Dried") || collision.gameObject.CompareTag("Salt.") || collision.gameObject.CompareTag("Thyme Dried")
            || collision.gameObject.CompareTag("Horseria") || collision.gameObject.CompareTag("BlackPepper") || collision.gameObject.CompareTag("tomato") || collision.gameObject.CompareTag("meat") || collision.gameObject.CompareTag("fish"))
        {
            collision.transform.parent = null;
        }
    }
}
