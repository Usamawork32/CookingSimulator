using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpicerackRayCast : MonoBehaviour
{
    RaycastHit HitInfo;
    public AudioSource Audio;
    public List<AudioClip> Auidos;
    public LineRenderer linerendere;
    public Transform transforms;
    public static int SpiceInt = 0;
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
    private void OnEnable()
    {
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
   public void PoreSpice(int b)
    {
        StartCoroutine(PoreSpiceCoroutine(b));
        Audio.clip = Auidos[0];
        Audio.Play();
    }

    private IEnumerator PoreSpiceCoroutine(int a)
    {
        if (transform.parent.transform.gameObject.GetComponent<SpiceQuantity>().Quantity > 0)
        {
            Vector3 startPosition = transforms.position;
            Vector3 targetPosition = startPosition + new Vector3(0, -0.03f, 0);
            transforms.position = Vector3.Lerp(startPosition, targetPosition, 2 * Time.deltaTime);
            transform.parent.transform.gameObject.GetComponent<SpiceQuantity>().Quantity = transform.parent.transform.gameObject.GetComponent<SpiceQuantity>().Quantity - 1;
            transform.parent.transform.GetChild(1).gameObject.SetActive(true);
            yield return new WaitForSeconds(delayTime);
            GameObject masala = Instantiate(Masala, transform.position, Quaternion.identity);
            SpiceInt++;
            if (a == 1)
            {
                masala.tag = "Dril Dried";
            }
            else if (a == 2)
            {
                masala.tag = "Salt.";
            }
            else if (a == 3)
            {
                masala.tag = "BlackPepper";
            }
            else if (a == 4)
            {
                masala.tag = "Horseria";
            }
            else if (a == 5)
            {
                masala.tag = "Thyme Dried";
            }
            else if (a == 6)
            {
                masala.tag = "Cayenna Pepper";
            }
            transforms.position = startPosition;
            transform.parent.transform.GetChild(1).gameObject.SetActive(false);
            transform.parent.transform.GetChild(2).transform.GetChild(0).transform.GetChild(2).gameObject.GetComponent<Text>().text = SpiceInt.ToString() + "g";

        }
    }

}
