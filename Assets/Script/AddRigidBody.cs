using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRigidBody : MonoBehaviour
{
    private void Update()
    {
        if(!transform.GetComponent<Rigidbody>() && transform.parent==null && PickNDrop.instance.RaycastControll)
        {
            transform.gameObject.AddComponent<Rigidbody>();
        }
    }
}
