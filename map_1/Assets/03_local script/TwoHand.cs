using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHand : MonoBehaviour
{
    public string Start;

    public void SaveClick()
    {
        PlayerPrefs.SetString("GameMode", Start);
        print("불러오기:" + Start);
    }
    public void ViewClick()
    {
        print("불러오기 성공:" + PlayerPrefs.GetString("GameMode"));
    }
}
