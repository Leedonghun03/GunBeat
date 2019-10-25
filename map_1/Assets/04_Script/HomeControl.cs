using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeControl : MonoBehaviour
{
    public string PostSongString;
    public string PostLevelString;
    public string PostGameModeString;
    public string PostGunModeString;

    public GameObject AlertPanelObject;
    public Text ErrorTitleText;

    void Start()
    {
        
    }

    //Song 선택
    public void ClickSongButton(string SongString)
    {
        PostSongString = SongString;
        PlayerPrefs.SetString("Song", SongString);
    }

    //Level 선택
    public void ClickLevelButton(string LevelString)
    {
        PostLevelString = LevelString;
        PlayerPrefs.SetString("Level", LevelString);
    }

    //GameMode 선택
    public void ClickGameModeButton(string GameModeString)
    {
        PostGameModeString = GameModeString;
        PlayerPrefs.SetString("GameMode", GameModeString);
    }

    //GunMode 선택
    public void ClickGunModeButton(string GunModeString)
    {
        PostGunModeString = GunModeString;
        PlayerPrefs.SetString("GunMode", GunModeString);
    }



    //Start버튼 누르면 불러오는 함수
    public void PlayGameStartClick()
    {
       if(PostSongString != "" && PostLevelString != "" && PostGameModeString != "" && PostGunModeString != "")
        {
            Debug.Log("게임 시작");
            Application.LoadLevel("GameUI");
        }
        else
        {
            AlertPanelObject.SetActive(true);
            ErrorTitleText.text = "설정 확인해주세요.";
        }



    }

    public void ExitButton()
    {
        AlertPanelObject.SetActive(false);

    }
}
