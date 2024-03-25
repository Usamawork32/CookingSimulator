using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiceQuantity : MonoBehaviour
{
    public static SpiceQuantity Instance;
    private void Awake()
    {
        Instance = this;
    }
    public int Quantity=80;
}
