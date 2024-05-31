using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
namespace LiquidVolumeFX
{
    public class ChickenBrouth : MonoBehaviour
    {
        RaycastHit HitInfo;
        public LayerMask IgnoreMe;
        public GameObject Broutebtn;
       // public GameObject ControllerScript;
        public GameObject Bigpot;
        public LineRenderer linerendere;
        public Transform BrouteEffect;
        public Transform BrouteEffectPOs;
        public  Vector3 initialPosition;
        public bool child = false;
        Quaternion rotation;
        LiquidVolume liquid;
        public int blendShapeIndex = 0;
        public float blendShapeSpeed = 5f;
        [Range(0f, 1f)]
        public float level = -0.5f;
        int  ChickenBroutequantitlty = 0;
        private bool childRotating = false;
        public static ChickenBrouth Instance;
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            transform.gameObject.GetComponent<LineRenderer>().enabled = true;
            liquid = GetComponent<LiquidVolume>();
            level = 0f;
           // transform.GetChild(3).transform.GetChild(0).transform.GetChild(2).gameObject.GetComponent<Text>().text = (Bigpot.transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level * 357.14) + "g";
        }
        private void Update()
        {
            if (PickNDrop.Chickenbroute)
            {
                if (Physics.Raycast(BrouteEffectPOs.transform.position, BrouteEffectPOs.transform.forward, out HitInfo, 0.8f, IgnoreMe))
                {
                    Debug.DrawRay(BrouteEffectPOs.transform.position, BrouteEffectPOs.transform.forward * HitInfo.distance, Color.white);
                    if (HitInfo.transform.tag == "BigPot")
                    {
                        Broutebtn.SetActive(true);
                    }
                    else
                    {
                        Broutebtn.SetActive(false);
                    }
                    if (!child)
                    {
                        transform.gameObject.GetComponent<LineRenderer>().enabled = true;
                        linerendere.SetPosition(0, HitInfo.point);
                        linerendere.SetPosition(1, HitInfo.point + new Vector3(0f, 0.05f, 0f));
                    }
                    else
                    {
                        linerendere.SetPosition(0, new Vector3(0f, 0f, 0f));
                        linerendere.SetPosition(1, new Vector3(0f, 0f, 0f));
                    }

                }
            }
            if (child && Bigpot.transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level< 0.7)
            {
                level = Bigpot.transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level;
                level += 0.09f * Time.deltaTime;
                level = Mathf.Clamp(level, 0f, 0.7f);
                // int BrouthQuantity = Mathf.RoundToInt(ChickenBroutequantitlty - (float)(level/4) * 1028.5f);
                ChickenBroutequantitlty = Mathf.RoundToInt(level* 357.4f);
                SaltAmount.Instance.SaltAmountWin.transform.GetChild(0).transform.GetChild(2).gameObject.GetComponent<Text>().text = ChickenBroutequantitlty.ToString() + "g";

                // transform.GetChild(3).transform.GetChild(0).transform.GetChild(2).gameObject.GetComponent<Text>().text = ChickenBroutequantitlty.ToString() + "g";
                Bigpot.transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level = level;
                if (childRotating)
                {
                    RotateObject();
                }
            }
            else
            {
                BrouteEffect.gameObject.SetActive(false);
            }
        }
        public void ONBroutebtnDown()
        {
            if (Bigpot.transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level < 0.7)
            {
                BrouteEffect.gameObject.SetActive(true);
            }
            child = true;
            rotation = transform.rotation;
            childRotating = true;

        }
        public void ONBroutebtnUp()
        {
           /* if (PlayerPrefs.GetInt("ChickenBroute", 1) == 1)
            {
                transform.gameObject.GetComponent<SpiceQuantity>().Quantity = 1000 - ChickenBroutequantitlty;
            }
            else if (PlayerPrefs.GetInt("ChickenBroute", 1) ==2)
            {
                transform.gameObject.GetComponent<SpiceQuantity>().Quantity = 750 - ChickenBroutequantitlty;
            } else if (PlayerPrefs.GetInt("ChickenBroute", 1) ==3)
            {
                transform.gameObject.GetComponent<SpiceQuantity>().Quantity = 500 - ChickenBroutequantitlty;
            } else if (PlayerPrefs.GetInt("ChickenBroute", 1) ==4)
            {
                transform.gameObject.GetComponent<SpiceQuantity>().Quantity = 250 - ChickenBroutequantitlty;
            }*/

            child = false;
            transform.rotation = rotation;
            BrouteEffect.gameObject.SetActive(false);
            childRotating = false;
        }
        public void YpositionsBtn()
        {
            Invoke("Ypositions", 1);
        
        }    public void Ypositions()
        {
            initialPosition = PickNDrop.yposition;
            print("position" + initialPosition);
        
        }
        private void RotateObject()
        {
            if (transform.rotation.eulerAngles.x < -120f)
            {
                transform.Rotate(Vector3.right, -Time.deltaTime * 30);
            }
            else
            {
                transform.rotation = Quaternion.Euler(-120f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                childRotating = false;
            }
           
        }
    }
}

