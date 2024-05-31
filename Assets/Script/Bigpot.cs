using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LiquidVolumeFX
{
    public class Bigpot : MonoBehaviour
    {
        RaycastHit HitInfo;
        private GameObject bowl;
        int tomato=0;    
        private Vector3 initialPosition;
        public int blendShapeIndex = 0;
        public float blendShapeSpeed = 20f;
        public LineRenderer linerendere;
        bool newcolour = true;
        bool potatoinpot = true;

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "burner" && other.gameObject.name == "burner 1" )
            {
                if (PickNDrop.burner1)
                {
                    foreach (Transform child in transform)
                    {
                        if (child.tag == "tomato")
                        {
                            if (newcolour  && transform.GetChild(1).gameObject.GetComponent<LiquidVolume>().level >= 0.1f)
                            {
                                Invoke("SoupColour", 30);
                                newcolour = false;
                            }
                        }
                        if (child.tag== "potato")
                        {
                            print("dscds1");
                            SkinnedMeshRenderer skinnedMeshRenderer = transform.GetComponentInChildren<SkinnedMeshRenderer>();
                            if (skinnedMeshRenderer != null)
                            {
                                // Check if the key value of the first child's SkinnedMeshRenderer is less than 90
                                if (skinnedMeshRenderer.bones.Length < 90)
                                {
                                    if (potatoinpot)
                                    {
                                        Invoke("BoilPotato", 40);
                                        potatoinpot = false;
                                    }
                                }
                            }
                        }
                    }

                }
            }
            else if (other.gameObject.tag == "burner"  && other.gameObject.name == "burner 2")
            { if (PickNDrop.burner2)
                {
                    foreach (Transform child in transform)
                    {
                        if (child.tag == "tomato")
                        {
         
                            if (newcolour && transform.GetChild(1).gameObject.GetComponent<LiquidVolume>().level >= 0.1f)
                            {
                                Invoke("SoupColour", 30);
                                newcolour = false;
                            }
                        }
                        if (child.tag == "potato")
                        {
                            SkinnedMeshRenderer skinnedMeshRenderer = transform.GetComponentInChildren<SkinnedMeshRenderer>();
                            if (skinnedMeshRenderer != null)
                            {
                                // Check if the key value of the first child's SkinnedMeshRenderer is less than 90
                                if (skinnedMeshRenderer.bones.Length < 90)
                                {
                                    print("Boil The Potato");
                                    if (potatoinpot)
                                    {
                                        Invoke("SoupColour", 40);
                                        potatoinpot = false;
                                    }
                                }
                            }
                        }
                    }
                } }
            else if (other.gameObject.tag == "burner" && other.gameObject.name == "burner 3")
            { if (PickNDrop.burner3)
                {
                    foreach (Transform child in transform)
                    {
                        if (child.tag == "tomato")
                        {
                       
                            if (newcolour && transform.GetChild(1).gameObject.GetComponent<LiquidVolume>().level >= 0.1f)
                            {
                                Invoke("SoupColour", 30);
                                newcolour = false;
                            }
                        }
                        if (child.tag == "potato")
                        {
                            SkinnedMeshRenderer skinnedMeshRenderer = transform.GetComponentInChildren<SkinnedMeshRenderer>();
                            if (skinnedMeshRenderer != null)
                            {
                                // Check if the key value of the first child's SkinnedMeshRenderer is less than 90
                                if (skinnedMeshRenderer.bones.Length < 90)
                                {
                                    print("Boil The Potato");
                                    if (potatoinpot)
                                    {
                                        Invoke("SoupColour", 40);
                                        potatoinpot = false;
                                    }
                                }
                            }
                        }
                    }
                } }
            else if (other.gameObject.tag == "burner" && other.gameObject.name == "burner 4")
            {
                if (PickNDrop.burner4)
                {
                    foreach (Transform child in transform)
                    {
                        if (child.tag == "tomato")
                        {
                            if (newcolour && transform.GetChild(1).gameObject.GetComponent<LiquidVolume>().level >= 0.1f)
                            {
                                Invoke("SoupColour", 30);
                                newcolour = false;
                            }
                        }
                        if (child.tag == "potato")
                        {
                            SkinnedMeshRenderer skinnedMeshRenderer = transform.GetComponentInChildren<SkinnedMeshRenderer>();
                            if (skinnedMeshRenderer != null)
                            {
                                // Check if the key value of the first child's SkinnedMeshRenderer is less than 90
                                if (skinnedMeshRenderer.bones.Length < 90)
                                {
                                    print("Boil The Potato");
                                    if (potatoinpot)
                                    {
                                        Invoke("SoupColour", 40);
                                        potatoinpot = false;
                                    }
                                }
                            }
                        }
                    }
                } }
        }
        public void BoilPotato()
        {
            foreach (Transform child in transform)
            {
                if (child.tag == "potato")
                {
                    child.name = "BoiledPotato";
                    child.tag = "potato1";
                    potatoinpot = true;
                }
            }
        }
        public void SoupColour()
        {
            if (transform.GetChild(1))
            {
                transform.GetChild(1).GetComponent<LiquidVolume>().liquidColor1 = new Color(0.85f, 0.46f, 0.52f, 1f);
            }
            foreach(Transform potato in transform)
            {
                if(potato.gameObject.tag=="tomato")
                {
                    PickNDrop.instance.InstantiateObject.Remove(potato.gameObject);
                    Destroy(potato.gameObject);
                }
            }
            newcolour = true;
            tomato = 0;
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
                    if (transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level>0f)
                    {
                        print("bowl");
                        bowl = HitInfo.transform.gameObject;
                        transform.GetChild(2).transform.gameObject.SetActive(true);
                        float Bowllevel = transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level;
                        Bowllevel -= 0.1f * Time.deltaTime;
                        Bowllevel = Mathf.Clamp(Bowllevel, 0f, 1f);
                        transform.GetChild(1).GetComponent<LiquidVolume>().level = Bowllevel;

                        bowl.transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().liquidColor1 = transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().liquidColor1;
                        float level = bowl.transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level;
                        level += 0.3f * Time.deltaTime;
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
                        transform.GetChild(3).transform.gameObject.SetActive(true);
                        bowl = HitInfo.transform.gameObject;
                        float Bowllevel = transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level;
                        Bowllevel -= 0.1f * Time.deltaTime;
                        Bowllevel = Mathf.Clamp(Bowllevel, 0f, 0.7f);
                        transform.GetChild(1).GetComponent<LiquidVolume>().level = Bowllevel;

                        bowl.transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().liquidColor1 = transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().liquidColor1;
                        float level = bowl.transform.GetChild(1).transform.gameObject.GetComponent<LiquidVolume>().level;
                        level += 0.25f * Time.deltaTime;
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
        private void OnDisable()
        {
            transform.GetChild(3).transform.gameObject.SetActive(false);
            transform.GetChild(2).transform.gameObject.SetActive(false);
        }
    }
}

