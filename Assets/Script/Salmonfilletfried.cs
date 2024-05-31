using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Salmonfilletfried : MonoBehaviour
{
    public Material friedSalmonMaterial;
    public Material underfriedSalmonMaterial;
    public Material OverfriedSalmonMaterial;
    float elapsedtime1 = 0;
    float TriggerExittCount = 0;
    private bool isFrying = false;
    private bool isTrigger = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SalmonFillet")
        {
            isFrying = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (transform.childCount > 1 && transform.GetChild(1).tag== "SalmonFillet" && transform.GetChild(0).gameObject.activeSelf)
        {
           
            bool parentHasSalmonFillet = GetComponentsInChildren<Transform>().Any(child => child.CompareTag("SalmonFillet"));
            if (parentHasSalmonFillet)
            {
                if (other.gameObject.tag == "burner" && other.gameObject.name == "burner 1")
                {
                    if (!isFrying && PickNDrop.burner1)
                    {
                        isFrying = true;
                        StartCoroutine(Fryfish());
                    }
                    if (PickNDrop.burner1 && isTrigger)
                    {
                        elapsedtime1 += Time.deltaTime;
                        if (elapsedtime1 >= 400)
                        {
                            foreach (Transform child in transform)
                            {
                                if (child.tag == "SalmonFillet" && child.GetComponent<Renderer>().material == friedSalmonMaterial)
                                {
                                    child.GetComponent<Renderer>().material = OverfriedSalmonMaterial;
                                    
                                }
                            }
                        }
                    }

                }
                else if (other.gameObject.tag == "burner" && other.gameObject.name == "burner 2")
                {
                    if (!isFrying && PickNDrop.burner2)
                    {
                        isFrying = true;
                        StartCoroutine(Fryfish());
                    }
                    if (PickNDrop.burner2 && isTrigger)
                    {
                        elapsedtime1 += Time.deltaTime;
                        if (elapsedtime1 >= 400)
                        {
                            foreach (Transform child in transform)
                            {
                                if (child.tag == "SalmonFillet" && child.GetComponent<Renderer>().material == friedSalmonMaterial)
                                {
                                    child.GetComponent<Renderer>().material = OverfriedSalmonMaterial;
                                    
                                }
                            }
                        }
                    }

                }
                else if (other.gameObject.tag == "burner" && other.gameObject.name == "burner 3")
                {
                    if (!isFrying && PickNDrop.burner3)
                    {
                        print("fry the  Salmon");
                        isFrying = true;
                        StartCoroutine(Fryfish());
                    }
                    if (PickNDrop.burner3 && isTrigger)
                    {
                        elapsedtime1 += Time.deltaTime;
                        if (elapsedtime1 >= 400)
                        {
                            foreach (Transform child in transform)
                            {
                                if (child.tag == "SalmonFillet" && child.GetComponent<Renderer>().material == friedSalmonMaterial)
                                {
                                    child.GetComponent<Renderer>().material = OverfriedSalmonMaterial;
                                    
                                }
                            }
                        }
                    }

                }
                else if (other.gameObject.tag == "burner" && other.gameObject.name == "burner 4")
                {
                    if (!isFrying && PickNDrop.burner4)
                    {
                        print("fry the  Salmon");
                        isFrying = true;
                        StartCoroutine(Fryfish());
                    }
                    if(PickNDrop.burner4 && isTrigger )
                    {
                        elapsedtime1 += Time.deltaTime;
                        if (elapsedtime1 >= 400)
                        {
                            foreach (Transform child in transform)
                            {
                                if (child.tag == "SalmonFillet"&& child.GetComponent<Renderer>().material== friedSalmonMaterial)
                                {
                                    child.GetComponent<Renderer>().material = OverfriedSalmonMaterial;
;
                                }
                            }
                        }
                    }

                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "burner 4" || other.gameObject.name == "burner 4" || other.gameObject.name == "burner 4" || other.gameObject.name == "burner 4")
        {
            isTrigger = false;
           
        }
    }

    private void Update()
    {
        if (!isTrigger)
        {
            TriggerExittCount += Time.deltaTime;
            if(TriggerExittCount>220)
            {
                isTrigger = true;
                elapsedtime1 = 0;
            }

        }
    }

    IEnumerator Fryfish()
    {
        yield return new WaitForSeconds(60f);
        foreach (Transform child in transform)
        {
            if (child.tag == "SalmonFillet")
            {
                child.GetComponent<Renderer>().material = underfriedSalmonMaterial;
                StartCoroutine(ChangeMat(child));
            }

        }
        yield return null;
    }

    private IEnumerator ChangeMat(Transform child)
    {
        Renderer childRenderer = child.GetComponent<Renderer>();
        Material originalMaterial = childRenderer.material;
        float elapsedTime = 0f;
        float duration = 1f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float lerpFactor = elapsedTime / duration;
            yield return new WaitForSeconds(1);
        }
        childRenderer.material = friedSalmonMaterial;
        child.GetComponent<Renderer>().material = friedSalmonMaterial;
        isFrying = false;
        isTrigger = true;
        elapsedtime1 = 0;
        if(transform.GetChild(0).transform.name=="Cube")
        {
            transform.GetChild(0).transform.gameObject.SetActive(false);
        }
    }
}
