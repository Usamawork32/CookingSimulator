using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance;
    public GameObject AcceptOfferBtn;
    public AudioSource Audio;
    public GameObject OrderText;
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
    public GameObject[] orderObjects2;
    public GameObject[] orderObjects3;// Array of order GameObjects for LCD's
    public Text orderText;
    public Text orderText1;
    public Text orderText2;
    public Text orderText3;
    public Text timerText;
    public Text timerText1;
    public Text timerText2;
    public Text timerText3;
    int a = 0;
    private bool isOrderActive = true,OrderAccepted=false,TimeOut=true;
    public int currentOrder=6;
    public int currentOrder2=6;
    public int cuhickenBroute=0;
    private float orderInterval = 120f; // 2 minutes for the order to appear
    private float orderCompletionTime = 420f; // 7 minutes for order completion

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        orderText.text = "Time In New Order";
        orderText1.text = "Time In New Order";
        orderText2.text = "Time In New Order";
        orderText3.text = "Time In New Order";
        orderInterval = 120f;
        currentOrder = 6;
        a = 0;
    }
    public void startCoroutine()
    {
        orderCoroutine = StartCoroutine(GenerateOrder());
       // StartCoroutine(GenerateOrder());
        isOrderActive = false;
        TimeOut = true;
    }
    float    pauseTime=0;
    bool pauseBool = true;
    private Coroutine orderCoroutine;
    public void PauseMenu()
    {

        Time.timeScale = 0;
       /* pauseBool = false;
        pauseTime = orderInterval;
        Digitaltime.DigitalTime = false;
        if (orderCoroutine != null)
        {
            StopCoroutine(orderCoroutine);
            orderCoroutine = null;
        }*/
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
       /* pauseBool = true;
        Digitaltime.DigitalTime = true;
        orderInterval = pauseTime;
        pauseTime = 0;
        if (!isOrderActive)
        {
            orderCoroutine = StartCoroutine(GenerateOrder());
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        if (pauseBool)
        {
            if (!isOrderActive && TimeOut)
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
                timerText.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
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
    }
    int lastOrderNo = -1; // Variable to hold the last generated order number
    public int GenerateOrderNO()
    {
        int orderNo;
        do
        {
            orderNo = Random.Range(0, 4);
        } while (orderNo == lastOrderNo);
        lastOrderNo = orderNo; // Update lastOrderNo with the new order number
        return orderNo;
    }
    IEnumerator GenerateOrder()
    {
        yield return new WaitForSeconds(orderInterval);
        currentOrder = GenerateOrderNO();
        print("order time");
        // Activate the order canvas and set the order panel active
        AcceptOfferBtn.SetActive(true);
        orderObjects[currentOrder].SetActive(true);
        orderObjects[currentOrder].transform.GetChild(4).gameObject.SetActive(false);
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
        orderCompletionTime = 60f;
        a++;
        orderText.text = "Accept The Order: ";
        orderText1.text = "Accept The Order: ";
        orderText2.text = "Accept The Order: ";
        orderText3.text = "Accept The Order: ";
       
        // Set the flag to indicate that an order is active
        isOrderActive = true;
    }
    public void Acceptorder()
    {
        currentOrder2=currentOrder;
        orderObjects[currentOrder].transform.GetChild(0).transform.gameObject.GetComponent<Digitaltime>().enabled = true;
        orderObjects2[currentOrder].transform.GetChild(0).transform.gameObject.GetComponent<Digitaltime>().enabled = true;
        orderObjects3[currentOrder].transform.GetChild(0).transform.gameObject.GetComponent<Digitaltime>().enabled = true;
        AcceptOfferBtn.SetActive(false);
        orderCompletionTime = 420;
        OrderAccepted = true;
        BottomOrderNo.SetActive(false);
        BottomOrderNo1.SetActive(false);
        BottomOrderNo2.SetActive(false);
        BottomOrderNo3.SetActive(false);
        Recepe4.SetActive(false);
        Recepe3.SetActive(false);
        Recepe2.SetActive(false);
        Recepe1.SetActive(false);
        Recipe.SetActive(true);
        // ChickenBroute value controll
        if (currentOrder == 0)
        {
            cuhickenBroute++;
            PlayerPrefs.SetInt("ChickenBroute", cuhickenBroute);
        }
       
    }
    public void RecipeManger()
    {
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
        Recipe.SetActive(false);
    }

    void CompleteOrder()
    {
        if (OrderAccepted)
        {
            Recipe.SetActive(false);
            isOrderActive = false;
            TimeOut = false;
            orderInterval = 120f;
            AcceptOfferBtn.SetActive(false);
            Recipe.SetActive(false);
            orderObjects[currentOrder].transform.GetChild(4).gameObject.SetActive(true);
            orderObjects2[currentOrder].transform.GetChild(4).gameObject.SetActive(true);
            orderObjects3[currentOrder].transform.GetChild(4).gameObject.SetActive(true);
            BottomOrderNo.SetActive(false);
            BottomOrderNo1.SetActive(false);
            BottomOrderNo2.SetActive(false);
            BottomOrderNo3.SetActive(false);
            Invoke("TimeOutOrder", 30f);
        }
        else
        {
            orderObjects[currentOrder].SetActive(false);
            orderObjects2[currentOrder].SetActive(false);
            orderObjects3[currentOrder].SetActive(false);
            isOrderActive = false;
            AcceptOfferBtn.SetActive(false);
            orderInterval = 120; Recipe.SetActive(false);
            StartCoroutine(GenerateOrder());
            orderText.text = "Time In New Order";
            orderText1.text = "Time In New Order";
            orderText2.text = "Time In New Order";
            orderText3.text = "Time In New Order";
            WaitForOrder();
        }
    }
    public void TimeOutOrder()
    {
        if (orderObjects.Length >= currentOrder)
        {
            orderObjects[currentOrder].transform.GetChild(4).gameObject.SetActive(false);
            orderObjects2[currentOrder].transform.GetChild(4).gameObject.SetActive(false);
            orderObjects3[currentOrder].transform.GetChild(4).gameObject.SetActive(false);
        }
        WaitForOrder();
        TimeOut = true; isOrderActive = false;
        orderInterval = 120f;
        StartCoroutine(GenerateOrder());
        orderText.text = "Time In New Order";
        orderText1.text = "Time In New Order";
        orderText2.text = "Time In New Order";
        orderText3.text = "Time In New Order";
        BottomOrderNo.SetActive(true);
        BottomOrderNo1.SetActive(true);
        BottomOrderNo2.SetActive(true);
        BottomOrderNo3.SetActive(true);
        Recepe4.SetActive(false);
        Recepe3.SetActive(false);
        Recepe2.SetActive(false);
        Recepe1.SetActive(false);
        currentOrder = 6;
    }
    public void OrderCompleteOnTime(int a)
    {
        // Activate order Pic And Order Nanme 
        if (currentOrder == 0)
        {
            OrderText.transform.GetChild(0).transform.GetChild(0).transform.gameObject.SetActive(true);
        }
        else if (currentOrder == 1)
        {
            OrderText.transform.GetChild(0).transform.GetChild(1).transform.gameObject.SetActive(true);
        }
        else if (currentOrder == 2)
        {
            OrderText.transform.GetChild(0).transform.GetChild(2).transform.gameObject.SetActive(true);
        }
        else if (currentOrder == 3)
        {
            OrderText.transform.GetChild(0).transform.GetChild(3).transform.gameObject.SetActive(true);
        }

        // Give rating to the dish 
        if(a==1)
        {
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.gameObject.SetActive(true);
        }
        else if (a == 2)
        {
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.gameObject.SetActive(true);
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(1).transform.GetChild(0).transform.gameObject.SetActive(true);
        }
        else if (a == 3)
        {
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.gameObject.SetActive(true);
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(1).transform.GetChild(0).transform.gameObject.SetActive(true);
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(2).transform.GetChild(0).transform.gameObject.SetActive(true);
        }
        else if (a == 4)
        {
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.gameObject.SetActive(true);
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(1).transform.GetChild(0).transform.gameObject.SetActive(true);
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(2).transform.GetChild(0).transform.gameObject.SetActive(true);
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(3).transform.GetChild(0).transform.gameObject.SetActive(true);

        }
        else if (a == 5)
        {
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.gameObject.SetActive(true);
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(1).transform.GetChild(0).transform.gameObject.SetActive(true);
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(2).transform.GetChild(0).transform.gameObject.SetActive(true);
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(3).transform.GetChild(0).transform.gameObject.SetActive(true);
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(4).transform.GetChild(0).transform.gameObject.SetActive(true);

        }
        else if (a == 0)
        {
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.gameObject.SetActive(false);
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(1).transform.GetChild(0).transform.gameObject.SetActive(false);
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(2).transform.GetChild(0).transform.gameObject.SetActive(false);
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(3).transform.GetChild(0).transform.gameObject.SetActive(false);
            OrderText.transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).transform.GetChild(4).transform.GetChild(0).transform.gameObject.SetActive(false);
        }

        // Activate OrderText and deactivate Recipe
        OrderText.SetActive(true);
        Recipe.SetActive(false);

        // Reset OrderAccepted and other variables
        OrderAccepted = false;
        TimeOutOrder();
        orderInterval = 120f;
        currentOrder = 6;
        WaitForOrder();
        // Set a delay to turn off the OrderText
        Invoke("OrdertextOff", 6f);
    }
    public void WaitForOrder()
    {
        foreach(GameObject orderpic in orderObjects)
        {
            orderpic.SetActive(false);
        }foreach(GameObject orderpic in orderObjects2)
        {
            orderpic.SetActive(false);
        }foreach(GameObject orderpic in orderObjects3)
        {
            orderpic.SetActive(false);
        }
    }
    public void OrdertextOff()
    {
        OrderText.transform.GetChild(0).transform.GetChild(0).transform.gameObject.SetActive(false);
        OrderText.transform.GetChild(0).transform.GetChild(1).transform.gameObject.SetActive(false);
        OrderText.transform.GetChild(0).transform.GetChild(2).transform.gameObject.SetActive(false);
        OrderText.transform.GetChild(0).transform.GetChild(3).transform.gameObject.SetActive(false);
        OrderText.SetActive(false);
        orderText.text = "Time In New Order";
        orderText1.text = "Time In New Order";
        orderText2.text = "Time In New Order";
        orderText3.text = "Time In New Order";
    }
}
