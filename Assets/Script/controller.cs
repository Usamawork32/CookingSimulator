using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    public float totalShiftDistance;
    public float cameraShiftSpeed;
    public Transform playercamera;
    public Transform envcamera;
    Transform T;
    public GameObject  Cf_Rig, FPS;
    int a = 1;
    public static controller instance;
    private void Awake()
    {
        instance = this;
    }
    public void TargetTV (Transform targettv , float Targetsize,int ControlFrig)
    {
        T = targettv;
        envcamera.position = playercamera.position;
        envcamera.rotation = playercamera.rotation;
        envcamera.gameObject.SetActive(true);
        playercamera.gameObject.SetActive(false);
        Cf_Rig.SetActive(false);
        a = ControlFrig;
        StartCoroutine(moveCamera(T,  Targetsize));
    }
    public void BackFromTV()
    {
        a = 2;
        StartCoroutine(moveBackCamera(playercamera,  30f));
    }
    IEnumerator moveCamera(Transform targettransform,  float targetSize)
    {
        while (Vector3.Distance(envcamera.position, targettransform.position) > totalShiftDistance)
        {
            envcamera.position = Vector3.Lerp(envcamera.position, targettransform.position, Time.deltaTime * cameraShiftSpeed);
            envcamera.rotation = Quaternion.Lerp(envcamera.rotation, targettransform.rotation, Time.deltaTime * cameraShiftSpeed);
            envcamera.GetComponent<Camera>().fieldOfView = Mathf.Lerp(envcamera.GetComponent<Camera>().fieldOfView, targetSize, cameraShiftSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        if (a == 2)
        {
            Cf_Rig.SetActive(true);
        }
        envcamera.gameObject.SetActive(true);
        playercamera.gameObject.SetActive(false);
        yield return null;
    }
    IEnumerator moveBackCamera(Transform targettransform, float targetSize)
    {
        while (Vector3.Distance(envcamera.position, targettransform.position) > totalShiftDistance)
        {
            envcamera.position = Vector3.Lerp(envcamera.position, playercamera.position, Time.deltaTime * cameraShiftSpeed);
            envcamera.rotation = Quaternion.Lerp(envcamera.rotation, playercamera.rotation, Time.deltaTime * cameraShiftSpeed);
            envcamera.GetComponent<Camera>().fieldOfView = Mathf.Lerp(envcamera.GetComponent<Camera>().fieldOfView, targetSize, cameraShiftSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        if (a == 2)
        {
            Cf_Rig.SetActive(true);
        }
        envcamera.gameObject.SetActive(false);
        playercamera.gameObject.SetActive(true);
        yield return null;
    }
}
