using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    public string play;

    public void SaveClick()
    {
        PlayerPrefs.SetString("Start", play);
        print("불러오기:" + play);

        //게임씬으로 이동
        Application.LoadLevel("GameUI");
    }
    public void ViewClick()
    {
        print("불러오기 성공:" + PlayerPrefs.GetString("Start"));

    }
}
