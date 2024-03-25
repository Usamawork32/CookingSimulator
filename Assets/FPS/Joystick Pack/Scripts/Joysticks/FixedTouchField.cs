using UnityEngine;
using UnityEngine.EventSystems;

public class FixedTouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   // [HideInInspector]
    public Vector2 TouchDist;
    [HideInInspector]
    public Vector2 PointerOld;
    [HideInInspector]
    protected int PointerId;
    [HideInInspector]
    public bool Pressed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Pressed)
        {
            if (PointerId >= 0 && PointerId < ControlFreak2.CF2Input.touches.Length)
            {
                TouchDist = ControlFreak2.CF2Input.touches[PointerId].position - PointerOld;
                PointerOld = ControlFreak2.CF2Input.touches[PointerId].position;
            }
            else
            {
                TouchDist = new Vector2(ControlFreak2.CF2Input.mousePosition.x, ControlFreak2.CF2Input.mousePosition.y) - PointerOld;
                PointerOld = ControlFreak2.CF2Input.mousePosition;
            }
        }
        else
        {
            TouchDist = new Vector2();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        PointerId = eventData.pointerId;
        PointerOld = eventData.position;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
    
}