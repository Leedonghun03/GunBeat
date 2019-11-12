using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogSceneChange : MonoBehaviour
{

    void Start()
    {
        Invoke("SceneChange", 3);
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("Home");
    }
}
