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
            print("Trigger call");
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
   
}
