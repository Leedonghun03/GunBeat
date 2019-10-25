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
            homeControl.ClickGunModeButton("Ak47");
            Debug.Log("AK47이 눌렸다");
        }
        else if (number == 1)
        {
            homeControl.ClickGunModeButton("M4A1");
            Debug.Log("M4A1이 눌렸다");
        }
        else if (number == 2)
        {
            homeControl.ClickGunModeButton("Pistol");
            Debug.Log("Pistol이 눌렸다");
        }
        else if (number == 3)
        {
            homeControl.ClickSongButton("Die In A Fire");
            Debug.Log("Die in A fire이 눌렸다");
        }
        else if (number == 4)
        {
            homeControl.ClickSongButton("snebon sakula");
            Debug.Log("snebon sakula이 눌렸다");
        }
        else if (number == 5)
        {
            homeControl.ClickSongButton("Happy");
            Debug.Log("Happy이 눌렸다");
        }
        else if (number == 6)
        {
            homeControl.ClickSongButton("Fire bird");
            Debug.Log("Fire bird이 눌렸다");
        }
        else if (number == 7)
        {
            homeControl.ClickSongButton("unrablle");
            Debug.Log("unrablle이 눌렸다");
        }
        else if (number == 8)
        {
            homeControl.ClickLevelButton("Easy");
            Debug.Log("Easy이 눌렸다");
        }
        else if (number == 9)
        {
            homeControl.ClickLevelButton("nomal");
            Debug.Log("nomal이 눌렸다");
        }
        else if (number == 10)
        {
            homeControl.ClickLevelButton("hard");
            Debug.Log("hard이 눌렸다");
        }
        else if (number == 11)
        {
            homeControl.ClickGameModeButton("one Hand");
            Debug.Log("one Hand이 눌렸다");
        }
        else if (number == 12)
        {
            homeControl.ClickGameModeButton("two hand");
            Debug.Log("Two hand이 눌렸다");
        }
        else if (number == 13)
        {
            homeControl.PlayGameStartClick();
            Debug.Log("start이 눌렸다");
        }
        else if (number == 14)
        {
            homeControl.ExitButton();
            Debug.Log("게임 설정 확인 버튼 닫기");
        }
    }
}
