using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieInAFire : MonoBehaviour
{
    public string StringValue01;

    public void getSave()
    {
        PlayerPrefs.SetString("Song", StringValue01);
        print("불러오기:" + StringValue01);
    }
    public void getView()
    {
        print("불러오기 성공:" + PlayerPrefs.GetString("Song"));
    }
}
