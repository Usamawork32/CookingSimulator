using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KniefFPS : MonoBehaviour
{
    private GameObject cam;
    public Transform cutterBoard;
    public Transform cuttingpos, knief;
    RaycastHit hitInfo;
    float rayDistance = 5f;

    void Update()
    {
        PickUp();

    }
    public void Start()
    {
/*        cam = PickNDrop.knief2;
        cam.transform.parent = null;
        cam.transform.position = cutterBoard.tr;
        cam.transform.localRotation = cuttingpos.transform.localRotation;
        cam.transform.localScale = cuttingpos.transform.localScale;
        print(" Cam  knief2 ===" + cam.name);*/
    }
    public void PickUp()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, rayDistance))
        {

            Debug.DrawRay(transform.position, transform.forward * hitInfo.distance, Color.yellow);
           
        }

    }
}

