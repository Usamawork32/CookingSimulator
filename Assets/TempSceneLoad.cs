using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempSceneLoad : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene(1);
    }
    public void SceneLoad()
    {
        SceneManager.LoadScene(1);
    }
}
