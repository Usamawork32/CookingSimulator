using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LiquidVolumeFX
{
    public class ChickenBrouth : MonoBehaviour
    {
        RaycastHit HitInfo;
        public LayerMask IgnoreMe;
        public GameObject Broutebtn;
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
        public float level = 0f;
        private bool childRotating = false;
        private void Start()
        {
            transform.gameObject.GetComponent<LineRenderer>().enabled = true;
            initialPosition = PickNDrop.yposition;
            Invoke("position", 1f);
            liquid = GetComponent<LiquidVolume>();
            //level = liquid.level;
            level = 0f;
        }
        public void position()
        {
            initialPosition = transform.position;
        }
        private void Update()
        {
            if (PickNDrop.Chickenbroute)
            {
                if (Physics.Raycast(BrouteEffectPOs.transform.position , BrouteEffectPOs.transform.forward, out HitInfo, 0.8f, IgnoreMe))
                {
                    Debug.DrawRay(BrouteEffectPOs.transform.position, BrouteEffectPOs.transform.forward * HitInfo.distance, Color.white);
                    if(HitInfo.transform.tag=="BigPot")
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
                if (Input.touchCount > 0)
                {
                    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    touchDeltaPosition = -touchDeltaPosition;

                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        Vector3 newPosition = new Vector3(
                            Mathf.Clamp(transform.position.x + touchDeltaPosition.x * 0.001f, initialPosition.x - 0.3f, initialPosition.x + 0.5f),
                            initialPosition.y,
                            Mathf.Clamp(transform.position.z + touchDeltaPosition.y * 0.001f, initialPosition.z - 0.3f, initialPosition.z + 0.5f));

                        transform.position = newPosition;
                    }
                }
                if (child)
                {
                    level = Bigpot.transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level;
                    level += 0.05f * Time.deltaTime;
                    level = Mathf.Clamp(level, 0f, 0.7f);
                    Bigpot.transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level = level;

                    /* float blendShapeWeight = Bigpot.transform.GetChild(0).transform.gameObject.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(blendShapeIndex);
                     blendShapeWeight -= blendShapeSpeed * Time.deltaTime;
                     blendShapeWeight = Mathf.Clamp(blendShapeWeight, 40f, 100f);
                     Bigpot.transform.GetChild(0).transform.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(blendShapeIndex, blendShapeWeight);*/

                    if (childRotating)
                    {
                        RotateObject();
                    }
                }
            
            }
        }
        public void ONBroutebtnDown()
        {
            child = true;
            BrouteEffect.gameObject.SetActive(true);
            rotation = transform.rotation;
            childRotating = true;
           /* Bigpot.transform.GetChild(0).transform.gameObject.SetActive(true);
            Bigpot.transform.GetChild(1).transform.gameObject.SetActive(false);*/

        }
        public void ONBroutebtnUp()
        {
            child = false;
            transform.rotation = rotation;
            BrouteEffect.gameObject.SetActive(false);
            childRotating = false;
            
          /*  float level = Bigpot.transform.GetChild(0).transform.gameObject.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(blendShapeIndex);
            print("level" + level);
            level = 1 - (level / 100);
            print("level"+level);
            Bigpot.transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level = level;
            Bigpot.transform.GetChild(1).transform.gameObject.SetActive(true);
            Bigpot.transform.GetChild(0).transform.gameObject.SetActive(false);*/

        }
        public void Ypositions()
        {
            initialPosition = PickNDrop.yposition;
            initialPosition = transform.position;
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

