using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    //홈씬에서 저장한 로컬변수를 Game씬에서 시작시 불러오기
    [HideInInspector]
    public string GetGameModeString;
    [HideInInspector]
    public string GetLevelString;
    [HideInInspector]
    public string GetGunModeString;
    [HideInInspector]
    public string GetSongString;

    //생성하려는 오브젝트 
    public GameObject[] ContentPObject;


    //생성하려는 오브젝트의 부모오브젝트 (해당 부모오브젝트 밑의 자식으로 들어가야함)
    public GameObject ContentParanet;




    //전체 게임시간
    private float TotalGameTime;
    //큐브 생성시간 텀 
    public float CubeCraetTime;

    //큐브 시작 점(기준)
    public float CubeStartPositioZ;


    //게임포인트
    public float GamePointCountFloat;
    public Text GamePointCountText;


    // 테스트용 -> 나중에 수정 바람
    public AudioClip gameAudio;
    public AudioSource audioSource;

   // int cubecnt = 10;


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

        GamePointCountFloat = 0;

        GamePointCountText.text = GamePointCountFloat.ToString();

        //오디오 세팅
        audioSource.clip = gameAudio;
        TotalGameTime = gameAudio.length;

        audioSource.Play();


        // 큐브 생성
        StartCoroutine(GameCubeCreat2e());
    }


    public void HomeGoClick()
    {

        Application.LoadLevel("Home");
       
    }



    IEnumerator GameCubeCreat2e()
    {

        for(int i=0; i< TotalGameTime; i++)
        {
            float RamdomX = Random.Range(-5.0f,5.1f);


            int ranNum = Random.Range(0, 2);

            GameObject ContentP = Instantiate(ContentPObject[ranNum]);


            ContentP.transform.parent = ContentParanet.transform;
            ContentP.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            ContentP.transform.position = new Vector3(RamdomX, 2.8f, CubeStartPositioZ);

            ContentP.name = i.ToString();

            yield return new WaitForSeconds(CubeCraetTime);
           // if()
        }

        yield break;
    }
}
