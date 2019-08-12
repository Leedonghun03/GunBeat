using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBird : MonoBehaviour
{
    public string Starting;

    public void SaveClick()
    {
        PlayerPrefs.SetString("Song", Starting);
        print("불러오기:" + Starting);
    }
    public void ViewClick()
    {
        print("불러오기 성공:" + PlayerPrefs.GetString("Song"));
    }
}
