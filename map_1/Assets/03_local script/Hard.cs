using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard : MonoBehaviour
{
    public string Starting;

    public void SaveClick()
    {
        PlayerPrefs.SetString("Level", Starting);
        print("불러오기:" + Starting);
    }
    public void ViewClick()
    {
        print("불러오기 성공:" + PlayerPrefs.GetString("Level"));
    }
}
