using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    //홈씬에서 저장한 로컬변수를 Game씬에서 시작시 불러오기
    public string GetGameModeString;
    public string GetLevelString;
    public string GetGunModeString;
    public string GetSongString;

    void Start()
    {
       
        //Key값 : Game Mode
        GetGameModeString = PlayerPrefs.GetString("GameMode");
        //Key값 : Level
        GetLevelString = PlayerPrefs.GetString("Level");
        //Key값 : GunMode
        GetGunModeString = PlayerPrefs.GetString("GunMode");
        //Key값 : Song
        GetSongString = PlayerPrefs.GetString("Song");


    }

    public void HomeGoClick()
    {

        Application.LoadLevel("Home");
    }





}
