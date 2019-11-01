using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LeftController : MonoBehaviour
{
    [SerializeField]
    public bool ischecking = false;

    public int number;

    public SteamVR_Action_Boolean triggerAction;

    public HomeControl homeControl;

    public GameObject AlertPanelObject;

    void Update()
    {

        if (ischecking == true && triggerAction.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            NumberCheck();
        }
    }

    void NumberCheck()
    {
        if (number == 0)
        {
            homeControl.ClickSongButton("AlexNekitaCorporateSong");
            Debug.Log("Alex Nekita - Corporate Song이 눌렸다");
        }
        else if (number == 1)
        {
            homeControl.ClickSongButton("ArtegonBadBounce");
            Debug.Log("Artegon - Bad Bounce이 눌렸다");
        }
        else if (number == 2)
        {
            homeControl.ClickSongButton("MonaWonderlickChamber");
            Debug.Log("Mona Wonderlick - Chamber이 눌렸다");
        }
        else if (number == 3)
        {
            homeControl.ClickSongButton("NightLightsMarkTynerYouTube");
            Debug.Log("Night Lights - Mark Tyner - YouTube이 눌렸다");
        }
        else if (number == 4)
        {
            homeControl.ClickSongButton("PeyruisFeelinMe");
            Debug.Log("Peyruis - Feelin' Me이 눌렸다");
        }
        else if (number == 5)
        {
            homeControl.ClickLevelButton("Easy");
            Debug.Log("Easy이 눌렸다");
        }
        else if (number == 6)
        {
            homeControl.ClickLevelButton("nomal");
            Debug.Log("nomal이 눌렸다");
        }
        else if (number == 7)
        {
            homeControl.ClickLevelButton("hard");
            Debug.Log("hard이 눌렸다");
        }
        else if (number == 8)
        {
            homeControl.PlayGameStartClick();
            Debug.Log("start이 눌렸다");
        }
        else if (number == 9)
        {
            homeControl.ExitButton();
            Debug.Log("게임 설정 확인 버튼 닫기");
        }
    }
}
