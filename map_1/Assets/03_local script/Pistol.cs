using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public string StartingValue;

    public void SaveClick()
    {
        PlayerPrefs.SetString("GunMode", StartingValue);
        print("불러오기:" + StartingValue);
    }
    public void ViewClick()
    {
        print("불러오기 성공:" + PlayerPrefs.GetString("GunMode"));
    }
}
