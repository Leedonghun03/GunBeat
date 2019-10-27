using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeControl : MonoBehaviour
{
    public string PostSongString;
    public string PostLevelString;

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


    //Start버튼 누르면 불러오는 함수
    public void PlayGameStartClick()
    {
       if(PostSongString != "" && PostLevelString != "")
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
