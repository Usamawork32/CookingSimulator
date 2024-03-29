using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiceSaving : MonoBehaviour
{
    public GameObject salt, drilldried, thyme,horseria, cayenne, blackpepper, chickenbrouth;
    public void OnSavingBtnclick()
    {
        PlayerPrefs.SetInt("Spice1", salt.gameObject.GetComponent<SpiceQuantity>().Quantity);
        PlayerPrefs.SetInt("Spice2", drilldried.gameObject.GetComponent<SpiceQuantity>().Quantity);
        PlayerPrefs.SetInt("Spice3", thyme.gameObject.GetComponent<SpiceQuantity>().Quantity);
        PlayerPrefs.SetInt("Spice4", horseria.gameObject.GetComponent<SpiceQuantity>().Quantity);
        PlayerPrefs.SetInt("Spice5", cayenne.gameObject.GetComponent<SpiceQuantity>().Quantity);
        PlayerPrefs.SetInt("Spice6", blackpepper.gameObject.GetComponent<SpiceQuantity>().Quantity);
        PlayerPrefs.SetInt("Spice7", chickenbrouth.gameObject.GetComponent<SpiceQuantity>().Quantity);
    }
    public void OnLoadBtnclick()
    {
        salt.gameObject.GetComponent<SpiceQuantity>().Quantity = PlayerPrefs.GetInt("Spice1");
        drilldried.gameObject.GetComponent<SpiceQuantity>().Quantity = PlayerPrefs.GetInt("Spice2" );
        thyme.gameObject.GetComponent<SpiceQuantity>().Quantity = PlayerPrefs.GetInt("Spice3");
        horseria.gameObject.GetComponent<SpiceQuantity>().Quantity = PlayerPrefs.GetInt("Spice4" );
        cayenne.gameObject.GetComponent<SpiceQuantity>().Quantity = PlayerPrefs.GetInt("Spice5");
        blackpepper.gameObject.GetComponent<SpiceQuantity>().Quantity = PlayerPrefs.GetInt("Spice6");
        chickenbrouth.gameObject.GetComponent<SpiceQuantity>().Quantity = PlayerPrefs.GetInt("Spice7");
    }
}
