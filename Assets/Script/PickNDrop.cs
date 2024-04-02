using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickNDrop : MonoBehaviour
{
    public Transform TvTAGE1;
    public AudioSource BackgroundAudio;
    public AudioSource Audio;
    public List<AudioClip> Auidos;
    public GameObject NameRender, justNamerenderer, SoundPanel, SoundOn, SoundOff, JoyStick;
    public List<Sprite> Sprites;
    public Animator Fridgedrawer1, Fridgedrawer2, PLaceOrderAnim;
    public GameObject cam, fpsContollar, cuttingFPS, MovingFPS, TemppickobjHolder, EnvCamera, Cf2, FPSCotroller;
    RaycastHit _hitInfo;
    float rayDistance = 5f;
    private Color newEmissionColor = Color.red;
    public Transform pickedObj, pickedObj2;
    private Transform order;
    Vector3 raycast_position;
    public GameObject start;
    public GameObject pickbtn, dropbtn, Cuttingbtn, opendoor, closedoor, PLacebtn, dustbibtn, laptopbtn,
                      StoveBtnleft, StoveBtnleft1, StoveBtnRight, StoveBtnRight2, TimeSetBtn, porespicebtn, Spicebtn, BackFromSpice, InteractButton, backInteractButton, Leftrotation,
                      RightRotation, UpRotation, Downrotation, PLaceBtnn, Water, oilup, oilDown, InteractSauce, PLaceOrder, KniefHolderBtn,
                      potatoCutBtn,ContinueBUtton, interactchikenBtn, BackinteractchikenBtn, CutBtn, placeSpatulla, ChickenBroutebtn, SoupPore, Phone, SavendLoadbtn,SunFlowerOilBtn,BackSunflowerBtnClk;
    public Transform OnionPos, MilkCreamPOs, DishPos, kniefpos, DishCamera, stolePos, BoxPos, MasalBoxapos, Cuttingknief, frypanpos, timeknob, BigPot,
                     cuttertry, PlaceCuttertTry, cutterBoard, LaptopPOs, fryerBasket, PellaPan, fishPos, TimeSetPos, cutterBoardPos
                      , verticallayout, SquareplateBasic, MediumPlateBasic, SmallPlateBasic, LargePlateBasic, DeepPlateBasic, Meat, fryerleft, fryerright,
                      SunflowerPOs, SpoonPOs, Spoon1POs, Spatula, dustpos1, dustpos2, Oil1, Oil2, Sushi, orderpos, TakeOrderpos, PotatoCutPos, ChickenBroutepos
                      , Knief22, knief3, PhonePOs, juicerJUg, juicerJUgPLacepos,PhonePlace;
    public List<Transform> picUpOjectsList;
    public GameObject burner1color, burner2color, burner3color, burner4color, UtensilsHolder1, UtensilsHolder2, UtensilsHolder3, UtensilsHolder4;
    public Transform BakedObject, friedPotato;
    public bool Baking;
    public List<Transform> picUpOjects2List;
    private List<GameObject> instantiatedPrefabs = new List<GameObject>();
    public List<GameObject> OUTline = new List<GameObject>();
    public float rotationSpeed = 10f;
    public GameObject ItemNameImage, totalNameimg, justName;
    public Text ItemName, ItemWeight;
    public Text justNametext;
    Vector3 PlacePosition, PickupPosition;
    Quaternion pickedRotation;
    GameObject outline;
    Transform childCounts;
    public List<GameObject> InstantiateObject = new List<GameObject>();
    public Transform TempPOsRot;
    public GameObject textPrefab;
    Quaternion initialRotation, targetRotation;
    private bool Rotate = true;
    private bool DuringCutting = true;
    private bool OUtline = true;
    private bool Waters = false;
    public Material FishMaterial, SalmonMaterial, PotatoMaterial;
    private bool Childcount = true;
    private bool rotateEnabled = false;
    public GameObject[] objectPrefabs;
    int TV = 0;
    int turn, potatoclone;
    private bool isFilling = false;
    private bool isClear = false;
    private float maxYPosition = 1.07f;
    private float minYPosition = 0.7f;
    private float moveSpeed = 1.0f;
    Transform oil;
    public static PickNDrop instance;
    public static bool Hitobject = true;
    public static int SpiceAmount = 0;
    public static bool PotatoFrieoil, PotatoFrieBtn = false;
    public static bool friedfish = false;
    public static bool friedfish1 = false;
    public static bool burner1, burner2, burner3, burner4 = false;
    private void Awake()
    {
        start.SetActive(true);
        instance = this;
        Hitobject = true;
        JoyStick.SetActive(false);
    }
    private void Start()
    {
        int a = PlayerPrefs.GetInt("Continue",0);
        if(a==1)
        {
            ContinueBUtton.SetActive(true);
        }
        else
        {
            ContinueBUtton.SetActive(false);
        }
        Baking = false;
        PotatoFrieBtn = false;
        PotatoFrieoil = false;
        potatoclone = 0;
    }
    public void SoundSettingbtnclk()
    {
        Audio.clip = Auidos[6];
        Audio.Play();
        start.SetActive(false);
        SoundPanel.SetActive(true);
    }
    public void MainMenubtnclk()
    {
        Audio.clip = Auidos[6];
        Audio.Play();
        SoundPanel.SetActive(false);
        start.SetActive(true);
    }
    public void SoundOfff()
    {
        Audio.clip = Auidos[6];
        Audio.Play();
        SoundOn.SetActive(true);
        SoundOff.SetActive(false);
        BackgroundAudio.mute = false;
    }
    public void SoundONN()
    {
        Audio.clip = Auidos[6];
        Audio.Play();
        SoundOff.SetActive(true);
        SoundOn.SetActive(false);
        BackgroundAudio.mute = true;
    }
    public void SavePickedObjet()
    {
        
        if (pickedObj != null)
        {
            print("dvvdv");
            PlayerPrefs.SetString("pickedObjName", pickedObj.name);
            PlayerPrefs.SetString("pickedObjTag", pickedObj.tag);
        }
        else if (pickedObj == null)
        {
            print("ddwsfsdv");
            PlayerPrefs.SetString("pickedObjName", "");
            PlayerPrefs.SetString("pickedObjTag", "");
        }
    }
    public void Startgameobject()
    {
      
        Audio.clip = Auidos[6];
        Audio.Play();
        BackgroundAudio.Play();
        JoyStick.SetActive(true);
        start.SetActive(false);
        SavendLoadbtn.SetActive(true);
        FPSCotroller.gameObject.GetComponent<CharacterController>().enabled = true;
        PlayerPrefs.SetInt("Minute2", 0);
        PlayerPrefs.SetInt("Second2", 0);
        PlayerPrefs.SetInt("Minute3", 0);
        PlayerPrefs.SetInt("Second3", 0);
        PlayerPrefs.SetInt("Minute4", 0);
        PlayerPrefs.SetInt("Second4", 0);
        PlayerPrefs.SetInt("Minute1", 0);
        PlayerPrefs.SetInt("Second1", 0);
        OrderManager.Instance.startCoroutine();
    }
    public void Reload()
    {
        Audio.clip = Auidos[6];
        Audio.Play();
        Invoke("INVOKREELOAD", 1f);
        functionality();
        OrderManager.Instance.startCoroutine();
    }
    public void functionality()
    {

      
        string pickedObjName = PlayerPrefs.GetString("pickedObjName");
        if (pickedObjName == "kinfyyy")
        {
            pickedObj = Cuttingknief;
            OnclickCutbtn();
        }
        JoyStick.SetActive(true);
        int interact = PlayerPrefs.GetInt("Interact", 0);
        if (interact == 1)
        {
            InteractBtnclick();
        }
        else if (interact == 2)
        {
            ChickenBroutebtnClick();
        }
        int seconds1 = PlayerPrefs.GetInt("Second1", 0);
        if (seconds1 > 0)
        {
            TimeKnob1.instance.LoadedTime();
        }
        int seconds2 = PlayerPrefs.GetInt("Second2", 0);
        if (seconds2 > 0)
        {
            Timeknob2.instance.LoadedTime();
        }
        int seconds3 = PlayerPrefs.GetInt("Second3", 0);
        if (seconds3 > 0)
        {
            Timeknob3.instance.LoadedTime();
        }
        int seconds4 = PlayerPrefs.GetInt("Second4", 0);
        if (seconds4 > 0)
        {
            TimeKnob4.instance.LoadedTime();
        }
        BackgroundAudio.Play();
        start.SetActive(false);
        SavendLoadbtn.SetActive(true);
    }
    public void INVOKREELOAD()
    {
        FPSCotroller.gameObject.GetComponent<CharacterController>().enabled = true;

    }
    public void StartRotation(int a)
    {
        turn = a;
        rotateEnabled = true;
    }
    public void StopRotation()
    {
        rotateEnabled = false;
    }
    public void OilFilling()
    {
        oil.Translate(Vector3.up * moveSpeed / 5 * Time.deltaTime);
        // Clamp the Y position between minYPosition and maxYPosition
        float clampedY = Mathf.Clamp(oil.position.y, minYPosition, maxYPosition);
        oil.transform.position = new Vector3(oil.transform.position.x, clampedY, oil.transform.position.z);
        if (clampedY == maxYPosition)
        {
            PotatoFrieoil = true;
            print("Oil Ok");
        }
    }
    public void OilClear()
    {

        oil.Translate(Vector3.down * moveSpeed / 5 * Time.deltaTime);
        // Clamp the Y position between minYPosition and maxYPosition
        float clampedY = Mathf.Clamp(oil.position.y, minYPosition, maxYPosition);
        oil.transform.position = new Vector3(oil.transform.position.x, clampedY, oil.transform.position.z);
        if (clampedY == minYPosition)
        {
            PotatoFrieoil = false;
            print("Oil Ok");
        }
    }
    public void startfilling()
    {
        if (_hitInfo.transform.name == "Leftoilup")
        {
            oil = Oil1;
            isFilling = true;
        }
        else if (_hitInfo.transform.name == "Rightoilup")
        {
            oil = Oil2;
            isFilling = true;
        }

    }
    public void startClearing()
    {
        print("clear");
        if (_hitInfo.transform.name == "leftoildown")
        {
            oil = Oil1;
            isClear = true;
        }
        else if (_hitInfo.transform.name == "Rightoildown")
        {
            oil = Oil2;
            isClear = true;
        }
    }
    public void StopFilling()
    {
        isFilling = false;
        isClear = false;
    }
    private void RotateObject()
    {
        if (turn == 1)
        {
            pickedObj.Rotate(Vector3.up * 15 * Time.deltaTime);
        }
        if (turn == 2)
        {
            pickedObj.Rotate(-Vector3.up * 15 * Time.deltaTime);
        }
        if (turn == 3)
        {
            pickedObj.Rotate(Vector3.right * 15 * Time.deltaTime);
        }
        if (turn == 4)
        {
            pickedObj.Rotate(-Vector3.right * 15 * Time.deltaTime);
        }

    }
    void Update()
    {
        if (rotateEnabled)
        {
            RotateObject();
        }
        if (isFilling)
        {
            OilFilling();
        }
        if (isClear)
        {
            OilClear();
        }
        if (DuringCutting)
        {
            PickUp();
            if (picUpOjectsList.Count != 0)
            {
                dropbtn.SetActive(true);
            }
            else
            {
                dropbtn.SetActive(false);

            }
        }
    }
    public void PickUp()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hitInfo, rayDistance))
        {
            raycast_position = _hitInfo.point;
            Debug.DrawRay(cam.transform.position, cam.transform.forward * _hitInfo.distance, Color.red);
            if (_hitInfo.transform.tag == "Left" || _hitInfo.transform.tag == "Right")
            {
                PLaceBtnn.SetActive(false);
                outline = _hitInfo.transform.gameObject;
                if (!OUTline.Contains(outline))
                {
                    OUTline.Add(outline);
                }
                HighlightObject();
                OUtline = true;
                outline.GetComponent<Outline>().enabled = true;
                if (_hitInfo.transform.rotation.y == 0)
                {
                    opendoor.SetActive(true);

                }
                else
                {
                    closedoor.SetActive(true);
                }
            }
            else if (_hitInfo.transform.tag == "Drawer")
            {
                outline = _hitInfo.transform.gameObject;
                if (!OUTline.Contains(outline))
                {
                    OUTline.Add(outline);
                }
                HighlightObject();
                outline.GetComponent<Outline>().enabled = true;
                float xPosition = _hitInfo.transform.position.x;
                float openThreshold = 25.65f;
                float closeThreshold = 25.4f;
                if (xPosition > openThreshold)
                {
                    opendoor.SetActive(true);
                    closedoor.SetActive(false);
                }
                else if (xPosition < closeThreshold)
                {
                    opendoor.SetActive(false);
                    closedoor.SetActive(true);
                }
            }
            else if (_hitInfo.transform.tag == "BUtton")
            {
                outline = _hitInfo.transform.gameObject;
                if (!OUTline.Contains(outline))
                {
                    OUTline.Add(outline);
                }
                HighlightObject();
                outline.GetComponent<Outline>().enabled = true;
                if (_hitInfo.transform.name == "Oven"|| _hitInfo.transform.name == "Oven1" || _hitInfo.transform.name == "Water")
                {
                    if (_hitInfo.transform.rotation.eulerAngles.x < 10)
                    {
                        StoveBtnleft.SetActive(true);
                    }
                    else if (_hitInfo.transform.rotation.eulerAngles.x > 60)
                    {
                        StoveBtnRight.SetActive(true);
                    }
                }
                else
                {
                    if (_hitInfo.transform.rotation.eulerAngles.y < 10)
                    {
                        StoveBtnleft1.SetActive(true);
                    }
                    else if (_hitInfo.transform.rotation.eulerAngles.y > 60)
                    {
                        StoveBtnRight2.SetActive(true);
                    }
                }

            }
            else if (_hitInfo.transform.name == "CutButton")
            {
                outline = _hitInfo.transform.gameObject;
                if (!OUTline.Contains(outline))
                {
                    OUTline.Add(outline);
                }
                HighlightObject();
                outline.GetComponent<Outline>().enabled = true;
                CutBtn.SetActive(true);
            }
            else if (_hitInfo.transform.tag == "TakeOrder" && orderpos.childCount != 0)
            {
                PLaceOrder.SetActive(true);
            }
            else if (_hitInfo.transform.tag == "Oilfill")
            {
                if (_hitInfo.transform.name == "Leftoilup" || _hitInfo.transform.name == "Rightoilup")
                {
                    oilup.SetActive(true);
                }
                else if (_hitInfo.transform.name == "leftoildown" || _hitInfo.transform.name == "Rightoildown")
                {
                    oilDown.SetActive(true);
                }
            }
            else if (picUpOjectsList == null || picUpOjectsList.Count == 0)
            {
                PLaceOrder.SetActive(false);
                PLaceBtnn.SetActive(false);
                SoupPore.SetActive(false);
                placeSpatulla.SetActive(false);
                opendoor.SetActive(false);
                KniefHolderBtn.SetActive(false);
                closedoor.SetActive(false);
                StoveBtnleft.SetActive(false);
                Spicebtn.SetActive(false);
                InteractButton.SetActive(false);
                StoveBtnRight.SetActive(false);
                StoveBtnleft1.SetActive(false);
                StoveBtnRight2.SetActive(false);
                oilup.SetActive(false);
                oilDown.SetActive(false);
                CutBtn.SetActive(false);
                potatoCutBtn.SetActive(false);
                TimeSetBtn.SetActive(false);
                if (_hitInfo.transform.tag == "cayennepepper" || _hitInfo.transform.tag == "horsera" ||
                     _hitInfo.transform.tag == "salt" || _hitInfo.transform.tag == "thymedried" ||
                     _hitInfo.transform.tag == "blackpepper" || _hitInfo.transform.tag == "drilldried")
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    foreach (Sprite rendere in Sprites)
                    {
                        if (rendere.name == _hitInfo.transform.tag)
                        {
                            NameRender.GetComponent<Image>().sprite = rendere;
                        }
                    }
                    justName.SetActive(false); ItemNameImage.SetActive(false);
                    ItemName.text = _hitInfo.transform.name;
                    ItemWeight.text = _hitInfo.transform.gameObject.GetComponent<SpiceQuantity>().Quantity.ToString() + "g";
                    ItemNameImage.SetActive(true);
                    pickbtn.SetActive(true);
                }
                else if (_hitInfo.transform.tag == "Large Plate Basic" || _hitInfo.transform.tag == "Medium Plate Basic" ||
                    _hitInfo.transform.tag == "Casserole , Basic" || _hitInfo.transform.tag == "Small Bowl , Basic" ||
                    _hitInfo.transform.tag == "Large Bowl , Basic" || _hitInfo.transform.tag == "Small Plate,  Basic" ||
                    _hitInfo.transform.tag == "Medium Plate,  Basic" || _hitInfo.transform.tag == "Square plate, Basic" ||
                    _hitInfo.transform.tag == "Small Deep PLate, Basic" || _hitInfo.transform.tag == "Deep Plate, Basic")
                {
                    if (OUtline && outline != null && outline.tag != _hitInfo.transform.gameObject.tag && outline.name != _hitInfo.transform.gameObject.name)
                    {
                        outline.GetComponent<Outline>().enabled = false;
                        outline = null;
                    }
                    childCounts = _hitInfo.transform;
                    if (childCounts.childCount == 0)
                    {
                        outline = _hitInfo.transform.gameObject;
                        if (!OUTline.Contains(outline))
                        {
                            OUTline.Add(outline);
                        }
                        HighlightObject();
                        outline.GetComponent<Outline>().enabled = true;
                        foreach (Sprite rendere in Sprites)
                        {
                            if (rendere.name == _hitInfo.transform.name)
                            {
                                justNamerenderer.GetComponent<Image>().sprite = rendere;
                            }
                        }
                        justName.SetActive(true); ItemNameImage.SetActive(false);
                        justNametext.text = _hitInfo.transform.tag;
                        pickbtn.SetActive(true);
                    }
                    else
                    {
                        outline = _hitInfo.transform.gameObject;
                        if (!OUTline.Contains(outline))
                        {
                            OUTline.Add(outline);
                        }
                        HighlightObject();
                        outline.GetComponent<Outline>().enabled = true;
                        foreach (Sprite rendere in Sprites)
                        {
                            if (rendere.name == _hitInfo.transform.name)
                            {
                                justNamerenderer.GetComponent<Image>().sprite = rendere;
                            }
                        }
                        justName.SetActive(true); ItemNameImage.SetActive(false);
                        justNametext.text = _hitInfo.transform.name;
                        pickbtn.SetActive(true);
                        if (Childcount)
                        {
                            ChildCount();
                        }
                        verticallayout.gameObject.SetActive(true);

                    }
                }
                else if (_hitInfo.transform.tag == "MilkCream" || _hitInfo.transform.tag == "BakingTray"
                       || _hitInfo.transform.tag == "cuttertry" || _hitInfo.transform.name == "CuttingBoard")
                {
                    if (OUtline && outline != null && outline.tag != _hitInfo.transform.gameObject.tag && outline.name != _hitInfo.transform.gameObject.name)
                    {
                        outline.GetComponent<Outline>().enabled = false;
                        outline = null;
                    }
                    childCounts = _hitInfo.transform;
                    if (childCounts.childCount == 0)
                    {
                        outline = _hitInfo.transform.gameObject;
                        if (!OUTline.Contains(outline))
                        {
                            OUTline.Add(outline);
                        }
                        HighlightObject();
                        outline.GetComponent<Outline>().enabled = true;
                        foreach (Sprite rendere in Sprites)
                        {
                            if (rendere.name == _hitInfo.transform.tag)
                            {
                                justNamerenderer.GetComponent<Image>().sprite = rendere;
                            }
                        }
                        justName.SetActive(true);
                        justNametext.text = _hitInfo.transform.tag;
                        pickbtn.SetActive(true);
                    }
                    else
                    {
                        outline = _hitInfo.transform.gameObject;
                        if (!OUTline.Contains(outline))
                        {
                            OUTline.Add(outline);
                        }
                        HighlightObject();
                        outline.GetComponent<Outline>().enabled = true;
                        foreach (Sprite rendere in Sprites)
                        {
                            if (rendere.name == _hitInfo.transform.tag)
                            {
                                justNamerenderer.GetComponent<Image>().sprite = rendere;
                            }
                        }
                        justName.SetActive(true);
                        justNametext.text = _hitInfo.transform.tag;
                        ItemNameImage.SetActive(false);
                        pickbtn.SetActive(true);
                        if (Childcount)
                        {
                            ChildCount();
                        }
                        verticallayout.gameObject.SetActive(true);
                    }
                }
                else if (_hitInfo.transform.tag == "FryPan" || _hitInfo.transform.tag == "PellaPan" || _hitInfo.transform.tag == "BigPot") 
                {
                    if (OUtline && outline != null && outline.tag != _hitInfo.transform.gameObject.tag && outline.name != _hitInfo.transform.gameObject.name)
                    {
                        outline.GetComponent<Outline>().enabled = false;
                        outline = null;
                    }
                    childCounts = _hitInfo.transform;
                    if (childCounts.childCount == 0)
                    {
                        outline = _hitInfo.transform.gameObject;
                        if (!OUTline.Contains(outline))
                        {
                            OUTline.Add(outline);
                        }
                        HighlightObject();
                        outline.GetComponent<Outline>().enabled = true;
                        foreach (Sprite rendere in Sprites)
                        {
                            if (rendere.name == _hitInfo.transform.tag)
                            {
                                justNamerenderer.GetComponent<Image>().sprite = rendere;
                            }
                        }
                        justName.SetActive(true);
                        justNametext.text = _hitInfo.transform.tag;
                        pickbtn.SetActive(true);
                    }
                    else
                    {
                        outline = _hitInfo.transform.gameObject;
                        if (!OUTline.Contains(outline))
                        {
                            OUTline.Add(outline);
                        }
                        HighlightObject();
                        outline.GetComponent<Outline>().enabled = true;
                        foreach (Sprite rendere in Sprites)
                        {
                            if (rendere.name == _hitInfo.transform.tag)
                            {
                                justNamerenderer.GetComponent<Image>().sprite = rendere;
                            }
                        }
                        justName.SetActive(true); ItemNameImage.SetActive(false);
                        justNametext.text = _hitInfo.transform.tag;
                        pickbtn.SetActive(true);
                        if (Childcount)
                        {
                            ChildCount();
                        }
                        verticallayout.gameObject.SetActive(true);
                    }
                }
                else if (_hitInfo.transform.tag == "JuicerJug" || _hitInfo.transform.tag == "Timeknob" || _hitInfo.transform.tag == "Knief")
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    foreach (Sprite rendere in Sprites)
                    {
                        if (rendere.name == _hitInfo.transform.tag)
                        {
                            justNamerenderer.GetComponent<Image>().sprite = rendere;
                        }
                    }
                    justNametext.text = _hitInfo.transform.name;
                    justName.SetActive(true);
                    ItemNameImage.SetActive(false);
                    pickbtn.SetActive(true);
                }
                else if (_hitInfo.transform.name == "Phone")
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    foreach (Sprite rendere in Sprites)
                    {
                        if (rendere.name == _hitInfo.transform.name)
                        {
                            justNamerenderer.GetComponent<Image>().sprite = rendere;
                        }
                    }
                    justName.SetActive(true);
                    ItemNameImage.SetActive(false);
                    justNametext.text = _hitInfo.transform.name;
                    pickbtn.SetActive(true);
                }
                else if (_hitInfo.transform.tag == "ChickenBroute")
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    foreach (Sprite rendere in Sprites)
                    {
                        if (rendere.name == "ChickenBroute")
                        {
                            NameRender.GetComponent<Image>().sprite = rendere;
                        }
                    }
                    ItemNameImage.SetActive(true);
                    justName.SetActive(false);
                    ItemName.text = "Chicken Broute";
                    ItemWeight.text = "720g";
                    pickbtn.SetActive(true);

                }
                else if (_hitInfo.transform.name == "Salmon Fillet" || _hitInfo.transform.tag == "SalmonFillet")
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    foreach (Sprite rendere in Sprites)
                    {
                        if (rendere.name == "Salmon Fillet")
                        {
                            NameRender.GetComponent<Image>().sprite = rendere;
                        }
                    }
                    ItemNameImage.SetActive(true); justName.SetActive(false);
                    ItemName.text = "Salmon";
                    ItemWeight.text = "210g";
                    pickbtn.SetActive(true);
                }
                else if (_hitInfo.transform.tag == "Blender" || _hitInfo.transform.tag == "Spatulla")
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    foreach (Sprite rendere in Sprites)
                    {
                        if (rendere.name == _hitInfo.transform.tag)
                        {
                            justNamerenderer.GetComponent<Image>().sprite = rendere;
                        }
                    }
                    justName.SetActive(true);
                    ItemNameImage.SetActive(false);
                    justNametext.text = _hitInfo.transform.name;
                    pickbtn.SetActive(true);
                }
                else if (_hitInfo.transform.tag == "Spoon1" || _hitInfo.transform.tag == "Spoon" || _hitInfo.transform.name == "Sunflower Oil")
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    foreach (Sprite rendere in Sprites)
                    {
                        if (rendere.name == _hitInfo.transform.name)
                        {
                            justNamerenderer.GetComponent<Image>().sprite = rendere;
                        }
                    }
                    justName.SetActive(true);
                    ItemNameImage.SetActive(false);
                    justNametext.text = _hitInfo.transform.name;
                    pickbtn.SetActive(true);
                }
                else if (_hitInfo.transform.tag == "Onion" || _hitInfo.transform.tag == "onion")
                {
                    DestroyInstantiatedPrefabs();
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    foreach (Sprite rendere in Sprites)
                    {
                        if (rendere.name == "onion")
                        {
                            NameRender.GetComponent<Image>().sprite = rendere;
                        }
                    }
                    ItemNameImage.SetActive(true); justName.SetActive(false);
                    ItemName.text = "Onion";
                    ItemWeight.text = "120g";
                    pickbtn.SetActive(true);
                }
                else if (_hitInfo.transform.tag == "Tomato" || _hitInfo.transform.tag == "tomato")
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    foreach (Sprite rendere in Sprites)
                    {
                        if (rendere.name == "tomato")
                        {
                            NameRender.GetComponent<Image>().sprite = rendere;
                        }
                    }
                    ItemNameImage.SetActive(true); justName.SetActive(false);
                    ItemName.text = "Tomato";
                    ItemWeight.text = "50g";
                    print("tomato");
                    pickbtn.SetActive(true);
                }
                else if (_hitInfo.transform.tag == "Meat" || _hitInfo.transform.tag == "meat")
                {
                    DestroyInstantiatedPrefabs();
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    foreach (Sprite rendere in Sprites)
                    {
                        if (rendere.name == "meat")
                        {
                            NameRender.GetComponent<Image>().sprite = rendere;
                        }
                    }
                    ItemNameImage.SetActive(true); justName.SetActive(false);
                    ItemName.text = "Steak";
                    ItemWeight.text = "150g";
                    pickbtn.SetActive(true);
                }
                else if (_hitInfo.transform.tag == "Potato" || _hitInfo.transform.tag == "potato")
                {
                    DestroyInstantiatedPrefabs();
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    foreach (Sprite rendere in Sprites)
                    {
                        if (rendere.name == "potato")
                        {
                            NameRender.GetComponent<Image>().sprite = rendere;
                        }
                    }
                    ItemNameImage.SetActive(true); justName.SetActive(false);
                    ItemName.text = "Potato";
                    ItemWeight.text = "100g";
                    pickbtn.SetActive(true);
                }
                else if (_hitInfo.transform.tag == "potato1")
                {
                    DestroyInstantiatedPrefabs();
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    foreach (Sprite rendere in Sprites)
                    {
                        if (rendere.name == "potato1")
                        {
                            NameRender.GetComponent<Image>().sprite = rendere;
                        }
                    }
                    ItemNameImage.SetActive(true); justName.SetActive(false);
                    ItemName.text = "Potato";
                    ItemWeight.text = " 8g ";
                    pickbtn.SetActive(true);
                }
                else if (_hitInfo.transform.tag == "Lemon" || _hitInfo.transform.tag == "lemon")
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    DestroyInstantiatedPrefabs();
                    outline.GetComponent<Outline>().enabled = true;
                    foreach (Sprite rendere in Sprites)
                    {
                        if (rendere.name == "Lemon")
                        {
                            NameRender.GetComponent<Image>().sprite = rendere;
                        }
                    }
                    ItemNameImage.SetActive(true); justName.SetActive(false);
                    ItemName.text = "Lemon";
                    ItemWeight.text = "80g";
                    pickbtn.SetActive(true);
                }
                else if (_hitInfo.transform.tag == "Fish" || _hitInfo.transform.tag == "fish")
                {
                    outline = _hitInfo.transform.gameObject;
                    DestroyInstantiatedPrefabs();
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    foreach (Sprite rendere in Sprites)
                    {
                        if (rendere.name == "trout")
                        {
                            NameRender.GetComponent<Image>().sprite = rendere;
                        }
                    }
                    ItemNameImage.SetActive(true); justName.SetActive(false);
                    ItemName.text = "Trout";
                    ItemWeight.text = "200g";
                    pickbtn.SetActive(true);
                }
                else if (_hitInfo.transform.tag == "Sushi")
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    foreach (Sprite rendere in Sprites)
                    {
                        if (rendere.name == "Sushi")
                        {
                            justNamerenderer.GetComponent<Image>().sprite = rendere;
                        }
                    }
                    outline.GetComponent<Outline>().enabled = true;
                    justName.SetActive(true);
                    justNametext.text = _hitInfo.transform.name;
                    pickbtn.SetActive(true);
                }
                else if (_hitInfo.transform.name == "Bucket" || _hitInfo.transform.name == "fryerBasket" || _hitInfo.transform.name == "Gas Cylinder")
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    foreach (Sprite rendere in Sprites)
                    {
                        if (rendere.name == _hitInfo.transform.name)
                        {
                            justNamerenderer.GetComponent<Image>().sprite = rendere;
                        }
                    }
                    justName.SetActive(true);ItemNameImage.SetActive(false);
                    justNametext.text = _hitInfo.transform.name;
                    pickbtn.SetActive(true);
                }
                else if ( _hitInfo.transform.tag == "Stoll")
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    foreach (Sprite rendere in Sprites)
                    {
                        if (rendere.name == _hitInfo.transform.tag)
                        {
                            justNamerenderer.GetComponent<Image>().sprite = rendere;
                        }
                    }
                    justName.SetActive(true);
                    justNametext.text = _hitInfo.transform.name;
                    pickbtn.SetActive(true);
                }
                else
                {
                    justName.SetActive(false);
                    placeSpatulla.SetActive(false);
                    ItemNameImage.SetActive(false);
                    pickbtn.SetActive(false);
                    opendoor.SetActive(false);
                    closedoor.SetActive(false);
                    Cuttingbtn.SetActive(false);
                    PLacebtn.SetActive(false);
                    laptopbtn.SetActive(false);
                    SunFlowerOilBtn.SetActive(false);
                    SoupPore.SetActive(false);
                    StoveBtnleft.SetActive(false);
                    Spicebtn.SetActive(false);
                    InteractButton.SetActive(false);
                    TimeSetBtn.SetActive(false);
                    if (outline != null)
                    {
                        outline.GetComponent<Outline>().enabled = false;
                        outline = null;
                    }
                    Childcount = true;
                    DestroyInstantiatedPrefabs();
                }

            }
            else if (picUpOjectsList.Count != 0)       // List Of PIcked Object   has One Elememt 
            {
                PLaceOrder.SetActive(false);
                opendoor.SetActive(false);
                closedoor.SetActive(false);
                StoveBtnleft.SetActive(false);
                StoveBtnRight.SetActive(false);
                StoveBtnleft1.SetActive(false);
                StoveBtnRight2.SetActive(false);
                oilup.SetActive(false);
                oilDown.SetActive(false);
                CutBtn.SetActive(false);
                PLaceBtnn.SetActive(false);
                placeSpatulla.SetActive(false);
                pickedObj2 = _hitInfo.transform;
                if (pickedObj2.tag == "Place")
                {
                    if (outline != null)
                    {
                        outline.GetComponent<Outline>().enabled = false;
                        outline = null;
                    }
                    InteractButton.SetActive(false);
                    PLaceBtnn.SetActive(true);
                    potatoCutBtn.SetActive(false);
                    SunFlowerOilBtn.SetActive(false);
                    KniefHolderBtn.SetActive(false);
                    PLacebtn.SetActive(false);
                }
                else if (_hitInfo.transform.name == "CutPotato")
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;

                    potatoCutBtn.SetActive(true);
                }
                else if ((pickedObj.tag == "lemon" || pickedObj.tag == "tomato" || pickedObj.tag == "onion" ||
                    pickedObj.tag == "potato" || pickedObj.tag == "potato1" || pickedObj.tag == "fish" || pickedObj.tag == "meat" || pickedObj.tag == "SalmonFillet")
                    && (pickedObj2.tag == "BakingTray" || pickedObj2.tag == "cuttertry" || pickedObj2.tag == "BigPot" || pickedObj2.tag == "CuttingBoard"
                || pickedObj2.tag == "FryPan" || pickedObj2.tag == "PellaPan" || pickedObj2.name == "fryerBasket" ||
                pickedObj2.tag == "Large Plate Basic" || pickedObj2.tag == "Medium Plate Basic" ||
                pickedObj2.tag == "Casserole , Basic" || pickedObj2.tag == "Small Bowl , Basic" ||
                pickedObj2.tag == "Large Bowl , Basic" || pickedObj2.tag == "Small Plate,  Basic" ||
                pickedObj2.tag == "Medium Plate,  Basic" || pickedObj2.tag == "Square plate, Basic" ||
                pickedObj2.tag == "Small Deep PLate, Basic" || pickedObj2.tag == "Deep Plate, Basic"))
                {
                    InteractButton.SetActive(false);
                    PLaceBtnn.SetActive(true);
                    PLacebtn.SetActive(false);
                }
                else if (pickedObj.name == "fryerBasket" && _hitInfo.transform.tag == "DeepFryer")
                {
                    PLacebtn.SetActive(true);
                }
                else if (pickedObj.transform.tag == "BakingTray" && _hitInfo.collider.tag == "OvenPlace")
                {
                    outline = _hitInfo.collider.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    PLacebtn.SetActive(true);
                }
                else if (pickedObj.name == "Phone" && _hitInfo.transform.name == "Phone Holder")
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    PLacebtn.SetActive(true);
                }
                else if (pickedObj.tag == "JuicerJug" && _hitInfo.transform.name == "Juicer Base")
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    PLacebtn.SetActive(true);
                }
                else if (pickedObj.tag == "ChickenBroute" && _hitInfo.transform.tag == "BigPot")
                {
                    interactchikenBtn.SetActive(true);
                    PLaceBtnn.SetActive(false);
                }  else if (pickedObj.name == "Sunflower Oil" && _hitInfo.transform.tag == "FryPan")
                {
                    SunFlowerOilBtn.SetActive(true);
                    PLaceBtnn.SetActive(false);
                }
                else if ((pickedObj.tag == "BakingTray" || pickedObj.tag == "cuttertry" || pickedObj.tag == "BigPot" || pickedObj.tag == "CuttingBoard"
                || pickedObj.tag == "FryPan" || pickedObj.tag == "PellaPan" || pickedObj.name == "fryerBasket" ||
                pickedObj.tag == "Large Plate Basic" || pickedObj.tag == "Medium Plate Basic" ||
                pickedObj.tag == "Casserole , Basic" || pickedObj.tag == "Small Bowl , Basic" ||
                pickedObj.tag == "Large Bowl , Basic" || pickedObj.tag == "Small Plate,  Basic" ||
                pickedObj.tag == "Medium Plate,  Basic" || pickedObj.tag == "Square plate, Basic" ||
                pickedObj.tag == "Small Deep PLate, Basic" || pickedObj.tag == "Deep Plate, Basic")
                &&
                    (_hitInfo.transform.tag == "cayennepepper" || _hitInfo.transform.tag == "horsera" || _hitInfo.transform.tag == "Onion" || _hitInfo.transform.tag == "onion" ||
                     _hitInfo.transform.tag == "salt" || _hitInfo.transform.tag == "thymedried" || _hitInfo.transform.name == "Salmon Fillet" || _hitInfo.transform.tag == "SalmonFillet" ||
                     _hitInfo.transform.tag == "blackpepper" || _hitInfo.transform.tag == "drilldried" || _hitInfo.transform.tag == "Tomato" || _hitInfo.transform.tag == "tomato" ||
                     _hitInfo.transform.tag == "Potato" || _hitInfo.transform.tag == "potato" || _hitInfo.transform.tag == "Lemon" || _hitInfo.transform.tag == "lemon" || _hitInfo.transform.tag == "Meat" || _hitInfo.transform.tag == "meat"
                    || _hitInfo.transform.tag == "Fish" || _hitInfo.transform.tag == "fish"
                     ))
                {
                    if (_hitInfo.transform.tag == "Tomato" || _hitInfo.transform.tag == "tomato")
                    {
                        outline = _hitInfo.transform.gameObject;
                        if (!OUTline.Contains(outline))
                        {
                            OUTline.Add(outline);
                        }
                        HighlightObject();
                        outline.GetComponent<Outline>().enabled = true;
                        foreach (Sprite rendere in Sprites)
                        {
                            if (rendere.name == "tomato")
                            {
                                NameRender.GetComponent<Image>().sprite = rendere;
                            }
                        }
                        ItemNameImage.SetActive(true);
                        ItemName.text = "Tomato";
                        ItemWeight.text = "50g";
                        pickbtn.SetActive(true);
                    }
                    else if (_hitInfo.transform.name == "Salmon Fillet" || _hitInfo.transform.tag == "SalmonFillet")
                    {
                        outline = _hitInfo.transform.gameObject;
                        if (!OUTline.Contains(outline))
                        {
                            OUTline.Add(outline);
                        }
                        HighlightObject();
                        outline.GetComponent<Outline>().enabled = true;
                        foreach (Sprite rendere in Sprites)
                        {
                            if (rendere.name == "Salmon Fillet")
                            {
                                NameRender.GetComponent<Image>().sprite = rendere;
                            }
                        }
                        ItemNameImage.SetActive(true);
                        ItemName.text = "Salmon";
                        ItemWeight.text = "210g";
                        pickbtn.SetActive(true);
                    }
                    else if (_hitInfo.transform.tag == "Onion" || _hitInfo.transform.tag == "onion")
                    {
                        outline = _hitInfo.transform.gameObject;
                        if (!OUTline.Contains(outline))
                        {
                            OUTline.Add(outline);
                        }
                        HighlightObject();
                        outline.GetComponent<Outline>().enabled = true;
                        foreach (Sprite rendere in Sprites)
                        {
                            if (rendere.name == "onion")
                            {
                                NameRender.GetComponent<Image>().sprite = rendere;
                            }
                        }
                        ItemNameImage.SetActive(true);
                        ItemName.text = "Onion";
                        ItemWeight.text = "120g";
                        pickbtn.SetActive(true);
                    }
                    else if (_hitInfo.transform.tag == "Potato" || _hitInfo.transform.tag == "potato")
                    {
                        outline = _hitInfo.transform.gameObject;
                        if (!OUTline.Contains(outline))
                        {
                            OUTline.Add(outline);
                        }
                        HighlightObject();
                        outline.GetComponent<Outline>().enabled = true;
                        foreach (Sprite rendere in Sprites)
                        {
                            if (rendere.name == "potato")
                            {
                                NameRender.GetComponent<Image>().sprite = rendere;
                            }
                        }
                        ItemNameImage.SetActive(true);
                        ItemName.text = "Potato";
                        ItemWeight.text = "100g";
                        pickbtn.SetActive(true);
                    }
                    else if (_hitInfo.transform.tag == "Lemon" || _hitInfo.transform.tag == "lemon")
                    {
                        outline = _hitInfo.transform.gameObject;
                        if (!OUTline.Contains(outline))
                        {
                            OUTline.Add(outline);
                        }
                        HighlightObject();
                        outline.GetComponent<Outline>().enabled = true;
                        foreach (Sprite rendere in Sprites)
                        {
                            if (rendere.name == "lemon")
                            {
                                NameRender.GetComponent<Image>().sprite = rendere;
                            }
                        }
                        ItemNameImage.SetActive(true);
                        ItemName.text = "Lemon";
                        ItemWeight.text = "80g";
                        pickbtn.SetActive(true);
                    }
                    else if (_hitInfo.transform.tag == "Meat" || _hitInfo.transform.tag == "meat")
                    {
                        DestroyInstantiatedPrefabs();
                        outline = _hitInfo.transform.gameObject;
                        if (!OUTline.Contains(outline))
                        {
                            OUTline.Add(outline);
                        }
                        HighlightObject();
                        outline.GetComponent<Outline>().enabled = true;
                        foreach (Sprite rendere in Sprites)
                        {
                            if (rendere.name == "meat")
                            {
                                NameRender.GetComponent<Image>().sprite = rendere;
                            }
                        }
                        ItemNameImage.SetActive(true);
                        ItemName.text = "Steak";
                        ItemWeight.text = "150g";
                        pickbtn.SetActive(true);
                    }
                    else if (_hitInfo.transform.tag == "Fish" || _hitInfo.transform.tag == "fish")
                    {
                        outline = _hitInfo.transform.gameObject;
                        if (!OUTline.Contains(outline))
                        {
                            OUTline.Add(outline);
                        }
                        HighlightObject();
                        outline.GetComponent<Outline>().enabled = true;
                        foreach (Sprite rendere in Sprites)
                        {
                            if (rendere.name == "trout")
                            {
                                NameRender.GetComponent<Image>().sprite = rendere;
                            }
                        }
                        ItemNameImage.SetActive(true);
                        ItemName.text = "Trout";
                        ItemWeight.text = "200g";
                        pickbtn.SetActive(true);
                    }
                    else
                    {
                        outline = _hitInfo.transform.gameObject;
                        if (!OUTline.Contains(outline))
                        {
                            OUTline.Add(outline);
                        }
                        HighlightObject();
                        outline.GetComponent<Outline>().enabled = true;
                        foreach (Sprite rendere in Sprites)
                        {
                            if (rendere.name == _hitInfo.transform.tag)
                            {
                                justNamerenderer.GetComponent<Image>().sprite = rendere;
                            }
                        }
                        justName.SetActive(true);
                        justNametext.text = _hitInfo.transform.tag;
                        pickbtn.SetActive(true);
                    }
                }
                
                else if (pickedObj2.tag == "Order" && (
               pickedObj.tag == "Large Plate Basic" || pickedObj.tag == "Medium Plate Basic" ||
               pickedObj.tag == "Casserole , Basic" || pickedObj.tag == "Small Bowl , Basic" ||
               pickedObj.tag == "Large Bowl , Basic" || pickedObj.tag == "Small Plate,  Basic" ||
               pickedObj.tag == "Medium Plate,  Basic" || pickedObj.tag == "Square plate, Basic" ||
               pickedObj.tag == "Small Deep PLate, Basic" || pickedObj.tag == "Deep Plate, Basic"))
                {
                    PLaceOrder.SetActive(true);
                }
                else if (_hitInfo.transform.tag == "PLaceInOven")
                {
                    PLacebtn.SetActive(true);
                }
                else if ((pickedObj.tag == "cayennepepper" || pickedObj.tag == "horsera" ||
                         pickedObj.tag == "salt" || pickedObj.tag == "thymedried" ||
                         pickedObj.tag == "blackpepper" || pickedObj.tag == "drilldried" )&& (
                          _hitInfo.transform.tag == "BakingTray" || _hitInfo.transform.tag == "FryPan" || _hitInfo.transform.tag == "CuttingBoard"
                        || _hitInfo.transform.tag == "cuttertry" || _hitInfo.transform.tag == "BigPot" || _hitInfo.transform.tag == "Medium Plate,  Basic"
                        || _hitInfo.transform.tag == "Large Plate Basic" || _hitInfo.transform.tag == "Small Bowl , Basic" || _hitInfo.transform.tag == "Medium Plate Basic"
                        ||  _hitInfo.transform.tag == "Casserole , Basic"))
                {
                    Spicebtn.SetActive(true);
                }
                else if ((pickedObj.tag == "BakingTray" || pickedObj.tag == "FryPan" || pickedObj.tag == "Casserole , Basic" ||
                         pickedObj.tag == "cuttertry" || pickedObj.tag == "BigPot" || pickedObj.tag == "Small Bowl , Basic" ||
                         pickedObj.tag == "CuttingBoard" || pickedObj.tag == "Medium Plate,  Basic" || pickedObj.tag == "Large Plate Basic" ||
                         pickedObj.tag == "Medium Plate Basic" || pickedObj.name == "fryerBasket" || pickedObj.tag == "Small Deep PLate, Basic" ||
                         pickedObj.tag == "Square plate, Basic" || pickedObj.tag == "Large Bowl , Basic" || pickedObj.tag == "PellaPan")
                        &&
                      (_hitInfo.transform.tag == "BakingTray" || _hitInfo.transform.tag == "FryPan" || _hitInfo.transform.tag == "CuttingBoard"
                        || _hitInfo.transform.tag == "cuttertry" || _hitInfo.transform.tag == "BigPot" || _hitInfo.transform.tag == "Medium Plate,  Basic"
                        || _hitInfo.transform.tag == "Large Plate Basic" || _hitInfo.transform.tag == "Small Bowl , Basic" || _hitInfo.transform.tag == "Medium Plate Basic"
                        || _hitInfo.transform.tag == "Casserole , Basic" || _hitInfo.transform.tag == "Large Bowl , Basic"
                        || _hitInfo.transform.tag == "Square plate, Basic" || _hitInfo.transform.tag == "Small Deep PLate, Basic"
                        || _hitInfo.transform.name == "fryerBasket" || _hitInfo.transform.tag == "Medium Plate Basic" || _hitInfo.transform.tag == "PellaPan")&& pickedObj.tag!= _hitInfo.transform.tag)

                {
                    
                    InteractButton.SetActive(true);
                    PLaceBtnn.SetActive(false);

                }
                else if (_hitInfo.transform.tag == "Dust")
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    dustbibtn.SetActive(true);
                }
                else if (_hitInfo.transform.tag == "CuttingBoard" && pickedObj.transform.tag == "Knief")
                {
                    PLaceBtnn.SetActive(false);
                    justName.SetActive(false);
                    ItemNameImage.SetActive(false);
                    Transform cutting = _hitInfo.transform;
                    if (cutting.childCount > 0)
                    {
                        outline = _hitInfo.transform.gameObject;
                        if (!OUTline.Contains(outline))
                        {
                            OUTline.Add(outline);
                        }
                        HighlightObject();
                        outline.GetComponent<Outline>().enabled = true;
                        Cuttingbtn.SetActive(true);
                    }
                }
                else if (_hitInfo.transform.name == "knife holder" && pickedObj.transform.tag == "Knief")
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    KniefHolderBtn.SetActive(true);
                }
                else if (_hitInfo.transform.tag == "Burner" && (pickedObj.tag == "FryPan" || pickedObj.tag == "BigPot"|| pickedObj.tag == "PellaPan"))
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    PLacebtn.SetActive(true);
                }
                else if ((_hitInfo.transform.tag == "FryPan" || _hitInfo.transform.tag == "PellaPan") && pickedObj.tag == "Spatulla")
                {
                    InteractButton.SetActive(true);
                }
                else if (pickedObj.tag == "Spatulla" && _hitInfo.transform.tag == "Utensils")
                {
                    outline = _hitInfo.transform.gameObject;
                    if (!OUTline.Contains(outline))
                    {
                        OUTline.Add(outline);
                    }
                    HighlightObject();
                    outline.GetComponent<Outline>().enabled = true;
                    placeSpatulla.SetActive(true);
                }
                else if ((_hitInfo.transform.tag == "BigPot") && pickedObj.tag == "Blender")
                {
                    PLacebtn.SetActive(true);
                }
                else if (_hitInfo.transform.name == "Pro Cutter" && pickedObj.transform.tag == "cuttertry")
                {
                    print("Place");
                    PLacebtn.SetActive(true);
                    PLaceBtnn.SetActive(false);
                }
                else if (pickedObj.tag == "BigPot" && (_hitInfo.transform.tag == "Small Deep PLate, Basic" || _hitInfo.transform.tag == "Large Bowl , Basic"))
                {
                    SoupPore.SetActive(true);
                }
               
                else
                {
                    SoupPore.SetActive(false);
                    PLaceBtnn.SetActive(false);
                    InteractButton.SetActive(false);
                    justName.SetActive(false);
                    ItemNameImage.SetActive(false);
                    SunFlowerOilBtn.SetActive(false);
                    pickbtn.SetActive(false);
                    placeSpatulla.SetActive(false);
                    opendoor.SetActive(false);
                    closedoor.SetActive(false);
                    dropbtn.SetActive(false);
                    PLacebtn.SetActive(false);
                    KniefHolderBtn.SetActive(false);
                    dustbibtn.SetActive(false);
                    potatoCutBtn.SetActive(false);
                    StoveBtnleft.SetActive(false);
                    StoveBtnRight.SetActive(false);
                    StoveBtnleft1.SetActive(false);
                    StoveBtnRight2.SetActive(false);
                    Cuttingbtn.SetActive(false);
                    interactchikenBtn.SetActive(false);
                    Spicebtn.SetActive(false);
                    if (outline != null)
                    {
                        outline.GetComponent<Outline>().enabled = false;
                        outline = null;
                    }
                    Childcount = true;
                    DestroyInstantiatedPrefabs();
                    PLaceOrder.SetActive(false);
                }
            }
            else
            {
                SoupPore.SetActive(false);
                oilup.SetActive(false);
                oilDown.SetActive(false);
                PLaceBtnn.SetActive(false);
                SunFlowerOilBtn.SetActive(false);
                ItemNameImage.SetActive(false);
                interactchikenBtn.SetActive(false);
                justName.SetActive(false);
                pickbtn.SetActive(false);
                opendoor.SetActive(false);
                placeSpatulla.SetActive(false);
                potatoCutBtn.SetActive(false);
                closedoor.SetActive(false);
                Cuttingbtn.SetActive(false);
                PLacebtn.SetActive(false);
                dustbibtn.SetActive(false);
                StoveBtnleft.SetActive(false);
                StoveBtnRight.SetActive(false);
                StoveBtnleft1.SetActive(false);
                StoveBtnRight2.SetActive(false);
                KniefHolderBtn.SetActive(false);
                StoveBtnleft.SetActive(false);
                Spicebtn.SetActive(false);
                InteractButton.SetActive(false);
                if (outline != null)
                {
                    outline.GetComponent<Outline>().enabled = false;
                    outline = null;
                    OUtline = false;
                }
                Childcount = true;
                DestroyInstantiatedPrefabs();
            }
        }
        else
        {
            SoupPore.SetActive(false);
            oilup.SetActive(false);
            oilDown.SetActive(false);
            PLaceBtnn.SetActive(false);
            ItemNameImage.SetActive(false);
            SunFlowerOilBtn.SetActive(false);
            justName.SetActive(false);
            KniefHolderBtn.SetActive(false);
            pickbtn.SetActive(false);
            placeSpatulla.SetActive(false);
            interactchikenBtn.SetActive(false);
            opendoor.SetActive(false);
            closedoor.SetActive(false);
            PLacebtn.SetActive(false);
            dustbibtn.SetActive(false);
            StoveBtnleft.SetActive(false);
            Cuttingbtn.SetActive(false);
            StoveBtnRight.SetActive(false);
            StoveBtnleft1.SetActive(false);
            StoveBtnRight2.SetActive(false);
            Spicebtn.SetActive(false);
            CutBtn.SetActive(false);
            potatoCutBtn.SetActive(false);
            InteractButton.SetActive(false);
            if (outline != null)
            {
                outline.GetComponent<Outline>().enabled = false;
                outline = null;
                OUtline = false;
            }
            Childcount = true;
            DestroyInstantiatedPrefabs();
        }
    }

    void HighlightObject()
    {
        int count = OUTline.Count;
        List<GameObject> removelist = new List<GameObject>();
        if (count > 1)
        {
            for (int a = 0; a < count; a++)
            {
                OUTline[a].GetComponent<Outline>().enabled = false;
                removelist.Add(OUTline[a]);
            }
            foreach (GameObject remove in removelist)
            {
                OUTline.Remove(remove);
            }
            removelist.Clear();

        }
    }

    void DestroyInstantiatedPrefabs()
    {
        justName.SetActive(false);
        foreach (GameObject obj in instantiatedPrefabs)
        {
            Destroy(obj);
        }

        // Clear the list
        //instantiatedPrefabs.Clear();
    }
    public void pickUpBtnClicked()
    {
        justName.SetActive(false);
        ItemNameImage.SetActive(false);
        pickbtn.SetActive(false);

        if (picUpOjectsList.Count == 0)
        {
            if (Hitobject)
            {
                pickedObj = _hitInfo.transform;
            }
            else { Hitobject = true; }

            if (pickedObj)
            {
                if (pickedObj.tag == "cayennepepper" || pickedObj.tag == "horsera" ||
                    pickedObj.tag == "salt" || pickedObj.tag == "thymedried" ||
                    pickedObj.tag == "blackpepper" || pickedObj.tag == "drilldried" || pickedObj.tag == "SalmonFillet")

                {
                    picUpOjectsList.Add(pickedObj);
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = MasalBoxapos.localPosition;
                    pickedRotation = MasalBoxapos.localRotation;
                    StartCoroutine(doubleok());

                }
                else if (pickedObj.name == "Large Plate Basic" || pickedObj.name == "Medium Plate Basic" ||
                    pickedObj.name == "Casserole , Basic" || pickedObj.name == "Small Bowl , Basic" ||
                    pickedObj.name == "Large Bowl , Basic" || pickedObj.name == "Small Plate,  Basic" ||
                    pickedObj.name == "Medium Plate,  Basic" || pickedObj.name == "Square plate, Basic" ||
                    pickedObj.name == "Small Deep PLate, Basic" || pickedObj.name == "Deep Plate, Basic")
                {
                    GeneratePrefab();

                }
                else if (pickedObj.tag == "Casserole , Basic" || pickedObj.tag == "Square plate, Basic" || pickedObj.tag == "Square plate, Basic")
                {
                    Audio.clip = Auidos[13];
                    Audio.Play();
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = SquareplateBasic.localPosition;
                    pickedRotation = SquareplateBasic.localRotation;
                    StartCoroutine(doubleok());
                    picUpOjectsList.Add(pickedObj);
                }
                else if (pickedObj.tag == "Deep Plate, Basic")
                {
                    Audio.clip = Auidos[13];
                    Audio.Play();
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = DeepPlateBasic.localPosition;
                    pickedRotation = DeepPlateBasic.localRotation;
                    StartCoroutine(doubleok());
                    picUpOjectsList.Add(pickedObj);
                }
                else if (pickedObj.tag == "ChickenBroute")
                {
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = ChickenBroutepos.localPosition;
                    pickedRotation = ChickenBroutepos.localRotation;
                    StartCoroutine(doubleok());
                    picUpOjectsList.Add(pickedObj);
                }
                else if (pickedObj.tag == "Large Bowl , Basic" || pickedObj.tag == "Medium Plate Basic" || pickedObj.tag == "Medium Plate,  Basic")
                {
                    Audio.clip = Auidos[13];
                    Audio.Play();
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = MediumPlateBasic.localPosition;
                    pickedRotation = MediumPlateBasic.localRotation;
                    StartCoroutine(doubleok());
                    picUpOjectsList.Add(pickedObj);
                }
                else if (pickedObj.tag == "Large Plate Basic")
                {
                    Audio.clip = Auidos[13];
                    Audio.Play();
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = LargePlateBasic.localPosition;
                    pickedRotation = LargePlateBasic.localRotation;
                    StartCoroutine(doubleok());
                    picUpOjectsList.Add(pickedObj);
                }
                else if (pickedObj.tag == "Small Plate,  Basic" || pickedObj.tag == "Small Deep PLate, Basic")
                {
                    Audio.clip = Auidos[13];
                    Audio.Play();
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = SmallPlateBasic.localPosition;
                    pickedRotation = SmallPlateBasic.localRotation;
                    StartCoroutine(doubleok());
                    picUpOjectsList.Add(pickedObj);
                }
                else if (pickedObj.tag == "Small Bowl , Basic")
                {
                    Audio.clip = Auidos[13];
                    Audio.Play();
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = DeepPlateBasic.localPosition;
                    pickedRotation = Quaternion.Euler(-10, 0, 0);
                    StartCoroutine(doubleok());
                    picUpOjectsList.Add(pickedObj);
                }
                else if (pickedObj.tag == "meat")
                {
                    Audio.clip = Auidos[12];
                    Audio.Play();
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = Meat.localPosition;
                    pickedRotation = Meat.localRotation;
                    StartCoroutine(doubleok());
                    picUpOjectsList.Add(pickedObj);
                }
                else if (pickedObj.tag == "Spoon")
                {
                    Audio.clip = Auidos[22];
                    Audio.Play();
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = Spatula.localPosition;
                    pickedRotation = Spatula.localRotation;
                    StartCoroutine(doubleok());
                    picUpOjectsList.Add(pickedObj);
                }
                else if (pickedObj.tag == "Sushi")
                {
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = Sushi.localPosition;
                    pickedRotation = Sushi.localRotation;
                    StartCoroutine(doubleok());
                    picUpOjectsList.Add(pickedObj);
                }
                else if (pickedObj.name == "Phone")
                {
                    Audio.clip = Auidos[23];
                    Audio.Play();
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = PhonePOs.localPosition;
                    pickedRotation = PhonePOs.localRotation;
                    StartCoroutine(doubleok());
                    picUpOjectsList.Add(pickedObj);
                }
                else if (pickedObj.tag == "Spatulla")
                {
                    Audio.clip = Auidos[22];
                    Audio.Play();
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = Spatula.localPosition;
                    pickedRotation = Spatula.localRotation;
                    StartCoroutine(doubleok());
                    picUpOjectsList.Add(pickedObj);
                }
                else if (pickedObj.tag == "Spoon1")
                {
                    Audio.clip = Auidos[22];
                    Audio.Play();
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = Spoon1POs.localPosition;
                    pickedRotation = Spoon1POs.localRotation;
                    StartCoroutine(doubleok());
                    picUpOjectsList.Add(pickedObj);
                }
                else if (pickedObj.tag == "Meat")
                {
                    GeneratePrefab();
                }
                else if (pickedObj.tag == "Timeknob")
                {
                    print("TimerKnob");
                    picUpOjectsList.Add(pickedObj);
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = timeknob.localPosition;
                    pickedRotation = timeknob.localRotation;
                    StartCoroutine(doubleok());
                    TimeSetBtn.SetActive(true);
                }
                else if (pickedObj.name == "fryerBasket")
                {
                    picUpOjectsList.Add(pickedObj);
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = fryerBasket.localPosition;
                    pickedRotation = fryerBasket.localRotation;
                    StartCoroutine(doubleok());
                }
                else if (pickedObj.tag == "PellaPan")
                {
                    print("PellaPan");
                    picUpOjectsList.Add(pickedObj);
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = PellaPan.localPosition;
                    pickedRotation = PellaPan.localRotation;
                    StartCoroutine(doubleok());
                }
                else if (pickedObj.tag == "Box" || pickedObj.tag == "JuicerJug")
                {
                    print("TimerKnob");
                    picUpOjectsList.Add(pickedObj);
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = juicerJUg.localPosition;
                    pickedRotation = juicerJUg.localRotation;
                    StartCoroutine(doubleok());
                }
                else if (pickedObj.tag == "lemon" || pickedObj.tag == "potato" || pickedObj.tag == "potato1"
                        || pickedObj.tag == "onion" || pickedObj.tag == "SalmonFillet" || pickedObj.tag == "tomato")
                {
                    print("nedjsn");
                    picUpOjectsList.Add(pickedObj);
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = OnionPos.localPosition;
                    pickedRotation = OnionPos.localRotation;
                    StartCoroutine(doubleok());
                }
                else if (pickedObj.tag == "fish")
                {
                    print("nedjsn");
                    picUpOjectsList.Add(pickedObj);
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = fishPos.localPosition;
                    pickedRotation = fishPos.localRotation;
                    StartCoroutine(doubleok());
                }
                else if (pickedObj.tag == "meat")
                {
                    print("nedjsn");
                    picUpOjectsList.Add(pickedObj);
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = Meat.localPosition;
                    pickedRotation = Meat.localRotation;
                    StartCoroutine(doubleok());
                }
                else if (pickedObj.tag == "Knief" || pickedObj.tag == "Blender")
                {
                    print("nedjsn");
                    picUpOjectsList.Add(pickedObj);
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = kniefpos.localPosition;
                    pickedRotation = kniefpos.localRotation;
                    StartCoroutine(doubleok());
                }
                else if (pickedObj.tag == "MilkCream")
                {
                    print("nedjsn");
                    picUpOjectsList.Add(pickedObj);
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = MilkCreamPOs.localPosition;
                    pickedRotation = MilkCreamPOs.localRotation;
                    StartCoroutine(doubleok());
                }
                else if (pickedObj.name == "Sunflower Oil" )
                {
                    print("nedjsn");
                    picUpOjectsList.Add(pickedObj);
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = SunflowerPOs.localPosition;
                    pickedRotation = SunflowerPOs.localRotation;
                    StartCoroutine(doubleok());
                }
                else if (pickedObj.tag == "FryPan")
                {
                    picUpOjectsList.Add(pickedObj);
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = frypanpos.localPosition;
                    pickedRotation = frypanpos.localRotation;
                    StartCoroutine(doubleok());

                }
                else if (pickedObj.tag == "BakingTray" || pickedObj.name == "Gas Cylinder")
                {
                    Audio.clip = Auidos[18];
                    Audio.Play();
                    picUpOjectsList.Add(pickedObj);
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = DishPos.localPosition;
                    pickedRotation = DishPos.localRotation;
                    StartCoroutine(doubleok());
                }
                else if (pickedObj.name == "CuttingBoard")
                {
                    picUpOjectsList.Add(pickedObj);
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = cutterBoardPos.localPosition;
                    pickedRotation = cutterBoardPos.localRotation;
                    StartCoroutine(doubleok());
                }
                else if (pickedObj.tag == "cuttertry")
                {
                    picUpOjectsList.Add(pickedObj);
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = cuttertry.localPosition;
                    pickedRotation = cuttertry.localRotation;
                    StartCoroutine(doubleok());
                }
                else if (pickedObj.tag == "BigPot")
                {
                    picUpOjectsList.Add(pickedObj);
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = BigPot.localPosition;
                    pickedRotation = BigPot.localRotation;
                    StartCoroutine(doubleok());
                }
                else if (pickedObj.name == "Bucket" || pickedObj.tag == "Stoll")
                {
                    picUpOjectsList.Add(pickedObj);
                    pickedObj.transform.parent = fpsContollar.transform;
                    PickupPosition = stolePos.localPosition;
                    pickedRotation = stolePos.localRotation;
                    StartCoroutine(doubleok());
                }
                else if (pickedObj.tag == "Lemon" || pickedObj.tag == "Tomato" || pickedObj.tag == "Onion" || pickedObj.tag == "Potato" || pickedObj.tag == "Fish" || pickedObj.name == "Salmon Fillet")
                {
                    OPTLPrefab();
                }
                if (pickedObj.GetComponent<Rigidbody>() != null)
                {
                    Rigidbody rb = pickedObj.GetComponent<Rigidbody>();
                    Destroy(rb);
                }
                if (pickedObj.tag == "BigPot" || pickedObj.name == "fryerBasket")
                {
                    MeshCollider meshcolider = pickedObj.GetComponent<MeshCollider>();
                    {
                        if (meshcolider != null)
                        {
                            meshcolider.convex = false;
                        }
                    }

                }
            }
        }
        else if (picUpOjectsList.Count != 0)
        {

            if (pickedObj.tag == "BakingTray" || pickedObj.tag == "cuttertry" || pickedObj.tag == "BigPot" || pickedObj.name == "CuttingBoard"
                || pickedObj.tag == "FryPan" || pickedObj.tag == "PellaPan" || pickedObj.name == "fryerBasket" ||
                pickedObj.tag == "Large Plate Basic" || pickedObj.tag == "Medium Plate Basic" ||
                pickedObj.tag == "Casserole , Basic" || pickedObj.tag == "Small Bowl , Basic" ||
                pickedObj.tag == "Large Bowl , Basic" || pickedObj.tag == "Small Plate,  Basic" ||
                pickedObj.tag == "Medium Plate,  Basic" || pickedObj.tag == "Square plate, Basic" ||
                pickedObj.tag == "Small Deep PLate, Basic" || pickedObj.tag == "Deep Plate, Basic")
            {

                if (pickedObj2.tag == "Lemon" || pickedObj2.tag == "Tomato" || pickedObj2.tag == "Onion" || pickedObj2.tag == "Potato" || pickedObj2.tag == "Fish" || pickedObj2.tag == "Meat")
                {
                    OPTL2Prefab();
                   

                }
                else if (pickedObj2.tag == "lemon" || pickedObj2.tag == "potato" || pickedObj2.tag == "meat" ||
                    pickedObj2.tag == "onion" || pickedObj2.tag == "SalmonFillet" || pickedObj2.tag == "fish" || pickedObj2.tag == "tomato"
                    || pickedObj2.tag == "cayennepepper" || pickedObj2.tag == "horsera" ||
                    pickedObj2.tag == "salt" || pickedObj2.tag == "thymedried" ||
                    pickedObj2.tag == "blackpepper" || pickedObj2.tag == "drilldried" || pickedObj2.tag == "SalmonFillet")
                {
                    picUpOjects2List.Add(pickedObj2);
                    pickedObj2.transform.parent = pickedObj.transform;
                    pickedObj2.transform.localPosition = new Vector3(0, 0.1f, 0);
                    Rigidbody rb2 = pickedObj2.GetComponent<Rigidbody>();
                    if (rb2 != null)
                    {
                        rb2.useGravity = true;
                        rb2.mass = 1;
                        rb2.angularDrag = 1f;
                    }
                }
            }
        }

    }
    public void OnclickCutbtn()
    {
        dropbtn.SetActive(false);
        DuringCutting = false;
        if (outline != null)
        {
            outline.GetComponent<Outline>().enabled = false;
        }
        dropbtn.SetActive(false);
        Cuttingbtn.SetActive(false);
        Cuttingknief.transform.gameObject.SetActive(true);
        Cuttingknief.position = pickedObj.position;
        TemppickobjHolder = pickedObj.gameObject;
        TemppickobjHolder.SetActive(false);
        pickedObj = Cuttingknief;
        PickupPosition = cutterBoard.transform.position + new Vector3(0, 0.5f, 0);
        yposition = PickupPosition;
        pickedRotation = Quaternion.Euler(0, 0, 0);
        StartCoroutine(doubleok());
        TV = 1;
        OnclickTvBtn1();
        Invoke("dropbuton", 0.5f);
    }
    public void dropbuton() { dropbtn.SetActive(false); }
    public void OnclickresetCutbtn()
    {
        Cuttingknief.transform.gameObject.SetActive(false);
        TemppickobjHolder.gameObject.SetActive(true);
        pickedObj = null;
        pickedObj = TemppickobjHolder.transform;
        print("picked onject" + pickedObj.tag);
        pickedObj.transform.position = Cuttingknief.position;
        PickupPosition = kniefpos.localPosition;
        pickedRotation = kniefpos.localRotation;
        StartCoroutine(doubleok());
        dropbtn.SetActive(false);
        DuringCutting = true;
        TV = 1;
        OnclickBackTvBtn1();
    }
    IEnumerator doubleok()
    {
        // print("Doubleok");
        Vector3 b = pickedObj.transform.localPosition;
        Vector3 targetpos = PickupPosition + new Vector3(0, 2, 0);
        float distance = Vector3.Distance(b, targetpos);
        while (distance >= 0.01f)
        {
            pickedObj.transform.localPosition = Vector3.Lerp(b, targetpos, 0.1f);
            //print("a");
            distance -= 0.5f;
            yield return null;
        }
        StartCoroutine(ok());
    }
    IEnumerator ok()
    {
        Quaternion a = pickedObj.transform.localRotation;
        Vector3 b = pickedObj.transform.localPosition;
        targetRotation = pickedRotation;
        Vector3 targetpos = PickupPosition;
        float distance = Vector3.Distance(b, targetpos);
        while (distance >= 0.01f)
        {
            pickedObj.transform.localPosition = Vector3.Lerp(b, targetpos, 0.1f * Time.deltaTime);
            pickedObj.transform.localRotation = Quaternion.Slerp(a, targetRotation, 0.1f * Time.deltaTime);
            distance -= 0.5f;
            yield return null;
        }
        pickedObj.transform.localRotation = targetRotation;
        pickedObj.transform.localPosition = targetpos;
    }
    public void OnRotatebtnClickLeft()
    {
        if (Rotate)
        {
            StartCoroutine(RotateObjLeft());
            Rotate = false;
        }
    }
    public void OnRotatebtnClickRight()
    {
        if (Rotate)
        {
            StartCoroutine(RotateObjRight());
            Rotate = false;
        }

    }
    public void OnclickDrop()
    {
        pickedObj.parent = null;
        MeshCollider meshCollider = pickedObj.GetComponent<MeshCollider>();
        if (meshCollider != null)
        {
            meshCollider.convex = true;
        }
        if (pickedObj.GetComponent<Rigidbody>() == null)
            pickedObj.gameObject.AddComponent<Rigidbody>();
        Rigidbody rb = pickedObj.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.drag = 5f;
        rb.angularDrag = 5f;
        if (pickedObj.tag == "Timeknob")
        {
            rb.AddRelativeForce(-Vector3.forward * 3f, ForceMode.Impulse);
            TimeSetBtn.SetActive(false);
        }
        else if (pickedObj.name == "Phone")
        {
            rb.AddRelativeForce(-Vector3.forward * 6f, ForceMode.Impulse);

        }
        else { rb.AddRelativeForce(Vector3.forward * 3f, ForceMode.Impulse); }
        if (pickedObj.name == "Phone")
        {
            Audio.clip = Auidos[24];
            Audio.Play();
        }
        else if (pickedObj.name == "Timeknob")
        {
            Audio.clip = Auidos[25];
            Audio.Play();
        }
        else if (pickedObj.tag == "ChickenBroute" && pickedObj.tag == "MilkCream")
        {
            Audio.clip = Auidos[26];
            Audio.Play();
        }
        else if (pickedObj.tag == "Spatulla"|| pickedObj.tag == "Spoon" || pickedObj.tag == "Spoon1")
        {
            Audio.clip = Auidos[22];
            Audio.Play();
        }
        pickedObj = null;
        picUpOjectsList.Clear();
    } 
    private Vector3 raycastposition;
    public void OnClickPlacebtn()
    {
        pickedObj.parent = null;
        raycastposition = raycast_position;
        if ((pickedObj.tag == "lemon" || pickedObj.tag == "tomato" || pickedObj.tag == "onion" ||
                     pickedObj.tag == "potato" || pickedObj.tag == "potato1" || pickedObj.tag == "fish" || pickedObj.tag == "meat" || pickedObj.tag == "SalmonFillet")
                     && (pickedObj2.tag == "BakingTray" || pickedObj2.tag == "cuttertry" || pickedObj2.tag == "BigPot" || pickedObj2.tag == "CuttingBoard"
                 || pickedObj2.tag == "FryPan" || pickedObj2.tag == "PellaPan" || pickedObj2.name == "fryerBasket" ||
                 pickedObj2.tag == "Large Plate Basic" || pickedObj2.tag == "Medium Plate Basic" ||
                 pickedObj2.tag == "Casserole , Basic" || pickedObj2.tag == "Small Bowl , Basic" ||
                 pickedObj2.tag == "Large Bowl , Basic" || pickedObj2.tag == "Small Plate,  Basic" ||
                 pickedObj2.tag == "Medium Plate,  Basic" || pickedObj2.tag == "Square plate, Basic" ||
                 pickedObj2.tag == "Small Deep PLate, Basic" || pickedObj2.tag == "Deep Plate, Basic"))
        {
            raycastposition = _hitInfo.transform.position;
        }
            
        StartCoroutine(PlaceObject(raycastposition));
    }
    IEnumerator PlaceObject(Vector3 hitTransform)
    {
        Quaternion a = Quaternion.Euler(0, 90, 0);
        Vector3 hitPosition = hitTransform + new Vector3(0, 0.3f, 0.1f);
        // Move the picked object smoothly to the hit position
        while (Vector3.Distance(pickedObj.position, hitPosition) > 0.1f)
        {
            pickedObj.position = Vector3.Lerp(pickedObj.position, hitPosition, Time.deltaTime * 2f);
            pickedObj.transform.rotation = Quaternion.Slerp(a, targetRotation, 0.1f * Time.deltaTime);
            yield return null;
        }
        if (pickedObj.tag != "cuttertry" && pickedObj.name != "fryerBasket" && pickedObj.tag!= "BigPot")
        {
            MeshCollider meshCollider = pickedObj.GetComponent<MeshCollider>();
            if (meshCollider != null)
            {
                meshCollider.convex = true;
            }
        }
        StartCoroutine(PlaceObject2(raycastposition));
    }
    IEnumerator PlaceObject2(Vector3 hitTransform)
    {
       
        Quaternion a = Quaternion.Euler(0, 0, 0);
        Vector3 hitPosition = hitTransform + new Vector3(0, 0.1f, 0);
        if (pickedObj.tag == "BigPot")
        {
            hitPosition = hitTransform + new Vector3(0, 0.3f, 0);
        }
        // Move the picked object smoothly to the hit position
        while (Vector3.Distance(pickedObj.position, hitPosition) > 0.01f)
        {
            pickedObj.position = Vector3.Lerp(pickedObj.position, hitPosition, Time.deltaTime * 2f);
            pickedObj.transform.rotation = Quaternion.Slerp(a, targetRotation, 0.1f * Time.deltaTime);
            yield return null;
        }

        // Ensure the object is precisely at the hit position
        pickedObj.position = hitPosition;
        if (pickedObj.GetComponent<Rigidbody>() == null)
            pickedObj.gameObject.AddComponent<Rigidbody>();
        Rigidbody rb = pickedObj.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.drag = 5f;
        rb.angularDrag = 5f;
        if (pickedObj.tag == "Timeknob")
        {
            TimeSetBtn.SetActive(false);
        }
        else if (pickedObj.tag == "cayennepepper" || pickedObj.tag == "horsera" ||
                    pickedObj.tag == "salt" || pickedObj.tag == "thymedried" ||
                    pickedObj.tag == "blackpepper" || pickedObj.tag == "drilldried" || pickedObj.tag == "SalmonFillet")
        {
            Audio.clip = Auidos[11];
            Audio.Play();
        }
        else if(pickedObj.tag == "FryPan" && pickedObj.tag == "BigPot")
        {
            Audio.clip = Auidos[12];
            Audio.Play();
        }
        else if(pickedObj.tag == "Large Plate Basic" || pickedObj.tag == "Medium Plate Basic" ||
                pickedObj.tag == "Casserole , Basic" || pickedObj.tag == "Small Bowl , Basic" ||
                pickedObj.tag == "Large Bowl , Basic" || pickedObj.tag == "Small Plate,  Basic" ||
                pickedObj.tag == "Medium Plate,  Basic" || pickedObj.tag == "Square plate, Basic" ||
                pickedObj.tag == "Small Deep PLate, Basic" || pickedObj.tag == "Deep Plate, Basic")
        {
            Audio.clip = Auidos[14];
            Audio.Play();
        }
        else if (pickedObj.name == "CuttingBoard")
        {
            Audio.clip = Auidos[15];
            Audio.Play();
        }
        else if (pickedObj.tag == "BakingTray" )
        {
            Audio.clip = Auidos[19];
            Audio.Play();
        }
        pickedObj = null;
        picUpOjectsList.Clear();
    }
    IEnumerator RotateObjLeft()
    {
        // print("Coroutine Start");
        initialRotation = pickedObj.transform.localRotation;
        Quaternion UpdatedRotation = Quaternion.Euler(0, 0, initialRotation.eulerAngles.z + 20);
        targetRotation = UpdatedRotation;
        float elapsedTime = 0f;
        while (elapsedTime < rotationSpeed)
        {
            pickedObj.transform.localRotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / rotationSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        print(targetRotation);
        pickedObj.transform.localRotation = targetRotation;
        print(pickedObj.transform.localRotation);
        Invoke("StopCoroutineLeft", 0.1f);

    }
    IEnumerator RotateObjRight()
    {
        initialRotation = pickedObj.transform.localRotation;
        Quaternion UpdatedRotation = Quaternion.Euler(0, 0, initialRotation.eulerAngles.z - 20);
        targetRotation = UpdatedRotation;
        float elapsedTime = 0f;
        while (elapsedTime < rotationSpeed)
        {
            pickedObj.transform.localRotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / rotationSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        print(targetRotation);
        pickedObj.transform.localRotation = targetRotation;
        print(pickedObj.transform.localRotation);
        Invoke("StopCoroutineRight", 0.1f);

    }
    public void StopCoroutineLeft()
    {
        print("coroutine Stop");
        StopCoroutine(RotateObjLeft());
        Rotate = true;
    }
    public void StopCoroutineRight()
    {
        print("coroutine Stop");
        StopCoroutine(RotateObjRight());
        Rotate = true;
    }
    public void OpenDoor()
    {
        Transform Button = _hitInfo.transform;
        if (Button.tag == "Left")
        {
            Audio.clip = Auidos[16];
            Audio.Play();
            float currentRotationY = Button.rotation.eulerAngles.y;
            print(" left dooe close" + currentRotationY);
            Quaternion targetRotation = Quaternion.Euler(0, 90, 0);
            StartCoroutine(RotateToTarget(Button, targetRotation));
        }
        else if (Button.tag == "Right")
        {
            Audio.clip = Auidos[16];
            Audio.Play();
            float currentRotationY = Button.rotation.eulerAngles.y;
            Quaternion targetRotation = Quaternion.Euler(0, -90, 0);
            StartCoroutine(RotateToTarget(Button, targetRotation));
        }
        if (Button.transform.name == "Fridgedrawer1")
        {
            Audio.clip = Auidos[1];
            Audio.Play();
            Fridgedrawer1.SetBool("open", true);
        }
        if (Button.transform.name == "Fridgedrawer2")
        {
            Audio.clip = Auidos[1];
            Audio.Play();
            Fridgedrawer2.SetBool("open", true);

        }
    }

    public void CloseDoor()
    {
        Transform Button = _hitInfo.transform;
        if (Button.transform.name == "Fridgedrawer1")
        {
            Audio.clip = Auidos[2];
            Audio.Play();
            Fridgedrawer1.SetBool("open", false);
        }
        if (Button.transform.name == "Fridgedrawer2")
        {
            Audio.clip = Auidos[2];
            Audio.Play();
            Fridgedrawer2.SetBool("open", false);
        }
        else
        {
            Audio.clip = Auidos[17];
            Audio.Play();
            Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
            StartCoroutine(RotateToTarget(Button, targetRotation));
        }
    }

    public void PLaceBtn()
    {
        print("nnnnnnnnnnnnn");
        PlacePosition = _hitInfo.transform.position;
        if (_hitInfo.transform.name == "Pro Cutter")
        {
            PlacePosition = PlaceCuttertTry.position ;
            StartCoroutine(PlaceObject1());
        }
        else if (_hitInfo.collider.gameObject.tag == "OvenPlace")
        {
            pickedObj.parent = null;
            PlacePosition = _hitInfo.collider.transform.position + new Vector3(0, 0.01f,0 );
            StartCoroutine(PlaceObject2());
            if(pickedObj.childCount > 1)
            {
                Baking = true;
            }
        }
        else if (_hitInfo.transform.name == "Deep fryer 02")
        {
            PlacePosition = fryerright.position;
            StartCoroutine(PlaceObject1());
        }
        else if (_hitInfo.transform.name == "Deep Fryer 01")
        {
            PlacePosition = fryerleft.position;
            StartCoroutine(PlaceObject1());
        }
        else if (_hitInfo.transform.tag == "Burner")
        {
            if (pickedObj.tag == "BigPot")
            {
                if (pickedObj.name == "Big Pot")
                {
                    pickedObj.parent = null;
                    PlacePosition = PlacePosition + new Vector3(0, 0.20f, 0);
                    StartCoroutine(PlaceObject2());
                }
                else if (pickedObj.name == "Small Pot")
                {
                    pickedObj.parent = null;
                    PlacePosition = PlacePosition + new Vector3(0, 0.05f, 0);
                    StartCoroutine(PlaceObject2());
                }
            }
            else
            {
                PlacePosition = PlacePosition + new Vector3(0, 0.1f, 0);
                StartCoroutine(PlaceObject1());

            }
        }
        else if (_hitInfo.transform.name == "Juicer Base")
        {
            PlacePosition = juicerJUgPLacepos.position;
            StartCoroutine(PlaceObject1());
        }
        else if (_hitInfo.transform.name == "Phone Holder")
        {
            PlacePosition = PhonePlace.position;
            StartCoroutine(PlaceObject1());
        }
        else
        {
            StartCoroutine(PlaceObject1());
        }
    }
    IEnumerator PlaceObject1()
    {
        pickedObj.parent = null;
       
        Vector3 hitPosition = PlacePosition + new Vector3(0, 0.3f, 0);
        
        // Move the picked object smoothly to the hit position
        while (Vector3.Distance(pickedObj.position, hitPosition) > 0.1f)
        {
            pickedObj.position = Vector3.Lerp(pickedObj.position, hitPosition, Time.deltaTime * 2f);
            yield return null;
        }
        pickedObj.transform.position = hitPosition;
        StartCoroutine(PlaceObject2());
    }

    IEnumerator PlaceObject2()
    {
        Vector3 hitPosition = PlacePosition;
        Quaternion a = Quaternion.Euler(0, 0, 0);
        // Move the picked object smoothly to the hit position
        while (Vector3.Distance(pickedObj.position, hitPosition) > 0.01f)
        {
            pickedObj.position = Vector3.Lerp(pickedObj.position, hitPosition, Time.deltaTime * 2f);
            pickedObj.transform.rotation = Quaternion.Slerp(a, targetRotation, 0.1f * Time.deltaTime);
            yield return null;
        }

        // Ensure the object is precisely at the hit position
        pickedObj.position = hitPosition;
        pickedObj = null;
        picUpOjectsList.Clear();
    }

    public void OnclickTvBtn1()
    {
        if (TV == 1)
        {
            controller.instance.TargetTV(DishCamera, 25, 2);
        }
        if (TV == 2)
        {
            controller.instance.TargetTV(LaptopPOs, 25, 2);
        }
    }

    public void OnclickBackTvBtn1()
    {
        if (TV == 1)
        {
            controller.instance.BackFromTV();
        }
    }
    void OPTLPrefab()
    {
        if (pickedObj.tag == "Lemon")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[11], pickedObj.transform.position, Quaternion.identity);
            pickedObj = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
            pickedObj.transform.parent = fpsContollar.transform;
            PickupPosition = OnionPos.localPosition;
            pickedRotation = OnionPos.localRotation;
        }
        else if (pickedObj.tag == "Potato")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[12], pickedObj.transform.position, Quaternion.identity);
            potatoclone++;
            instantiatedObject.name = instantiatedObject.name + potatoclone;
            pickedObj = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
            pickedObj.transform.parent = fpsContollar.transform;
            PickupPosition = OnionPos.localPosition;
            pickedRotation = OnionPos.localRotation;
        }
        else if (pickedObj.tag == "Tomato")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[13], pickedObj.transform.position, Quaternion.identity);
            pickedObj = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
            pickedObj.transform.parent = fpsContollar.transform;
            PickupPosition = OnionPos.localPosition;
            pickedRotation = OnionPos.localRotation;
        }
        else if (pickedObj.tag == "Onion")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[10], pickedObj.transform.position, Quaternion.identity);
            pickedObj = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
            pickedObj.transform.parent = fpsContollar.transform;
            PickupPosition = OnionPos.localPosition;
            pickedRotation = OnionPos.localRotation;
        }
        else if (pickedObj.name == "Salmon Fillet")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[16], pickedObj.transform.position, Quaternion.identity);
            pickedObj = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
            pickedObj.transform.parent = fpsContollar.transform;
            PickupPosition = OnionPos.localPosition;
            pickedRotation = OnionPos.localRotation;
        }
        if (pickedObj.tag == "Fish")
        {
            print("fish generated");
            GameObject instantiatedObject = Instantiate(objectPrefabs[14], pickedObj.transform.position, Quaternion.identity);
            pickedObj = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
            pickedObj.transform.parent = fpsContollar.transform;
            PickupPosition = fishPos.localPosition;
            pickedRotation = fishPos.localRotation;
        }
        picUpOjectsList.Add(pickedObj);
        StartCoroutine(doubleok());

    }

    void OPTL2Prefab()
    {
        if (pickedObj2.tag == "Lemon")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[11], pickedObj.transform.position, Quaternion.identity);
            pickedObj2 = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
        }
        else if (pickedObj2.tag == "Potato")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[12], pickedObj.transform.position, Quaternion.identity);
            potatoclone++;
            instantiatedObject.name = instantiatedObject.name +potatoclone;
            pickedObj2 = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
        }
        else if (pickedObj2.tag == "Tomato")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[13], pickedObj.transform.position, Quaternion.identity);
            pickedObj2 = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
        }
        else if (pickedObj2.tag == "Onion")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[10], pickedObj.transform.position, Quaternion.identity);
            pickedObj2 = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
        }
        else if (pickedObj2.tag == "Fish")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[14], pickedObj.transform.position, Quaternion.identity);
            pickedObj2 = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
        }
        picUpOjects2List.Add(pickedObj2);
        pickedObj2.transform.parent = pickedObj.transform;
        pickedObj2.transform.localPosition = new Vector3(0, 0.1f, 0);
        Rigidbody rb2 = pickedObj2.GetComponent<Rigidbody>();
        rb2.useGravity = true;
        rb2.mass = 5;
        rb2.angularDrag = 2f;
        rb2.drag = 2f;
       // rb2.isKinematic = true;
        Invoke("rigidbodyoff", 1f);

    }

    public void rigidbodyoff()
    {
        Rigidbody rb2 = pickedObj2.GetComponent<Rigidbody>();
        Destroy(rb2);
    }

    void GeneratePrefab()
    {
        picUpOjectsList.Add(pickedObj);
        if (pickedObj.tag == "Casserole , Basic")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[0], pickedObj.transform.position, Quaternion.identity);
            pickedObj = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
            Audio.clip = Auidos[13];
            Audio.Play();
            pickedObj.transform.parent = fpsContollar.transform;
            PickupPosition = SquareplateBasic.localPosition;
            pickedRotation = SquareplateBasic.localRotation;
        }
        else if (pickedObj.tag == "Deep Plate, Basic")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[1], pickedObj.transform.position, Quaternion.identity);
            Audio.clip = Auidos[13];
            Audio.Play();
            pickedObj = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
            Audio.clip = Auidos[12];
            Audio.Play();
            pickedObj.transform.parent = fpsContollar.transform;
            PickupPosition = DeepPlateBasic.localPosition;
            pickedRotation = DeepPlateBasic.localRotation;
        }
        else if (pickedObj.tag == "Large Bowl , Basic")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[2], pickedObj.transform.position, Quaternion.identity);
            Audio.clip = Auidos[13];
            Audio.Play();
            pickedObj = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
            pickedObj.transform.parent = fpsContollar.transform;
            PickupPosition = MediumPlateBasic.localPosition;
            pickedRotation = MediumPlateBasic.localRotation;
        }
        else if (pickedObj.tag == "Large Plate Basic")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[3], pickedObj.transform.position, Quaternion.identity);
            Audio.clip = Auidos[13];
            Audio.Play();
            pickedObj = instantiatedObject.transform; pickedObj.transform.parent = fpsContollar.transform;
            pickedObj.transform.parent = fpsContollar.transform;
            InstantiateObject.Add(instantiatedObject);
            PickupPosition = LargePlateBasic.localPosition;
            pickedRotation = LargePlateBasic.localRotation;
        }
        else if (pickedObj.tag == "Medium Plate Basic")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[4], pickedObj.transform.position, Quaternion.identity);
            Audio.clip = Auidos[13];
            Audio.Play();
            pickedObj = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
            pickedObj.transform.parent = fpsContollar.transform;
            PickupPosition = MediumPlateBasic.localPosition;
            pickedRotation = MediumPlateBasic.localRotation;
        }
        else if (pickedObj.tag == "Small Plate,  Basic")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[5], pickedObj.transform.position, Quaternion.identity);
            Audio.clip = Auidos[13];
            Audio.Play();
            pickedObj = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
            pickedObj.transform.parent = fpsContollar.transform;
            PickupPosition = SmallPlateBasic.localPosition;
            pickedRotation = SmallPlateBasic.localRotation;
        }
        else if (pickedObj.tag == "Small Deep PLate, Basic")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[6], pickedObj.transform.position, Quaternion.identity);
            Audio.clip = Auidos[13];
            Audio.Play();
            pickedObj = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
            pickedObj.transform.parent = fpsContollar.transform;
            PickupPosition = SmallPlateBasic.localPosition;
            pickedRotation = SmallPlateBasic.localRotation;
        }
        else if (pickedObj.tag == "Small Bowl , Basic")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[7], pickedObj.transform.position, Quaternion.identity);
            Audio.clip = Auidos[13];
            Audio.Play();
            pickedObj = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
            pickedObj.transform.parent = fpsContollar.transform;
            PickupPosition = DeepPlateBasic.localPosition;
            pickedRotation = Quaternion.Euler(-10, 0, 0);
        }
        else if (pickedObj.tag == "Square plate, Basic")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[8], pickedObj.transform.position, Quaternion.identity);
            Audio.clip = Auidos[13];
            Audio.Play();
            pickedObj = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
            pickedObj.transform.parent = fpsContollar.transform;
            PickupPosition = SquareplateBasic.localPosition;
            pickedRotation = SquareplateBasic.localRotation;
        }
        else if (pickedObj.tag == "Medium Plate,  Basic")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[9], pickedObj.transform.position, Quaternion.identity);
            Audio.clip = Auidos[13];
            Audio.Play();
            pickedObj = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
            pickedObj.transform.parent = fpsContollar.transform;
            PickupPosition = MediumPlateBasic.localPosition;
            pickedRotation = MediumPlateBasic.localRotation;
        }
        else if (pickedObj.tag == "Meat")
        {
            GameObject instantiatedObject = Instantiate(objectPrefabs[15], pickedObj.transform.position, Quaternion.identity);
            pickedObj = instantiatedObject.transform;
            InstantiateObject.Add(instantiatedObject);
            pickedObj.transform.parent = fpsContollar.transform;
            PickupPosition = Meat.localPosition;
            pickedRotation = Meat.localRotation;
        }


        StartCoroutine(doubleok());
    }

    Transform dustbin;
    public void OnclickDustbtn()
    {
         dustbin = _hitInfo.transform;
        float currentRotationY = dustbin.rotation.eulerAngles.y;
        if (currentRotationY < 10)
        {
            Quaternion targetRotation = Quaternion.Euler(25, 0, 0);
            StartCoroutine(RotateToTarget(dustbin, targetRotation));
        }
        pickedObj.parent = null;
        if (dustbin.name== "dustbin opener 2")
        {
            StartCoroutine(DustObject(dustpos2.position, dustbin.gameObject));
        }
        else if (dustbin.name == "dustbin opener 1")
        {
            StartCoroutine(DustObject(dustpos1.position, dustbin.gameObject));
        }
    }
    IEnumerator DustObject(Vector3 hitTransform,GameObject DustObj)
    {
        Vector3 hitPosition = hitTransform;
        // Move the picked object smoothly to the hit position
        while (Vector3.Distance(pickedObj.position, hitPosition) > 0.1f)
        {
            pickedObj.position = Vector3.Lerp(pickedObj.position, hitPosition, Time.deltaTime * 4f);

            yield return null;
        }
        MeshCollider meshCollider = pickedObj.GetComponent<MeshCollider>();
        if (meshCollider != null)
        {
            //meshCollider.convex = false;
            Destroy(meshCollider);
        }
        if (pickedObj.GetComponent<Rigidbody>() == null)
            pickedObj.gameObject.AddComponent<Rigidbody>();
        Rigidbody rb = pickedObj.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        float currentRotationX = dustbin.rotation.eulerAngles.x;
        Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
        StartCoroutine(RotateToTarget(dustbin, targetRotation));
        pickedObj = null;
        picUpOjectsList.Clear();
        Destroy(DustObj);
    }
    public bool OnMaterial = false;
    public bool OffMaterial = false;
    public void StoveBtnClick()
    {
        Transform Button = _hitInfo.transform;

        if (Button.name == "Oven")
        {
            float currentRotationX = Button.rotation.eulerAngles.x;
            if (currentRotationX < 10 || currentRotationX > 300)
            {
                friedfish = true;
                Audio.clip = Auidos[8];
                Audio.Play();
                Quaternion targetRotation = Quaternion.Euler(90, 0, 0);
                StartCoroutine(RotateToTarget(Button, targetRotation));
                friedfish = true;
            }
            else if (currentRotationX > 60 && currentRotationX < 300)
            {
                friedfish = false;
                Audio.clip = Auidos[9];
                Audio.Play();
                Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
                StartCoroutine(RotateToTarget(Button, targetRotation));
                friedfish = false;
            }
        }
        else if (Button.name == "Oven1")
        {
            float currentRotationX = Button.rotation.eulerAngles.x;
            if (currentRotationX < 10 || currentRotationX > 300)
            {
                friedfish1 = true;
                Audio.clip = Auidos[8];
                Audio.Play();
                Quaternion targetRotation = Quaternion.Euler(90, 0, 0);
                StartCoroutine(RotateToTarget(Button, targetRotation));
                friedfish = true;
            }
            else if (currentRotationX > 60 && currentRotationX < 300)
            {
                friedfish1 = false;
                Audio.clip = Auidos[9];
                Audio.Play();
                Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
                StartCoroutine(RotateToTarget(Button, targetRotation));
                friedfish = false;
            }
        }
        else if (Button.name == "Juicer Button")
        {
            float currentRotationX = Button.rotation.eulerAngles.x;
            if (currentRotationX < 10 || currentRotationX > 300)
            {
                Audio.clip = Auidos[8];
                Audio.Play();
                Quaternion targetRotation = Quaternion.Euler(90, 0, 0);
                StartCoroutine(RotateToTarget(Button, targetRotation));
            }
            else if (currentRotationX > 60 && currentRotationX < 300)
            {
                Audio.clip = Auidos[9];
                Audio.Play();
                Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
                StartCoroutine(RotateToTarget(Button, targetRotation));
            }
        }
        else if (Button.name == "Water")
        {
            float currentRotationX = Button.rotation.eulerAngles.x;
            if (currentRotationX < 10 || currentRotationX > 300)
            {
                Audio.clip = Auidos[10];
                Audio.loop = true;
                Audio.Play();
                Quaternion targetRotation = Quaternion.Euler(-90, 0, 0);
                StartCoroutine(RotateToTarget(Button, targetRotation));
                Waters = true;
            }
            else if (currentRotationX > 60 && currentRotationX < 300)
            {
                Audio.loop = false;
                Audio.clip = null;
                Waters = false;
                Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
                StartCoroutine(RotateToTarget(Button, targetRotation));
            }
        }
        else
        {
            float currentRotationY = Button.rotation.eulerAngles.y;
            Audio.clip = Auidos[7];
            Audio.Play();
            if (currentRotationY < 10 || currentRotationY > 300)
            {
                Quaternion targetRotation = Quaternion.Euler(0, 90, 0);
                StartCoroutine(RotateToTarget(Button, targetRotation));
                if (Button.name == "DeepFryer"|| Button.name == "Stove Right 1" ||Button.name == "Stove Right 2"||
                Button.name == "Stove Left 1"||Button.name == "Stove Left 2")
                {
                    OnMaterial = true;
                    OffMaterial = false;
                }
            }
            else if (currentRotationY > 60 && currentRotationY < 300)
            {    
                Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
                StartCoroutine(RotateToTarget(Button, targetRotation));
                if (Button.name == "DeepFryer" ||Button.name == "DeepFryer1" || Button.name == "Stove Right 1" || Button.name == "Stove Right 2" ||
                Button.name == "Stove Left 1" || Button.name == "Stove Left 2")
                {
                    OffMaterial = true;
                    OnMaterial = false;
                }
            }
        }
        
    }

    IEnumerator RotateToTarget(Transform Button, Quaternion targetRotation)
    {
        Quaternion targetQuaternion = targetRotation;

        while (Quaternion.Angle(Button.rotation, targetQuaternion) > 0.1f)
        {
            Button.rotation = Quaternion.RotateTowards(Button.rotation, targetQuaternion, 90 * Time.deltaTime);
            yield return null;
        }
        Button.rotation = targetQuaternion;
        if (Button.name == "Water")
        {
            if (Waters)
            {
                Water.SetActive(true);
            }
            else
                Water.SetActive(false);
        }
        if (OnMaterial)
        {
            if (Button.name == "DeepFryer")
            {
                PotatoFrieBtn = true;
            }
            else if (Button.name == "Stove Right 1")
            {
                Renderer renderer1 = burner1color.GetComponent<Renderer>();
                renderer1.material.color = Color.red;
                renderer1.material.SetColor("_EmissionColor", newEmissionColor);
                burner1 = true;
            }
            else if (Button.name == "Stove Right 2")
            {
                Renderer renderer2 = burner2color.GetComponent<Renderer>();
                renderer2.material.color = Color.red;
                renderer2.material.SetColor("_EmissionColor", newEmissionColor);
                burner2 = true;
            }
            else if (Button.name == "Stove Left 1")
            {
                Renderer renderer3 = burner3color.GetComponent<Renderer>();
                renderer3.material.color = Color.red;
                renderer3.material.SetColor("_EmissionColor", newEmissionColor);
                burner3 = true;
            }
            else if (Button.name == "Stove Left 2")
            {
                Renderer renderer4 = burner4color.GetComponent<Renderer>();
                renderer4.material.color = Color.red;
                renderer4.material.SetColor("_EmissionColor", newEmissionColor);
                burner4 = true;
            }
        }
        else if (OffMaterial)
        {
            if (Button.name == "DeepFryer")
            {
                PotatoFrieBtn = false;
            }
            else if (Button.name == "Stove Right 1")
            {
                Renderer renderer1 = burner1color.GetComponent<Renderer>();
                renderer1.material.color = Color.white;
                renderer1.material.SetColor("_EmissionColor", Color.white);
                burner1 = false;
            }
            else if (Button.name == "Stove Right 2")
            {
                Renderer renderer2 = burner2color.GetComponent<Renderer>();
                renderer2.material.color = Color.white;
                renderer2.material.SetColor("_EmissionColor", Color.white);
                burner2 = false;
            }
            else if (Button.name == "Stove Left 1")
            {
                Renderer renderer3 = burner3color.GetComponent<Renderer>();
                renderer3.material.color = Color.white;
                renderer3.material.SetColor("_EmissionColor", Color.white);
                burner3 = false;
            }
            else if (Button.name == "Stove Left 2")
            {
                Renderer renderer4 = burner4color.GetComponent<Renderer>();
                renderer4.material.color = Color.white;
                renderer4.material.SetColor("_EmissionColor", Color.white);
                burner4 = false;
            }
        }
        
    }
    public void TimeSet()
    {
        pickedObj.parent = null;
        PickupPosition = TimeSetPos.position;
        pickedRotation = TimeSetPos.rotation;
        StartCoroutine(doubleok());
        if(pickedObj.name== "Knob1")
        {
            TimeKnob1.instance.CurrentTime();
        }
        else if (pickedObj.name == "Fryer Knob")
        {
            Timeknob2.instance.CurrentTime();
        }
        else if (pickedObj.name == "OvenTimeKnob")
        {
            Timeknob3.instance.CurrentTime();
        }
        else if (pickedObj.name == "Knob4")
        {
            TimeKnob4.instance.CurrentTime();
        }
        pickedObj.GetChild(1).transform.gameObject.SetActive(true);
        EnvCamera.transform.position = fpsContollar.transform.position;
        EnvCamera.transform.rotation = fpsContollar.transform.rotation;
        EnvCamera.SetActive(true);
        FPSCotroller.SetActive(false);
        Cf2.SetActive(false);
        TimeSetBtn.SetActive(false);

    }

    public void BackFromTimeSet()
    {
        pickedObj.parent = fpsContollar.transform;
        PickupPosition = timeknob.localPosition;
        pickedRotation = timeknob.localRotation;
        StartCoroutine(doubleok());
        pickedObj.GetChild(1).transform.gameObject.SetActive(false);
        FPSCotroller.SetActive(true);
        EnvCamera.SetActive(false);
        Cf2.SetActive(true);
        TimeSetBtn.SetActive(true);
    }

    public static Vector3 yposition;
    public void SpicebtnClick()
    {
        DuringCutting = false;
        dropbtn.SetActive(false);
        EnvCamera.transform.position = fpsContollar.transform.position;
        EnvCamera.transform.rotation = fpsContollar.transform.rotation;
        pickedObj.parent = null;
        PickupPosition = _hitInfo.transform.position + new Vector3(0, 0.2f, 0f);
        yposition = PickupPosition;
        pickedRotation = Quaternion.Euler(150, 90, 0);
        pickedObj.GetChild(0).gameObject.SetActive(true);
        int a = 0; 
        if (pickedObj.tag == "cayennepepper")
        {
            foreach (Transform child in _hitInfo.transform)
            {
                if (child.tag == "Cayenna Pepper")
                {
                    a++;
                }
            }
        }
        else if (pickedObj.tag == "horsera")
        {
            foreach (Transform child in _hitInfo.transform)
            {
                if (child.tag == "Horseria")
                {
                    a++;
                }
            }
        }
        else if (pickedObj.tag == "salt")
        {
            foreach (Transform child in _hitInfo.transform)
            {
                if (child.tag == "Salt.")
                {
                    a++;
                }
            }
        }
        else if (pickedObj.tag == "thymedried")
        {
            foreach (Transform child in _hitInfo.transform)
            {
                if (child.tag == "Thyme Dried")
                {
                    a++;
                }
            }
        }
        else if (pickedObj.tag == "blackpepper")
        {
            foreach (Transform child in _hitInfo.transform)
            {
                if (child.tag == "BlackPepper")
                {
                    a++;
                }
            }
        }
        else if (pickedObj.tag == "drilldried")
        {
            foreach (Transform child in _hitInfo.transform)
            {
                if (child.tag == "Dril Dried")
                {
                    a++;
                }
            }

        }
        SpicerackRayCast.SpiceInt = a;
        pickedObj.GetChild(2).transform.GetChild(0).transform.GetChild(2).gameObject.GetComponent<Text>().text = a.ToString() + "g";
        pickedObj.GetChild(2).gameObject.SetActive(true);
        EnvCamera.SetActive(true);
        FPSCotroller.SetActive(false);
        StartCoroutine(doubleok());
        Spicebtn.SetActive(false);
        BackFromSpice.SetActive(true);
        porespicebtn.SetActive(true);
    }

    public void BackSpicebtnClick()
    {
        DuringCutting = true;
        pickedObj.GetChild(0).gameObject.SetActive(false);
        pickedObj.GetChild(2).gameObject.SetActive(false);
        FPSCotroller.SetActive(true);
        EnvCamera.SetActive(false);
        pickedObj.transform.parent = fpsContollar.transform;
        PickupPosition = MasalBoxapos.localPosition;
        pickedRotation = MasalBoxapos.localRotation;
        StartCoroutine(doubleok());
        BackFromSpice.SetActive(false);
        porespicebtn.SetActive(false);
    }

    void ChildCount()
    {
        Dictionary<string, List<Transform>> tagMap = new Dictionary<string, List<Transform>>();

        int childCount = childCounts.childCount;

        for (int i = 0; i < childCount; i++)
        {
            Transform child = childCounts.GetChild(i);
            string childTag = child.tag;

            // Check if the tag is part of the allowed set
            if (IsAllowedTag(childTag))
            {
                // If the tag is not in the dictionary, add it with an empty list
                if (!tagMap.ContainsKey(childTag))
                {
                    tagMap[childTag] = new List<Transform>();
                }

                // Add the child to the list associated with its tag
                tagMap[childTag].Add(child);
            }
        }

        // Iterate through the dictionary to print and display UI
        foreach (var entry in tagMap)
        {
            string childTag = entry.Key;
            List<Transform> sameTagChildren = entry.Value;

            // Determine the potatoPrice based on childTag
            float potatoPrice = GetPriceForTag(childTag);

            // Count of children with the same tag
            int sameTagCount = sameTagChildren.Count;

            // Calculate the total price
            float totalPrice = sameTagCount * potatoPrice;

            // Display the result only for allowed tags
            string displayString = childTag + "    " + sameTagCount + "    " + totalPrice;
            print(displayString);


            GameObject newObj = Instantiate(textPrefab, verticallayout);
            instantiatedPrefabs.Add(newObj);

            // Get the Text components from the new object
            Text nameTextComponent = newObj.transform.Find("NameText").GetComponent<Text>();
            Text priceTextComponent = newObj.transform.Find("PriceText").GetComponent<Text>();

            // Set the text of the Text components
            nameTextComponent.text = childTag;
            priceTextComponent.text = totalPrice.ToString();
        }

        Childcount = false;
    }

    bool IsAllowedTag(string tag)
    {
        // Define the set of allowed tags
        HashSet<string> allowedTags = new HashSet<string>
        {
        "onion", "potato", "lemon", "tomato", "meat", "salmonfillet","fish","potato1","Dril Dried","Cayenna Pepper","Thyme Dried","Horseria","BlackPepper","Salt."
        };

        // Check if the tag is in the allowed set
        return allowedTags.Contains(tag);
    }
    float GetPriceForTag(string tag)
    {
        // Assign prices based on the tag
        switch (tag)
        {
            case "Onion":
                return 120f;
            case "Potato":
                return 100f;
            case "Lemon":
                return 80f;
            case "tomato":
                return 50f;
            case "meat":
                return 150f;
            case "salmonfillet":
                return 210f;
            case "fish":
                return 200f;
            case "potato1":
                return 4f;
            case "BlackPepper":
            case "Horseria":
            case "Salt.":
            case "Thyme Dried":
            case "Cayenna Pepper":
            case "Dril Dried":
                return 1f;
            default:
                return 1f; // Default price for unknown tags
        }
    }


    public void porespice()
    {
        int a = 0;
        if (pickedObj.tag == "cayennepepper")
        {
            a = 6;
        }
        else if (pickedObj.tag == "horsera")
        {
            a = 4;
        }
        else if (pickedObj.tag == "salt")
        {
            a = 2;
        }
        else if (pickedObj.tag == "thymedried")
        {
            a = 5;
        }
        else if (pickedObj.tag == "blackpepper")
        {
            a = 3;
        }
        else if (pickedObj.tag == "drilldried")
        {
            a = 1;
        }

        SpicerackRayCast.instance.PoreSpice(a);
    }

    private Transform interactableObject;
    public void InteractBtnclick()
    {
        DuringCutting = false;
        dropbtn.SetActive(false);
        EnvCamera.transform.position = fpsContollar.transform.position + new Vector3(0, 0.1f, 0);
        EnvCamera.transform.rotation = fpsContollar.transform.rotation * Quaternion.Euler(15, 0, 0);
        TempPOsRot.rotation = pickedObj.localRotation;
        TempPOsRot.position = pickedObj.localPosition;
        pickedObj.parent = null;
        PickupPosition = _hitInfo.transform.position + new Vector3(0, 0.3f, 0f);
        if (pickedObj.tag == "BigPot")
        {
            PickupPosition = _hitInfo.transform.position + new Vector3(0, 0.6f, 0f);
        }
        yposition = PickupPosition;
        pickedRotation = Quaternion.Euler(0, 0, 0);
        EnvCamera.SetActive(true);
        FPSCotroller.SetActive(false);
        StartCoroutine(doubleok());
        InteractButton.SetActive(false);
        backInteractButton.SetActive(true);
        Leftrotation.SetActive(true);
        RightRotation.SetActive(true);
        UpRotation.SetActive(true);
        Downrotation.SetActive(true);
        interactableObject = _hitInfo.transform;
        maintainDistanceFlag = true;
        StartCoroutine(MaintainDistance());
        pickedObj.GetComponent<LineRenderer>().enabled = true;
        pickedObj.GetComponent<Interact>().enabled = true;
        pickedObj.GetComponent<MeshCollider>().enabled = false;
        PLacebtn.SetActive(false);
        PLaceBtnn.SetActive(false);
        PlayerPrefs.SetInt("Interact", 1);

    }

    public void BackInteractBtnclick()
    {
        DuringCutting = true;
        FPSCotroller.SetActive(true);
        EnvCamera.SetActive(false);
        pickedObj.parent = null;
        pickedObj.transform.parent = fpsContollar.transform;
        pickedObj.GetComponent<MeshCollider>().enabled = true;
        PickupPosition = TempPOsRot.localPosition;
        pickedRotation = TempPOsRot.localRotation;
        StartCoroutine(doubleok());
        backInteractButton.SetActive(false);
        Leftrotation.SetActive(false);
        RightRotation.SetActive(false);
        UpRotation.SetActive(false);
        Downrotation.SetActive(false);
        maintainDistanceFlag = false;
        pickedObj.GetComponent<LineRenderer>().enabled = false;
        pickedObj.GetComponent<Interact>().enabled = false;
        PlayerPrefs.SetInt("Interact", 0);
    }
    public static bool Chickenbroute = false;
    public Transform capTransform;  
    public float openPosition = 90f;  
    public float closedPosition = 0f;  
    public float dropDistance = 1f;
    bool open = false;
    public void ChickenBroutebtnClick()
    {
        StartCoroutine(RotateCap(openPosition));
        StartCoroutine(MoveCap(-dropDistance));
        Audio.clip = Auidos[3];
        Audio.Play();
        DuringCutting = false;
        open = true;
        dropbtn.SetActive(false);
        EnvCamera.transform.position = fpsContollar.transform.position + new Vector3(0, 0.4f, 0);
        EnvCamera.transform.rotation = fpsContollar.transform.rotation * Quaternion.Euler(15, 0, 0);
        TempPOsRot.rotation = pickedObj.localRotation;
        TempPOsRot.position = pickedObj.localPosition;
        pickedObj.parent = null;
        PickupPosition = _hitInfo.transform.position + new Vector3(0, 0.45f, 0f);
        pickedRotation = Quaternion.Euler(-90,270,0);
        yposition = PickupPosition;
        EnvCamera.SetActive(true);
        FPSCotroller.SetActive(false);
        StartCoroutine(doubleok());
        interactableObject = _hitInfo.transform;
        maintainDistanceFlag = true;
        StartCoroutine(MaintainDistance());
        interactchikenBtn.SetActive(false);
        BackinteractchikenBtn.SetActive(true);
        pickedObj.GetComponent<MeshCollider>().enabled = false;
        Chickenbroute = true;
        ChickenBroutebtn.SetActive(true);
        pickedObj.gameObject.GetComponent<LineRenderer>().enabled = false;
        pickedObj.transform.GetChild(3).gameObject.SetActive(true);
        pickedObj.GetChild(3).transform.GetChild(0).transform.GetChild(2).gameObject.GetComponent<Text>().text = pickedObj.gameObject.GetComponent<SpiceQuantity>().Quantity.ToString() + "g";
        PlayerPrefs.SetInt("Interact", 2);
       
    } 
    public void SunflowerbtnClick()
    {
        Audio.clip = Auidos[3];
        Audio.Play();
        DuringCutting = false;
        open = true;
        dropbtn.SetActive(false);
        EnvCamera.transform.position = fpsContollar.transform.position + new Vector3(0, 0.2f, 0);
        EnvCamera.transform.rotation = fpsContollar.transform.rotation;
        TempPOsRot.rotation = pickedObj.localRotation;
        TempPOsRot.position = pickedObj.localPosition;
        pickedObj.parent = null;
        pickedObj.gameObject.GetComponent<SunflowerOil>().enabled = true;
        PickupPosition = _hitInfo.transform.position + new Vector3(0, 0.45f, 0f);
        pickedRotation = Quaternion.Euler(90,0,-90);
        yposition = PickupPosition;
        EnvCamera.SetActive(true);
        FPSCotroller.SetActive(false);
        StartCoroutine(doubleok());
        interactableObject = _hitInfo.transform;
        SunFlowerOilBtn.SetActive(false);
        BackSunflowerBtnClk.SetActive(true);
        pickedObj.GetComponent<MeshCollider>().enabled = false;
        pickedObj.gameObject.GetComponent<LineRenderer>().enabled = false;
        pickedObj.transform.GetChild(0).gameObject.SetActive(false);
       
    }

    public void BackChickenBroutebtnClick()
    {
        if (capTransform.GetComponent<Rigidbody>() != null)
        {
            Rigidbody rb = capTransform.gameObject.GetComponent<Rigidbody>();
            Destroy(rb);
            capTransform.parent = pickedObj;
            open = false;
        }
        DuringCutting = true;
        Chickenbroute = false;
        pickedObj.gameObject.GetComponent<LineRenderer>().enabled = false;
        pickedObj.GetComponent<MeshCollider>().enabled = true;
        FPSCotroller.SetActive(true);
        EnvCamera.SetActive(false);
        pickedObj.transform.GetChild(3).gameObject.SetActive(false);
        pickedObj.transform.parent = fpsContollar.transform;
        PickupPosition = TempPOsRot.localPosition;
        pickedRotation = TempPOsRot.localRotation;
        StartCoroutine(doubleok());
        maintainDistanceFlag = false;
        ChickenBroutebtn.SetActive(false);
        BackinteractchikenBtn.SetActive(false);
        StartCoroutine(MoveCap(dropDistance));
        StartCoroutine(RotateCap(0));
        PlayerPrefs.SetInt("Interact", 0);
    }
    public void BackSunflowerOilbtnClick()
    {
   
        DuringCutting = true;
        Chickenbroute = false;
        pickedObj.GetComponent<MeshCollider>().enabled = true;
        pickedObj.gameObject.GetComponent<SunflowerOil>().enabled = false;
        FPSCotroller.SetActive(true);
        EnvCamera.SetActive(false);
        pickedObj.transform.GetChild(0).gameObject.SetActive(true);
        pickedObj.transform.parent = fpsContollar.transform;
        PickupPosition = TempPOsRot.localPosition;
        pickedRotation = TempPOsRot.localRotation;
        StartCoroutine(doubleok());
        maintainDistanceFlag = false;
        SunFlowerOilBtn.SetActive(false);
        BackSunflowerBtnClk.SetActive(false);

    }

    private IEnumerator RotateCap(float targetRotation)
    {
        while (Mathf.Abs(capTransform.localRotation.eulerAngles.x - targetRotation) > 0.1f)
        {
            // Rotate towards the target rotation
            capTransform.localRotation = Quaternion.Lerp(capTransform.localRotation, Quaternion.Euler(0, targetRotation, 0), Time.deltaTime * rotationSpeed);

            yield return null;
        }
        capTransform.localRotation = Quaternion.Euler(0, 0, 0);
    }
    private IEnumerator MoveCap(float distance)
    {
        Vector3 initialPosition = capTransform.position;
        Vector3 targetPosition;
        if (open)
        {
            targetPosition = new Vector3(0.5f, 1f, -1f);
        }
        else
        {

            targetPosition = new Vector3(-0.01101303f, 0.08851635f, -0.03104365f);
        }

        float elapsedTime = 0f;
        float duration = 1f;  // Adjust the duration of the drop or rise

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            // Move towards the target position
            capTransform.localPosition = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            yield return null;
        }
        if (open)
        {
            capTransform.gameObject.AddComponent<Rigidbody>();
        }
        else
        {
            capTransform.localPosition = new Vector3(-0.01101303f, 0.08851635f, -0.03104365f); 
        }

    }
    public float distance = 0;

    IEnumerator MoveForwardAndRotate()
    {
        distance = Vector3.Distance(EnvCamera.transform.position, interactableObject.transform.position);
        print("distance" + distance);
        if (distance > 1f)
        {
            while (distance > 1.5f)
            {
                EnvCamera.transform.Translate(Vector3.forward * 5 * Time.deltaTime);
                distance = Vector3.Distance(EnvCamera.transform.position, interactableObject.transform.position);
                yield return null;
            }
        }
        else if (distance < 1.5f)
        {
            while (distance < 2.4f)
            {
                EnvCamera.transform.Translate(-Vector3.forward * 5 * Time.deltaTime);
                distance = Vector3.Distance(EnvCamera.transform.position, interactableObject.transform.position);
                yield return null;
            }
        }
    }

    public void PLaceOredr()
    {
        if (_hitInfo.transform.tag == "Order")
        {
            pickedObj.parent = null;
            order = pickedObj;
            if (pickedObj != null)
            {
                pickedObj = null;
                picUpOjectsList.Clear();
            }
            order.transform.SetParent(orderpos);
            StartCoroutine(PlaceOrder2(order ,orderpos.transform.position - new Vector3(0, -0.05f, 0.1f))); 

        }
        else if (_hitInfo.transform.tag == "TakeOrder")
        {
            //order.transform.parent = orderpos;
            PLaceOrderAnim.SetBool("Anim", true);
            StartCoroutine(PlaceOrder2(order,TakeOrderpos.position));
           
        }
    }

    IEnumerator PlaceOrder2(Transform order, Vector3 hitTransform)
    {
        Quaternion a = Quaternion.Euler(0, 0, 0);
        Vector3 hitPosition = hitTransform;
        //print("posironsacnahc fmwocdhi b");
        while (Vector3.Distance(order.position, hitPosition) > 0.04f)
        {
            order.position = Vector3.Lerp(order.position, hitPosition, Time.deltaTime * 2f);
            order.transform.rotation = Quaternion.Slerp(a, targetRotation, 0.1f * Time.deltaTime);
            yield return null;
        }
        if (_hitInfo.transform.tag == "TakeOrder")
        {
            Audio.clip = Auidos[21];
            Audio.Play();
            PLaceOrderAnim.SetBool("Anim", false);
            order.parent = null;
            AnalyzeOrder();
        }
    }

    public void AnalyzeOrder()
    {
        int a = OrderManager.Instance.currentOrder;
        int b = 0;
        HashSet<string> uniqueTags = new HashSet<string>(); // To store unique tags encountered

        if (a == 2)
        {
            foreach (Transform child in order)
            {
                if (child.tag == "fish" || child.tag == "potato")
                {
                    if (uniqueTags.Add(child.tag)) 
                    {
                        b++; 
                    }
                }
            }
            if(b>=2)
            {
                OrderManager.Instance.OrderCompleteOnTime(1);
            }
            else{
                OrderManager.Instance.OrderCompleteOnTime(2);
            }
        }
        else if (a == 3)
        {
            foreach (Transform child in order)
            {
                if (child.tag == "potato1" || child.tag == "Salt." || child.tag == "BlackPepper" || child.tag == "Cayenna Pepper")
                {
                    if (uniqueTags.Add(child.tag))
                    {
                        b++; 
                    }
                }
            }
            if (b >= 4)
            {
                OrderManager.Instance.OrderCompleteOnTime(1);
            }
            else
            {
                OrderManager.Instance.OrderCompleteOnTime(2);
            }
        }
        else if (a == 1)
        {
            foreach (Transform child in order)
            {
                if (child.tag == "Salmonillet"   )
                {
                    if (child.gameObject.GetComponent<MeshRenderer>().material.name.Contains("friedsalmon"))
                    {
                        if (uniqueTags.Add(child.tag))
                        {
                            b++;
                        }
                    }
                }
                else if(child.tag == "Salt." || child.tag == "BlackPepper"|| child.tag == "lemon")
                {
                    if (uniqueTags.Add(child.tag))
                    {
                        b++;
                    }
                }
            }
            if (b >= 4)
            {
                OrderManager.Instance.OrderCompleteOnTime(1);
            }
            else
            {
                OrderManager.Instance.OrderCompleteOnTime(2);
            }
        }
        else if (a == 0)
        {
            if (order.GetChild(1) != null)
            {
               
            }
        }
            Destroy(order.gameObject);
        order = null;
    }
    public void BakingTheObject()
    {
        foreach (Transform child in BakedObject)
        {
            // Check if the child has a renderer component
            Renderer fishrenderer = child.GetComponent<Renderer>();
            if (fishrenderer != null)
            {
                // Change the material of the fish
                fishrenderer.material = FishMaterial;
            }
        }
    }

    public void potatoCutBtnClick()
    {
        if (pickedObj.tag == "potato")
        {
            print("Cut POtato");
            pickedObj.parent = null;
            picUpOjectsList.Clear();
            StartCoroutine(POtatoCuttingPos(pickedObj, PotatoCutPos.position + new Vector3(0, 0.05f, 0)));
        }
        else 
        {
            foreach (Transform child in pickedObj)
            {

                if(child.transform.tag=="potato")
                {
                    StartCoroutine(POtatoCuttingPos(child, PotatoCutPos.position+ new Vector3(0,0.05f,0)));
                }
               
            }
        }
    }

    IEnumerator POtatoCuttingPos(Transform cuttingObj, Vector3 hitTransform)
    {
        Vector3 hitPosition = hitTransform;
        float lerpTime = 0f;
        float lerpDuration = 2f;

        print("Toward Cutting position");

        while (lerpTime < 1f)
        {
            lerpTime += Time.deltaTime / lerpDuration;
            cuttingObj.position = Vector3.Lerp(cuttingObj.position, hitPosition, lerpTime);
            yield return null;
        }
        if (cuttingObj.GetComponent<Rigidbody>() == null)
        {
            pickedObj.gameObject.AddComponent<Rigidbody>();
        }
        cuttingObj.transform.position = hitPosition;
    }

     public float desiredDistance = 2.5f;
    private bool maintainDistanceFlag = false;
    private IEnumerator MaintainDistance()
    {
        while (maintainDistanceFlag)
        {
            // Calculate the distance between the camera and the frypan
            float distance = Vector3.Distance(Camera.main.transform.position, interactableObject.position);


            // Adjust camera position based on distance
            if (distance > desiredDistance)
            {
                // Move the camera closer
                EnvCamera.transform.position = Vector3.Lerp(EnvCamera.transform.position, interactableObject.position - EnvCamera.transform.forward * desiredDistance, Time.deltaTime * moveSpeed);
            }
            else
            {
                // Move the camera away
                EnvCamera.transform.position = Vector3.Lerp(EnvCamera.transform.position, interactableObject.position - EnvCamera.transform.forward * desiredDistance, Time.deltaTime * moveSpeed);
            }

            yield return null;
        }
    }
    public void utensilsbtnclick()
    {
        pickedObj.parent = null;
        dustbin = _hitInfo.transform;
        if (dustbin.name== "Utensils Holder 01")
        {
            pickedRotation = UtensilsHolder1.transform.rotation;
            PickupPosition= UtensilsHolder1.transform.position;
            StartCoroutine(doubleok());
        }
        else if(dustbin.name == "Utensils Holder 02")
        {
            pickedRotation = UtensilsHolder2.transform.rotation;
            PickupPosition = UtensilsHolder2.transform.position;
            StartCoroutine(doubleok());
        }
        else if (dustbin.name == "Utensils Holder 03")
        {
            pickedRotation = UtensilsHolder3.transform.rotation;
            PickupPosition = UtensilsHolder3.transform.position;
            StartCoroutine(doubleok());
        }
        else if (dustbin.name == "Utensils Holder 04")
        {
            pickedRotation = UtensilsHolder4.transform.rotation;
            PickupPosition = UtensilsHolder4.transform.position;
            StartCoroutine(doubleok());
        }
        picUpOjectsList.Clear();
    }
    public void KniefHolderBtnClick()
    {
        pickedObj.transform.parent = null;
        if(pickedObj.name== "knife2")
        {
            pickedObj.position = Knief22.position;
            pickedObj.rotation = Knief22.rotation;

        }
        else if(pickedObj.name == "knife3")
        {
            pickedObj.position = knief3.transform.position;
            pickedObj.rotation = knief3.transform.rotation;
        }
        pickedObj = null;
        picUpOjectsList.Clear();
    }
}