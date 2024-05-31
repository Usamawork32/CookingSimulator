using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OulileController : MonoBehaviour
{
    public HashSet<GameObject> outlines = new HashSet<GameObject>();
    public LayerMask Mask;
    public float interctDist = 2;
    GameObject interect;

    void Update()
    {
        interctDist = 5;
        RemoveOutline();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit,interctDist,Mask))
        {
            interect = hit.collider.gameObject;
            if(hit.collider.gameObject.GetComponent<Outline>())
            {
                if (!hit.collider.gameObject.GetComponent<Outline>().enabled)
                {
                    hit.collider.gameObject.GetComponent<Outline>().enabled = true;
                        outlines.Add(hit.collider.gameObject);
                }
            }
            
        }
        else
        {
            interect = null;
        }
    }

    void RemoveOutline()
    {
        if (outlines.Count == 0)
            return;

        List<GameObject> outlinesToRemove = new List<GameObject>();

        foreach (GameObject o in outlines)
        {
            outlinesToRemove.Add(o);
        }

        foreach (GameObject o in outlinesToRemove)
        {
                 if (o != null)
                if (interect == null)
                {
                    outlines.Remove(o);
                    o.GetComponent<Outline>().enabled = false;
                }
                else if (o != interect)
                {
                    outlines.Remove(o);
                    o.GetComponent<Outline>().enabled = false;
                }
        }
    }
}
