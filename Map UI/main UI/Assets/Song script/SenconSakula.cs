using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenconSakula : MonoBehaviour
{
    public string String;

    public void SaveClick()
    {
        PlayerPrefs.SetString("Song", String);
        print("불러오기:" + String);
    }
    public void ViewClick()
    {
        print("불러오기 성공:" + PlayerPrefs.GetString("Song"));
    }
}
