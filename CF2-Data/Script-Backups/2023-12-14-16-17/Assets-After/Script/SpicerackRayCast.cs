using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpicerackRayCast : MonoBehaviour
{
    RaycastHit HitInfo;
    public AudioSource Audio;
    public List<AudioClip> Auidos;
    public LineRenderer linerendere;
    public Transform transforms;
    public static SpicerackRayCast instance;
    private Transform parentObject;
    public float touchSensitivity = 0.1f;
    private Vector3 initialPosition;
    public GameObject Masala;
    public float moveSpeed = 4f;
    public float delayTime = 0.5f;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        parentObject = transform.parent;
        initialPosition = PickNDrop.yposition;
    }
    void Update()
    {

        if (Physics.Raycast(transform.position, transform.up, out HitInfo, 1))
        {
            Debug.DrawRay(transform.position, transform.up * HitInfo.distance, Color.white);
            linerendere.SetPosition(0, HitInfo.point);
            linerendere.SetPosition(1, HitInfo.point + new Vector3(0, 0.05f, 0));
        }
        if (ControlFreak2.CF2Input.touchCount > 0)
        {  
            Vector2 touchDeltaPosition = ControlFreak2.CF2Input.GetTouch(0).deltaPosition;
            touchDeltaPosition = -touchDeltaPosition;

            Vector3 newPosition = new Vector3(
                  Mathf.Clamp(parentObject.position.x + touchDeltaPosition.x * 0.001f, initialPosition.x - 0.25f, initialPosition.x + 0.25f),
                  initialPosition.y,
                  Mathf.Clamp(parentObject.position.z + touchDeltaPosition.y * 0.001f, initialPosition.z - 0.25f, initialPosition.z + 0.25f));

            parentObject.position = newPosition;
           
        }

    }
   public void PoreSpice()
    {
        StartCoroutine(PoreSpiceCoroutine());
        Audio.clip = Auidos[0];
        Audio.Play();

    }
    private IEnumerator PoreSpiceCoroutine()
    {
        // Get the starting position
        Vector3 startPosition = transforms.position;

        // Move up to the new position
        Vector3 targetPosition = startPosition + new Vector3(0, -0.03f, 0);
        transforms.position = Vector3.Lerp(startPosition, targetPosition, 2 * Time.deltaTime);
        print(" before" + transforms.position);
        // Wait for the specified delay time
        yield return new WaitForSeconds(delayTime);
        Instantiate(Masala ,transform.position, Quaternion.identity);

        transforms.position = startPosition;
         print("After" + transforms.position);
    }

}
