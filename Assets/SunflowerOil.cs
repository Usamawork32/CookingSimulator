using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerOil : MonoBehaviour
{
    public GameObject TilTBtn;
    public GameObject FryPan;
    float OIlQuantity=0;
    public bool Oiltily=false;

    private void OnEnable()
    {
        TilTBtn.SetActive(true);
        Oiltily = false;
        OIlQuantity = 0;
    }

    public void tiltBtnDown()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        Oiltily = true;
    }
    public void tiltBtnUp()
    {
        transform.GetChild(1).gameObject.SetActive(false);
        Oiltily = false;

    }
    private void Update()
    {
        if (Oiltily)
        {
            OIlQuantity = OIlQuantity + Time.deltaTime;
        }
        if(OIlQuantity>6)
        {
            RaycastHit hitinfo;
            if(Physics.Raycast(transform.position,transform.forward, out hitinfo,3))
            {
                Debug.DrawRay(transform.position, transform.forward* 1, Color.white);
                if (hitinfo.transform.tag == "FryPan"|| hitinfo.transform.name== "FryPan")
                {
                    if (!hitinfo.transform.GetChild(0).gameObject.activeSelf)
                    {
                        hitinfo.transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
            }
            
        }
    }
    private void OnDisable()
    {
        TilTBtn.SetActive(false);
        OIlQuantity = 0;
    }

}
