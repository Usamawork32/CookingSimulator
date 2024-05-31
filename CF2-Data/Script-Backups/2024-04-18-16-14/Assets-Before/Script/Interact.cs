using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    RaycastHit HitInfo;
    public LayerMask IgnoreMe;
    public LineRenderer linerendere;
    public Vector3 initialPosition;

    private void Start()
    {
        Invoke("position", 1f);


    }
    public void position()
    {
        initialPosition = transform.position;
        print(" initial positon2" + initialPosition);
    }


    void Update()
    {
        if (Physics.Raycast(transform.position + new Vector3(0, 0.1f, 0f), transform.forward, out HitInfo, 0.8f))
        {
            Debug.DrawRay(transform.position + new Vector3(0, 0.1f , 0), transform.forward * HitInfo.distance, Color.black);
            linerendere.SetPosition(0, HitInfo.point);
            linerendere.SetPosition(1, HitInfo.point + new Vector3(0, 0.1f, 0f));

        }
        else if (Physics.Raycast(transform.position + new Vector3(0, 0.1f, 0f), -transform.forward, out HitInfo, 0.8f))
        {
            Debug.DrawRay(transform.position + new Vector3(0, 0.1f, 0f), -transform.forward * HitInfo.distance, Color.blue);
            linerendere.SetPosition(0, HitInfo.point);
            linerendere.SetPosition(1, HitInfo.point + new Vector3(0, 0.1f, 0));
        }
        else 
        {
            linerendere.SetPosition(0,  new Vector3(0, 0, 0));
            linerendere.SetPosition(1, new Vector3(0, 0, 0));
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            // Check if the touch has moved
            if (touch.phase == TouchPhase.Moved)
            {
                // Calculate the delta position of the touch
                Vector2 touchDeltaPosition = touch.deltaPosition;
            touchDeltaPosition = -touchDeltaPosition;

                // Calculate the new position based on touch input
                Vector3 newPosition = new Vector3(
                    Mathf.Clamp(transform.position.x + touchDeltaPosition.x * 0.001f, initialPosition.x - 0.25f, initialPosition.x + 0.25f),
                    initialPosition.y,
                    Mathf.Clamp(transform.position.z + touchDeltaPosition.y * 0.001f, initialPosition.z - 0.25f, initialPosition.z + 0.25f)
                );

                // Set the object's position to the new position
                transform.position = newPosition;
            }
        }

    }
}
