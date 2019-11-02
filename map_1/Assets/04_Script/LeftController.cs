using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class LeftController : MonoBehaviour
{
    public SteamVR_Action_Boolean triggerAction;
    public HomeControl homeControl;
    public Text songTitle;

    [SerializeField]
    public bool ischecking = false;
    public int number;

    private RaycastHit hitInfo;
    private LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }


    void Update()
    {
        ShootRay();

        if (ischecking == true && triggerAction.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Debug.Log("aaaa");

            menubring menu = hitInfo.transform.GetComponent<menubring>();

            if (menu != null)
            {
                number = menu.uiNumber;
                NumberCheck();
            }
        }
    }


    void ShootRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hitInfo, 100f))
        {
            if (hitInfo.transform.CompareTag("MenuButton"))
            {
                Debug.Log("cccc");
                ischecking = true;                
            }
        }
        else
        {
            ischecking = false;
        }

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.forward * 100);
    }


    void NumberCheck()
    {
        if (number == 0)
        {
            homeControl.ClickSongButton("AlexNekitaCorporateSong");
            songTitle.text = "Corporate Song";
            Debug.Log("Alex Nekita - Corporate Song이 눌렸다");
        }
        else if (number == 1)
        {
            homeControl.ClickSongButton("ArtegonBadBounce");
            songTitle.text = "Bad Bounce";
            Debug.Log("Artegon - Bad Bounce이 눌렸다");
        }
        else if (number == 2)
        {
            homeControl.ClickSongButton("MonaWonderlickChamber");
            songTitle.text = "Chamber";
            Debug.Log("Mona Wonderlick - Chamber이 눌렸다");
        }
        else if (number == 3)
        {
            homeControl.ClickSongButton("NightLightsMarkTynerYouTube");
            songTitle.text = "Night Light";
            Debug.Log("Night Lights - Mark Tyner - YouTube이 눌렸다");
        }
        else if (number == 4)
        {
            homeControl.ClickSongButton("PeyruisFeelinMe");
            songTitle.text = "Peyruis";
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
