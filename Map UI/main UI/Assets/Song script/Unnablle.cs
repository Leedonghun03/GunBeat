using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unnablle : MonoBehaviour
{
    public string bring;

    public void SaveClick()
    {
        PlayerPrefs.SetString("Song", bring);
        print("불러오기:" + bring);
    }
    public void ViewClick()
    {
        print("불러오기 성공:" + PlayerPrefs.GetString("Song"));
    }
}
