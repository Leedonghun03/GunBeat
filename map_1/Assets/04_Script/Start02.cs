using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start02 : MonoBehaviour
{
    public string play;

    public void getSave()
    {
        PlayerPrefs.SetString("Start", play);
        print("불러오기:" + play);
    }
    public void getView()
    {
        print("불러오기 성공:" + PlayerPrefs.GetString("Start"));
    }

    public void HomeGoClick()
    {
  
        Application.LoadLevel("Home");
    }
}
