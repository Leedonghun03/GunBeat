using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHand01 : MonoBehaviour
{
    public string play;

    public void getSave()
    {
        PlayerPrefs.SetString("Game Mode", play);
        print("불러오기:" + play);
    }
    public void getView()
    {
        print("불러오기 성공:" + PlayerPrefs.GetString("Game Mode"));
    }
}
