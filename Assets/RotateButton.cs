using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float rotationSpeed = 5.0f;
    public bool Rotate, Rotate1 = false;
    public Transform transformRotate;


    public void StartRotation()
    {
        Rotate=true;
    }
    public void StartRotation1()
    {
        Rotate1 = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        StopAllCoroutines();
        Rotate = false;
        Rotate1 = false;
    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (Rotate1)
        {
            StartCoroutine(RotateCoroutine1());
        }
        if (Rotate)
        {
            StartCoroutine(RotateCoroutine());
        }
    }


    IEnumerator RotateCoroutine()
    {
        while (Rotate)
        {
            // Rotate the object around its up axis
            transformRotate.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

            yield return null;
        }
    }
    

    IEnumerator RotateCoroutine1()
    {
        while (Rotate1)  
        {
            transformRotate.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);

            yield return null;
        }
    }

}
