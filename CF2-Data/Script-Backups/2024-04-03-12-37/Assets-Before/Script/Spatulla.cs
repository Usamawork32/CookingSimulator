using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spatulla : MonoBehaviour
{
    RaycastHit HitInfo;
    public GameObject Spatuallinteract;
    private Transform pickedObj;
    public LineRenderer linerendere;
    public Vector3 initialPosition;
    Vector3 PickupPosition;
    Quaternion pickedRotation;
    public Transform SalmonFilletPos;
    void Update()
    {
        if (Physics.Raycast(transform.position + new Vector3(-0.1f, 0, 0), -transform.up, out HitInfo, 0.5f))
        {
            Debug.DrawRay(transform.position + new Vector3(-0.1f, 0, 0), -transform.up * HitInfo.distance, Color.red);
            linerendere.SetPosition(0, HitInfo.point);
            linerendere.SetPosition(1, HitInfo.point + new Vector3(0, 0.05f, 0f));
            if (HitInfo.transform.tag=="FryPan")
            {
                Spatuallinteract.SetActive(true);
            }
            else
            {
                Spatuallinteract.SetActive(false);
            }
        }
    }
    
    public void SpatullabtnClick()
    {
        bool hasChildWithTag = HitInfo.transform.Cast<Transform>().Any(child => child.CompareTag("SalmonFillet"));
        if (hasChildWithTag)
        {
            pickedObj = HitInfo.transform.Cast<Transform>()
    .FirstOrDefault(child => child.CompareTag("SalmonFillet")); ;
            pickedObj.SetParent(transform);
            if (pickedObj.GetComponent<Rigidbody>() != null)
            {
                Rigidbody rb = pickedObj.GetComponent<Rigidbody>();
                Destroy(rb);
            }
            PickupPosition = SalmonFilletPos.localPosition;
            pickedRotation = SalmonFilletPos.localRotation;
            StartCoroutine(doubleok());
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = touch.deltaPosition;
                touchDeltaPosition = -touchDeltaPosition;

                Vector3 newPosition = new Vector3(
                    Mathf.Clamp(transform.position.x + touchDeltaPosition.x * 0.001f, initialPosition.x - 0.25f, initialPosition.x + 0.25f),
                    initialPosition.y,
                    Mathf.Clamp(transform.position.z + touchDeltaPosition.y * 0.001f, initialPosition.z - 0.25f, initialPosition.z + 0.25f));

                transform.position = newPosition;
            }
        }
    }
    IEnumerator doubleok()
    {
        // print("Doubleok");
        Vector3 b = pickedObj.transform.localPosition;
        Vector3 targetpos = PickupPosition + new Vector3(0, 2, 0);
        float distance = Vector3.Distance(b, targetpos);
        while (distance >= 0.01f)
        {
            pickedObj.transform.localPosition = Vector3.Lerp(b, targetpos, 0.1f);
            //print("a");
            distance -= 0.5f;
            yield return null;
        }
        StartCoroutine(ok());
    }
    IEnumerator ok()
    {
        Quaternion a = pickedObj.transform.localRotation;
        Vector3 b = pickedObj.transform.localPosition;
         Quaternion targetRotation = pickedRotation;
        Vector3 targetpos = PickupPosition;
        float distance = Vector3.Distance(b, targetpos);
        while (distance >= 0.01f)
        {
            pickedObj.transform.localPosition = Vector3.Lerp(b, targetpos, 0.1f * Time.deltaTime);
            pickedObj.transform.localRotation = Quaternion.Slerp(a, targetRotation, 0.1f * Time.deltaTime);
            distance -= 0.5f;
            yield return null;
        }
        pickedObj.transform.localRotation = targetRotation;
        pickedObj.transform.localPosition = targetpos;
        SpatullaTurn();
    }

    public void SpatullaTurn()
    {
        if (pickedObj.GetComponent<Rigidbody>() == null)
        {
            pickedObj.gameObject.AddComponent<Rigidbody>();
            Rigidbody rb = pickedObj.GetComponent<Rigidbody>();
            rb.isKinematic = false;
        } 
    }
}
