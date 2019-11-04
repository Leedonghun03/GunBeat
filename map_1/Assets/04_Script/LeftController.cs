using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class LeftController : MonoBehaviour
{
    int I;
    int C;
    public GameObject[] Button = new GameObject[7];

    public Image Image;
    
    public Sprite[] sp = new Sprite[5];

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

    private void Change()
    {     
            Button[5].GetComponent<Image>().color = new Color(255, 255, 255);
            Button[6].GetComponent<Image>().color = new Color(255, 255, 255);
            Button[7].GetComponent<Image>().color = new Color(255, 255, 255);
       
    }
    private void NewMethod()
    {            
            Button[0].GetComponent<Image>().color = new Color(255, 255, 255);
            Button[1].GetComponent<Image>().color = new Color(255, 255, 255);
            Button[2].GetComponent<Image>().color = new Color(255, 255, 255);
            Button[3].GetComponent<Image>().color = new Color(255, 255, 255);
            Button[4].GetComponent<Image>().color = new Color(255, 255, 255);
    }

    void Update()
    {
        ShootRay();

        if (ischecking == true && triggerAction.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
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

        lr.SetPosition(0, transform.position);

        if (Physics.Raycast(ray, out hitInfo, 100f))
        {
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.yellow);

            if (hitInfo.transform.CompareTag("MenuButton"))
            {
                ischecking = true;
                lr.SetPosition(1, hitInfo.point);
            }
            else
            {
                lr.SetPosition(1, transform.position + transform.forward * 0.5f);
            }
        }
        else
        {
            ischecking = false;
            lr.SetPosition(1, transform.position + transform.forward * 0.5f);
        }
    }


    public void NumberCheck()
    {
        if (number == 0)
        {
            homeControl.ClickSongButton("CorporateSong");
            songTitle.text = "Corporate Song";
            Debug.Log("Alex Nekita - Corporate Song이 눌렸다");
            NewMethod();
            GameObject.Find("Corporate Song").GetComponent<Image>().color = new Color(255, 0, 0);
            Image.sprite = sp[0];
        }
        else if (number == 1)
        {
            homeControl.ClickSongButton("Bad Bounce");
            songTitle.text = "Bad Bounce";
            Debug.Log("Artegon - Bad Bounce이 눌렸다");
            NewMethod();
            GameObject.Find("Bad Bounce").GetComponent<Image>().color = new Color(255, 0, 0);
            Image.sprite = sp[1];
        }
        else if (number == 2)
        {
            homeControl.ClickSongButton("Chamber");
            songTitle.text = "Chamber";
            Debug.Log("Mona Wonderlick - Chamber이 눌렸다");
            NewMethod();
            GameObject.Find("Chamber").GetComponent<Image>().color = new Color(255, 0, 0);
            Image.sprite = sp[2];
        }
        else if (number == 3)
        {
            homeControl.ClickSongButton("Night Lights");
            songTitle.text = "Night Light";
            Debug.Log("Night Lights - Mark Tyner - YouTube이 눌렸다");
            NewMethod();
            GameObject.Find("Night Lights").GetComponent<Image>().color = new Color(255, 0, 0);
            Image.sprite = sp[3];
        }
        else if (number == 4)
        {
            homeControl.ClickSongButton("Peyruis");
            songTitle.text = "Peyruis";
            Debug.Log("Peyruis - Feelin' Me이 눌렸다");
            NewMethod();
            GameObject.Find("Peyruis").GetComponent<Image>().color = new Color(255, 0, 0);
            Image.sprite = sp[4];
        }
        else if (number == 5)
        {
            homeControl.ClickLevelButton("easy");
            Debug.Log("easy이 눌렸다");
            Change();
            GameObject.Find("easy").GetComponent<Image>().color = new Color(255, 0, 0);
        }
        else if (number == 6)
        {
            homeControl.ClickLevelButton("nomal");
            Debug.Log("nomal이 눌렸다");
            Change();
            GameObject.Find("nomal").GetComponent<Image>().color = new Color(255, 0, 0);
        }
        else if (number == 7)
        {
            homeControl.ClickLevelButton("hard");
            Debug.Log("hard이 눌렸다");
            Change();
            GameObject.Find("hard").GetComponent<Image>().color = new Color(255, 0, 0);
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
