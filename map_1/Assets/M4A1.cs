using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4A101 : MonoBehaviour
{
    public string Start;

    public void getSave()
    {
        PlayerPrefs.SetString("Gun Mode", Start);
        print("불러오기:" + Start);
    }
    public void getView()
    {
        print("불러오기 성공:" + PlayerPrefs.GetString("Gun Mode"));
    }
}
