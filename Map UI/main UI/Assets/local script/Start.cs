using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    public string play;

    public void SaveClick()
    {
        PlayerPrefs.SetString("Gun Mode", play);
        print("불러오기:" + play);
    }
    public void ViewClick()
    {
        print("불러오기 성공:" + PlayerPrefs.GetString("Gun Mode"));
    }
}
