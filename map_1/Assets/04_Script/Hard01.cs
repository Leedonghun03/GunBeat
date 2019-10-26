using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard01 : MonoBehaviour
{
    public string Starting02;

    public void getSave()
    {
        PlayerPrefs.SetString("Level", Starting02);
        print("불러오기:" + Starting02);
    }
    public void getView()
    {
        print("불러오기 성공:" + PlayerPrefs.GetString("Level"));
    }
}
