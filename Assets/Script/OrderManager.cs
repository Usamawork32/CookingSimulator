using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public GameObject AcceptOfferBtn;
    public AudioSource Audio;
    public List<AudioClip> Auidos;
    public GameObject Recipe;
    public GameObject Recepe1;
    public GameObject Recepe2;
    public GameObject Recepe3;
    public GameObject Recepe4;
    public GameObject BottomOrderNo;
    public GameObject BottomOrderNo1;
    public GameObject BottomOrderNo2;
    public GameObject BottomOrderNo3;
    public GameObject[] orderObjects;
    //public GameObject[] orderObjects1;
    public GameObject[] orderObjects2;
    public GameObject[] orderObjects3;// Array of order GameObjects
    public Text orderText;
    public Text orderText1;
    public Text orderText2;
    public Text orderText3;
    public Text timerText;
    public Text timerText1;
    public Text timerText2;
    public Text timerText3;
    int a = 0;
    private bool isOrderActive = false;
    private int currentOrder;
    private float orderInterval = 120f; // 2 minutes for the order to appear
    private float orderCompletionTime = 420f; // 7 minutes for order completion

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateOrder());
        orderText.text = "Time In New Order";
        orderText1.text = "Time In New Order";
        orderText2.text = "Time In New Order";
        orderText3.text = "Time In New Order";
        orderInterval = 120f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOrderActive)
        {
            orderInterval -= Time.deltaTime;
            if (orderInterval > 0)
            {
                int minutes = Mathf.FloorToInt(orderInterval / 60);
                int seconds = Mathf.FloorToInt(orderInterval % 60);


                // Update the timer text
                timerText.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
                timerText1.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
                timerText2.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
                timerText3.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
            }
        }
        if (isOrderActive)
        {
            orderCompletionTime -= Time.deltaTime;

            // Calculate minutes and seconds
            int minutes = Mathf.FloorToInt(orderCompletionTime / 60);
            int seconds = Mathf.FloorToInt(orderCompletionTime % 60);

            // Update the timer text
            timerText.text =  minutes.ToString("D2") + ":" + seconds.ToString("D2");
            timerText1.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
            timerText2.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
            timerText3.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");


            // Check if the order completion time has reached 0
            if (orderCompletionTime <= 0)
            {
                CompleteOrder();
            }
        }
    }

    IEnumerator GenerateOrder()
    {
        yield return new WaitForSeconds(orderInterval);

        currentOrder = Random.Range(0, orderObjects.Length);
        print("order  time");
        // Activate the order canvas and set the order panel active
        AcceptOfferBtn.SetActive(true);
        orderObjects[currentOrder].SetActive(true);
        orderObjects[currentOrder].transform.GetChild(4).gameObject.SetActive(false);
        //orderObjects1[currentOrder].SetActive(true);
        //orderObjects1[currentOrder].transform.GetChild(4).gameObject.SetActive(false);
        orderObjects2[currentOrder].SetActive(true);
        orderObjects2[currentOrder].transform.GetChild(4).gameObject.SetActive(false);
        orderObjects3[currentOrder].SetActive(true);
        orderObjects3[currentOrder].transform.GetChild(4).gameObject.SetActive(false);
        Audio.clip = Auidos[0];
        Audio.Play();
        BottomOrderNo.SetActive(true);
        BottomOrderNo1.SetActive(true);
        BottomOrderNo2.SetActive(true);
        BottomOrderNo3.SetActive(true);

        // Set the order completion time back to 7 minutes
        orderCompletionTime = 420f;
        a++;
        orderText.text = "Order: " + (a);
        orderText1.text = "Order: " + (a);
        orderText2.text = "Order: " + (a);
        orderText3.text = "Order: " + (a);

        // Set the flag to indicate that an order is active
        isOrderActive = true;
    }
    public void Acceptorder()
    {
        orderObjects[currentOrder].transform.GetChild(0).transform.gameObject.GetComponent<Digitaltime>().enabled = true;
       // orderObjects1[currentOrder].transform.GetChild(0).transform.gameObject.GetComponent<Digitaltime>().enabled = true;
        orderObjects2[currentOrder].transform.GetChild(0).transform.gameObject.GetComponent<Digitaltime>().enabled = true;
        orderObjects3[currentOrder].transform.GetChild(0).transform.gameObject.GetComponent<Digitaltime>().enabled = true;
        AcceptOfferBtn.SetActive(false);
        orderInterval = 560f;
        BottomOrderNo.SetActive(false);
        BottomOrderNo1.SetActive(false);
        BottomOrderNo2.SetActive(false);
        BottomOrderNo3.SetActive(false);
        Recepe4.SetActive(false);
        Recepe3.SetActive(false);
        Recepe2.SetActive(false);
        Recepe1.SetActive(false);
        Recipe.SetActive(true);
    }
    public void RecipeManger()
    {
        //orderObjects1[currentOrder].SetActive(false);
        if (currentOrder == 0)
        {
            Recepe1.SetActive(true);
        }
        if (currentOrder == 1)
        {
            Recepe2.SetActive(true);
        }
        if (currentOrder == 2)
        {
            Recepe3.SetActive(true);
        }
        if (currentOrder == 3)
        {
            Recepe4.SetActive(true);
        }
    }

    void CompleteOrder()
    {
        Recipe.SetActive(false);
        isOrderActive = false;
        orderObjects[currentOrder].transform.GetChild(4).gameObject.SetActive(true);
        //orderObjects1[currentOrder].transform.GetChild(4).gameObject.SetActive(true);
        orderObjects2[currentOrder].transform.GetChild(4).gameObject.SetActive(true);
        orderObjects3[currentOrder].transform.GetChild(4).gameObject.SetActive(true);
        Invoke("TimeOutOrder",30f);
        StartCoroutine(GenerateOrder());
    }
    public void TimeOutOrder()
    {
        orderObjects[currentOrder].SetActive(false);
        //orderObjects1[currentOrder].SetActive(false);
        orderObjects2[currentOrder].SetActive(false);
        orderObjects3[currentOrder].SetActive(false);
       
    }

}
