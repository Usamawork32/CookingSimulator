using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spatulla : MonoBehaviour
{
    RaycastHit HitInfo;
    public GameObject Spatuallinteract;
    private Transform pickedObj;
    public LineRenderer linerendere;
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
            if (HitInfo.transform.tag=="SalmonFillet")
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
        pickedObj = HitInfo.transform;
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
