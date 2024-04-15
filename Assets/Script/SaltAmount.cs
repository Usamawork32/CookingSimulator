using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaltAmount : MonoBehaviour
{
    public GameObject SaltAmountWin;
    public string Name;
    public string Amount;
    public Sprite ItemSprite;
    public static SaltAmount Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        SaltAmountWin.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Text>().text = Name;
        SaltAmountWin.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Image>().sprite = ItemSprite;
        //SaltAmountWin.transform.GetChild(0).transform.GetChild(2).gameObject.GetComponent<Text>().text = Amount;
        SaltAmountWin.SetActive(true);
    }

    private void OnDisable()
    {
        SaltAmountWin.SetActive(false);
    }
}
