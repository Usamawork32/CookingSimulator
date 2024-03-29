using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLookAt : MonoBehaviour
{
    public Transform Player;

    void Update()
    {
        // Ensure the canvas faces the player's position
        if (Player != null)
            transform.LookAt(Player);
        transform.Rotate(0, 180, 0);
    }
}
