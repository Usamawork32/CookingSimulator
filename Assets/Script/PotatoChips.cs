using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoChips : MonoBehaviour
{
    public GameObject CutPotatoPrefab;
    private  GameObject CutPotato0;
    public  List<GameObject> collidedGameobject;
    public Transform TransformPOS;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("potato"))
        {
            GameObject colidedGameobject = other.transform.gameObject;
            if (CutPotato0 == null)
            {
                CutPotato0 = colidedGameobject;
                collidedGameobject.Add(colidedGameobject);
               
            }
            else if (CutPotato0.name != colidedGameobject.name)
            {
                CutPotato0 = colidedGameobject;
                collidedGameobject.Add(colidedGameobject);
            }
            print("Colide object" + colidedGameobject.name);
            print("CutPotto object" + CutPotato0.name);
        }
    }
    public void CutPotato()
    {
        List<GameObject> objectsToRemove = new List<GameObject>();

        // Iterate through the collidedGameobject list
        foreach (GameObject obj in collidedGameobject)
        {

            obj.SetActive(false);
            if (PickNDrop.instance.InstantiateObject.Contains(obj))
            {
                PickNDrop.instance.InstantiateObject.Remove(obj);
            }
            GameObject chips=Instantiate(CutPotatoPrefab, TransformPOS.position, Quaternion.identity);
            foreach (Transform child in chips.transform)
            {
                PickNDrop.instance.InstantiateObject.Add( child.gameObject);
            }
            objectsToRemove.Add(obj);
        }

        // Remove the objects after the iteration is complete
        foreach (GameObject objToRemove in objectsToRemove)
        {
            collidedGameobject.Remove(objToRemove);
        }
    }

}
