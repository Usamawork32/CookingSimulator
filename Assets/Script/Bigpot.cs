using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LiquidVolumeFX
{
    public class Bigpot : MonoBehaviour
    {
        RaycastHit HitInfo;
        public LayerMask IgnoreMe;
        private GameObject bowl;
        int tomato=0;    
        private Vector3 initialPosition;
        public int blendShapeIndex = 0;
        public float blendShapeSpeed = 20f;
        public LineRenderer linerendere;
        bool newcolour = true;
        private void OnCollisionStay(Collision collision)
        {
            if (collision.transform.gameObject.CompareTag("tomato"))
            {
                tomato++;

                if(tomato>3)
                {
                    if (newcolour)
                    {
                        Invoke("SoupColour", 30);
                        newcolour = false;
                    }
                }
                
            }
           
        }
        public void SoupColour()
        {
            transform.GetChild(1).GetComponent<LiquidVolume>().liquidColor1 = new Color(0.85f, 0.46f, 0.52f, 1f);
            newcolour = true;
        }
        private void Update()
        {
            if (Physics.Raycast(transform.position, transform.forward, out HitInfo, 1f))
            {
                Debug.DrawRay(transform.position, transform.forward * HitInfo.distance, Color.red);
                linerendere.SetPosition(0, HitInfo.point);
                linerendere.SetPosition(1, HitInfo.point + new Vector3(0f, 0.05f, 0));
                if (HitInfo.transform.tag == "Small Bowl , Basic" || HitInfo.transform.tag == "Large Bowl , Basic")
                {
                    if (transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level>0.2f)
                    {
                        print("bowl");
                        bowl = HitInfo.transform.gameObject;
                        transform.GetChild(2).transform.gameObject.SetActive(true);
                        float Bowllevel = transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level;
                        Bowllevel -= 0.1f * Time.deltaTime;
                        Bowllevel = Mathf.Clamp(Bowllevel, 0f, 0.8f);
                        transform.GetChild(1).GetComponent<LiquidVolume>().level = Bowllevel;

                        bowl.transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().liquidColor1 = transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().liquidColor1;
                        float level = bowl.transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level;
                        level += 0.5f * Time.deltaTime;
                        level = Mathf.Clamp(level, 0f, 0.7f);
                        bowl.transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level = level;
                    }
                    else
                    {
                        transform.GetChild(2).transform.gameObject.SetActive(false);
                    }
                }

            }
            else if (Physics.Raycast(transform.position, -transform.forward, out HitInfo, 1f))
            {
                Debug.DrawRay(transform.position, -transform.forward * HitInfo.distance, Color.white);
                linerendere.SetPosition(0, HitInfo.point);
                linerendere.SetPosition(1, HitInfo.point + new Vector3(0f, 0.05f, 0));
                if (HitInfo.transform.tag == "Small Bowl , Basic" || HitInfo.transform.tag == "Large Bowl , Basic")
                {
                    if (transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level > 0f)
                    {
                        print("bowl");
                        transform.GetChild(3).transform.gameObject.SetActive(true);
                        bowl = HitInfo.transform.gameObject;
                        float Bowllevel = transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level;
                        Bowllevel -= 0.1f * Time.deltaTime;
                        Bowllevel = Mathf.Clamp(Bowllevel, 0f, 0.8f);
                        transform.GetChild(1).GetComponent<LiquidVolume>().level = Bowllevel;

                        bowl.transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().liquidColor1 = transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().liquidColor1;
                        float level = bowl.transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level;
                        level += 0.5f * Time.deltaTime;
                        level = Mathf.Clamp(level, 0f, 0.7f);
                        bowl.transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level = level;

                    }
                    else
                    {
                        transform.GetChild(3).transform.gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                linerendere.SetPosition(0, new Vector3(0, 0, 0));
                linerendere.SetPosition(1, new Vector3(0, 0, 0));
                transform.GetChild(3).transform.gameObject.SetActive(false);
                transform.GetChild(2).transform.gameObject.SetActive(false);
            }
          
        }

    }
}
