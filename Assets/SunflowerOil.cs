using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerOil : MonoBehaviour
{
    public GameObject TilTBtn;
    public GameObject FryPan;
    float OIlQuantity=0;public bool Oiltily=true;

    private void OnEnable()
    {
        TilTBtn.SetActive(true);
        OIlQuantity = 0;
    }
    public void tiltBtnDown()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }public void tiltBtnUp()
    {
        transform.GetChild(1).gameObject.SetActive(false);

    }
    private void Update()
    {
        if (Oiltily)
        {
            OIlQuantity = OIlQuantity + Time.deltaTime;
        }
        if(OIlQuantity>10)
        {
            if(!FryPan.transform.GetChild(0).gameObject.activeSelf)
            {
                FryPan.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
    private void OnDisable()
    {
        TilTBtn.SetActive(false);
        OIlQuantity = 0;
    }

}
