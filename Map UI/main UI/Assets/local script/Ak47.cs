using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47 : MonoBehaviour
{
    public string Starting;

    public void SaveClick()
    {
        PlayerPrefs.SetString("Gun Mode", Starting);
        print("불러오기:" + Starting);
    }
    public void ViewClick()
    {
        print("불러오기 성공:" + PlayerPrefs.GetString("Gun Mode"));
    }
}
