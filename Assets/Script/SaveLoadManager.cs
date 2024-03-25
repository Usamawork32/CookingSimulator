using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
// Class To store Data of Instantiating gameobjects
public class InstantiatedGameObjectData
{
    public string tag;
    public string MaterialName;
    public Vector3 position;
    public Quaternion rotation;
}

// Class To store Data of Heirarchy Gameobjects
[System.Serializable]
public class HeirarchyGameObjectData
{
    public string name;
    public int SelfActive;
    public Vector3 position;
    public Quaternion rotation;
}
// List To store Data of Instantiating gameobjects of Class(InstantiatedGameObjectData) type
[System.Serializable]
public class INstantiatedGameObjectListsClass
{
    public List<InstantiatedGameObjectData> InstantiatedeObjectDataList = new List<InstantiatedGameObjectData>();
}
// List To store Data of Heirarchy gameobjects of Class(HeirarchyGameObjectData) type
[System.Serializable]
public class HeirarchyGameObjectListsClass
{
    public List<HeirarchyGameObjectData> HeirarchyGameobjectData = new List<HeirarchyGameObjectData>();
}

public class SaveLoadManager : MonoBehaviour
{
    private const string INstantiatePlayerPrefsKey = "InstantiatedGameObjectsData";
    private const string HeirarchyPlayerPrefsKeyTag = "HeirarchyGameObjectsDataTag";
    public List<GameObject> HeirarchyGameobject;                                          // List all hierarchy GameObjects, and we want to save their positions and rotations.
    public List<GameObject> PrefabList;                                                   // List all prefabs that need to be instantiated during reload or continue time.
    public List<GameObject> ChipsList;                                                   // List all prefabs that need to be instantiated during reload or continue time.
    public List<Material> ObjectMaterials;
    public INstantiatedGameObjectListsClass INstantiatedGameobjectListClassObject;        // An object of the InstantiatedGameObjectData class.
    public HeirarchyGameObjectListsClass HeirarchyGameobjectListClassObject;              // An object of the  HeirarchyGameObjectData Class

    private bool instantiateBool = true;
    private void Start()
    {
        instantiateBool = true;
    }

    public void SaveGameObjectsData(List<GameObject> INstantiatedObjects, List<GameObject> HeirarchyGameobject)
    {

        // To store Data of Instantiating gameobjects
        INstantiatedGameobjectListClassObject.InstantiatedeObjectDataList = new List<InstantiatedGameObjectData>();
        foreach (GameObject obj in INstantiatedObjects)
        {
            InstantiatedGameObjectData data = new InstantiatedGameObjectData();
            data.tag = obj.tag;
            data.position = obj.transform.position;
            data.rotation = obj.transform.rotation;
            data.MaterialName = obj.GetComponent<Renderer>().material.name;
            INstantiatedGameobjectListClassObject.InstantiatedeObjectDataList.Add(data);
        }
        string INstantiatObjjson = JsonUtility.ToJson(INstantiatedGameobjectListClassObject, true);
        print("json file" + INstantiatObjjson);
        PlayerPrefs.SetString(INstantiatePlayerPrefsKey, INstantiatObjjson);
        PlayerPrefs.Save();


        // To store Data of Heirarchy Gameobjects by Using Name, Position And Rotation 
        HeirarchyGameobjectListClassObject.HeirarchyGameobjectData = new List<HeirarchyGameObjectData>();
        foreach (GameObject Heirarchyobj in HeirarchyGameobject)
        {
            HeirarchyGameObjectData Heirarchydata = new HeirarchyGameObjectData();
            Heirarchydata.name = Heirarchyobj.name;

            Heirarchydata.position = Heirarchyobj.transform.position;
            Heirarchydata.rotation = Heirarchyobj.transform.rotation;
            if (Heirarchyobj.activeSelf)
            {
                Heirarchydata.SelfActive = 2;
            }
            else
            {
                Heirarchydata.SelfActive = 1;
            }
            HeirarchyGameobjectListClassObject.HeirarchyGameobjectData.Add(Heirarchydata);
        }
        string HeirarchyJSonFile = JsonUtility.ToJson(HeirarchyGameobjectListClassObject, true);
        print("json file" + HeirarchyJSonFile);
        PlayerPrefs.SetString(HeirarchyPlayerPrefsKeyTag, HeirarchyJSonFile);
        PlayerPrefs.Save();
    }
    // Load the position and rotation of GameObjects
    public void LoadGameObjectsData(List<GameObject> PrefabList, List<GameObject> HeirachyObjList)
    {
        // Retrieve the serialized string containing instantiated object data from PlayerPrefs
        string InstantedObjInfo = PlayerPrefs.GetString(INstantiatePlayerPrefsKey);
        if (!string.IsNullOrEmpty(InstantedObjInfo))
        {

            // Initialize a list to store deserialized InstantiatedGameObjectData objects
            INstantiatedGameobjectListClassObject.InstantiatedeObjectDataList = new List<InstantiatedGameObjectData>();
            // Deserialize the JSON string into a list of InstantiatedGameObjectData objects
            //List<InstantiatedGameObjectData> _InstantiatedloadedData= JsonUtility.FromJson<List<InstantiatedGameObjectData>>(InstantedObjInfo);
            INstantiatedGameObjectListsClass _InstantiatedloadedData = JsonUtility.FromJson<INstantiatedGameObjectListsClass>(InstantedObjInfo);
            // Assuming _InstantiatedloadedData is a List<InstantiatedGameObjectData>
            foreach (InstantiatedGameObjectData data in _InstantiatedloadedData.InstantiatedeObjectDataList)
            {
                GameObject prefab = PrefabList.Find(p => p.tag == data.tag);

                // Check if a matching prefab is found
                if (prefab != null)
                {
                    // Instantiate a new GameObject based on the prefab, position, and rotation from the loaded data
                    if (prefab.tag != "potato1")
                    {
                        GameObject instantiatedObject = Instantiate(prefab, data.position, data.rotation);
                        PickNDrop.instance.InstantiateObject.Add(instantiatedObject);
                        foreach (Material ObjectMaterial in ObjectMaterials)
                        {
                            print(data.MaterialName + "    " + ObjectMaterial.name);
                            if (data.MaterialName == ObjectMaterial.name + " (Instance)" || data.MaterialName == ObjectMaterial.name)
                            {
                                instantiatedObject.GetComponent<Renderer>().material = ObjectMaterial;
                            }
                        }
                    }
                    else if (prefab.tag == "potato1")
                    {
                        int a = Random.Range(0, 7);
                        prefab = ChipsList[a];
                        GameObject instantiatedObject = Instantiate(prefab, data.position, data.rotation);
                        PickNDrop.instance.InstantiateObject.Add(instantiatedObject);
                        foreach (Material ObjectMaterial in ObjectMaterials)
                        {
                            print(data.MaterialName + "    " + ObjectMaterial.name);
                            if (data.MaterialName == ObjectMaterial.name + " (Instance)" || data.MaterialName == ObjectMaterial.name)
                            {
                                instantiatedObject.GetComponent<Renderer>().material = ObjectMaterial;
                            }
                        }

                    }
                    // Additional logic can be added here to handle the instantiated object as needed
                }
            }
        }

        // Load Data OF Heirarchy Gameobjects
        // Retrieve the serialized string containing Heirarchy object data from PlayerPrefs
        string HeirarchyObjInfo = PlayerPrefs.GetString(HeirarchyPlayerPrefsKeyTag);

        if (!string.IsNullOrEmpty(HeirarchyObjInfo))
        {
            // Initialize a list to store deserialized HeirarchyGameObjectData objects
            HeirarchyGameobjectListClassObject.HeirarchyGameobjectData = new List<HeirarchyGameObjectData>();

            HeirarchyGameObjectListsClass _HeirarchyObjloadedData = JsonUtility.FromJson<HeirarchyGameObjectListsClass>(HeirarchyObjInfo);  // Corrected from InstantedObjInfo to HeirarchyObjInfo

            foreach (HeirarchyGameObjectData Heirarchydata in _HeirarchyObjloadedData.HeirarchyGameobjectData)
            {
                // Find the corresponding prefab in the PrefabList based on the tag of the loaded data
                GameObject HeirarchyObject = HeirachyObjList.Find(p => p.name == Heirarchydata.name); // Use a unique identifier or tag for the prefab

                if (HeirarchyObject != null)
                {
                    if (Heirarchydata.SelfActive == 2)
                    {
                        HeirarchyObject.SetActive(true);
                    }
                    HeirarchyObject.transform.position = Heirarchydata.position;
                    HeirarchyObject.transform.rotation = Heirarchydata.rotation;
                }
            }
        }

        string pickedObjName = PlayerPrefs.GetString("pickedObjName");
        print(pickedObjName);
        string pickedObjTag = PlayerPrefs.GetString("pickedObjTag");
        GameObject currentObj = GameObject.Find(pickedObjName);
        if (currentObj != null)
        {
            print(currentObj.name);
            PickNDrop.instance.pickedObj = currentObj.transform;
            PickNDrop.instance.pickedObj.name = pickedObjName;
            PickNDrop.instance.tag = pickedObjTag;
            PickNDrop.Hitobject = false;
            PickNDrop.instance.pickUpBtnClicked();
            Invoke("Bool", 0.5f);

        }
    }


    public void SaveBtnClick()
    {
        SaveGameObjectsData(PickNDrop.instance.InstantiateObject, HeirarchyGameobject);
        PlayerPrefs.SetInt("Continue", 1);
        //  Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID || UNITY_IOS
    Application.Quit();
#endif
    }
    public void LoadBtnClick()
    {
        LoadGameObjectsData(PrefabList, HeirarchyGameobject);
    }
    private void Bool()
    {
        PickNDrop.Hitobject = true;
    }
}
