using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy : MonoBehaviour
{
    public string StringValue;

    public void SaveClick()
    {
        PlayerPrefs.SetString("Level", StringValue);
        print("불러오기:" + StringValue);
    }
    public void ViewClick()
    {
        print("불러오기 성공:" + PlayerPrefs.GetString("Level"));
    }
}
