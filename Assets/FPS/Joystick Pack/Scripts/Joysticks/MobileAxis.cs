using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MobileAxis : MonoBehaviour
{
    // Start is called before the first frame update

    public FixedJoystick MovJoyStick;
    public FixedButton jumpButton;
    public FixedTouchField TouchField;

    //public GameObject fps;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var fps = GetComponent<FirstPersonController>();
        fps.RunAxis = MovJoyStick.Direction;
        fps.jumpAxis = jumpButton.Pressed;
        fps.m_MouseLook.LookAxis = TouchField.TouchDist;
    }
}
