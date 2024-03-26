using UnityEngine;
using System.Linq;
using System.Collections;

public class Potatofrier : MonoBehaviour
{
    public Material friedPotatoMaterial;
    public Material underfriedPotatoMaterial;
    public Material OverfriedPotatoMaterial;
    float elapsedtime = 0;

    private bool isFrying = false;

    private void OnTriggerStay(Collider other)
    {
        if (transform.childCount > 0 && PickNDrop.PotatoFrieBtn && PickNDrop.PotatoFrieoil)
        {
            if (other.gameObject.name== "OilPotato"||other.gameObject.name== "OilPotato1")
            {
                bool parentHasPotato = GetComponentsInChildren<Transform>().Any(child => child.CompareTag("potato") || child.CompareTag("potato1"));

                if (parentHasPotato)
                {
                    if (!isFrying)
                    {
                        isFrying = true;
                        StartCoroutine(FryPotato());
                        print("fry the potato");
                    }
                    elapsedtime += Time.deltaTime;
                    //print("  POtato time "+ elapsedtime);
                    if (elapsedtime>=400)
                    {
                        print("  POtato over Cooked");
                        foreach (Transform child in transform)
                        {
                            if (child.tag == "potato" || child.tag == "potato1")
                            {
                                if (child.GetComponent<Renderer>().material == friedPotatoMaterial)
                                {
                                    child.GetComponent<Renderer>().material = OverfriedPotatoMaterial;
                                }
                            }
                        }
                    }
                }
                else
                {
                    print("No potato in the fryer!");
                }


            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "OilPotato")
        {
            elapsedtime = 0;
        }
    }


   IEnumerator FryPotato()
    {
        yield return new WaitForSeconds(30);
        foreach (Transform child in transform)
        {
            if (child.tag == "potato" || child.tag == "potato1")
            {
                if (child.GetComponent<Renderer>().material != underfriedPotatoMaterial && child.GetComponent<Renderer>().material != friedPotatoMaterial && child.GetComponent<Renderer>().material != OverfriedPotatoMaterial)
                {
                    child.GetComponent<Renderer>().material = underfriedPotatoMaterial;
                    StartCoroutine(ChangeMat(child));
                    print("Potato is frying");
                }
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
              childRenderer.material.Lerp(originalMaterial, friedPotatoMaterial, lerpFactor);
              print("POtato fried" +elapsedTime);
               yield return new WaitForSeconds(1);
          }
          isFrying = false;
          print("POtato fried");
          childRenderer.material = friedPotatoMaterial;
          child.GetComponent<Renderer>().material = friedPotatoMaterial;
          StopCoroutine(ChangeMat(child));
      }

}
