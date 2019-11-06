using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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

    // 오디오 클립들
    public AudioClip AlexNekitaCorporateSong;
    public AudioClip ArtegonBadBounce;
    public AudioClip MonaWonderlickChamber;
    public AudioClip NightLightsMarkTynerYouTube;
    public AudioClip PeyruisFeelinMe;


    //게임포인트
    public float GamePointCountFloat;
    public Text GamePointCountText;
    public float GameComboCountFloat;
    public Text GameComboCountText;

    // 테스트용 -> 나중에 수정 바람

    private AudioSource audioSource;

    //int cubecnt = 10;

    void Start()
    {


        audioSource = GetComponent<AudioSource>();

        //Key값 : Game Mode
        GetGameModeString = PlayerPrefs.GetString("GameMode");
        //Key값 : Level
        GetLevelString = PlayerPrefs.GetString("Level");
        //Key값 : GunMode
        GetGunModeString = PlayerPrefs.GetString("GunMode");
        //Key값 : Song
        GetSongString = PlayerPrefs.GetString("Song");

        GamePointCountFloat = 0;

        GameComboCountFloat = 0;      

        GamePointCountText.text = GamePointCountFloat.ToString();

        GameComboCountText.text = GameComboCountFloat.ToString();

        //오디오 세팅
        SelectAudioClip();

        Debug.Log(GetLevelString);
     
        
        if(GetLevelString == "easy")
        {
            Debug.Log("속도가 1.5로 설정되었다");
            CubeCraetTime = 1.5f;
        }
        if(GetLevelString == "nomal")
        {
            CubeCraetTime = 1f;
        }
        if(GetLevelString == "hard")
        {
            CubeCraetTime = 0.3f;
            Debug.Log("0.5초로 변경되었다");
        }
      // 큐브 생성
        StartCoroutine(GameCubeCreat2e());
    }

    void SelectAudioClip()
    {
        if (GetSongString == "CorporateSong")
        {
            audioSource.clip = AlexNekitaCorporateSong;
            audioSource.Play();
        }
        else if (GetSongString == "Bad Bounce")
        {
            audioSource.clip = ArtegonBadBounce;
            audioSource.Play();
        }
        else if (GetSongString == "Chamber")
        {
            audioSource.clip = MonaWonderlickChamber;
            audioSource.Play();
        }
        else if (GetSongString == "Night Lights")
        {
            audioSource.clip = NightLightsMarkTynerYouTube;
            audioSource.Play();
        }
        else if (GetSongString == "Peyruis")
        {
            audioSource.clip = PeyruisFeelinMe;
            audioSource.Play();
        }


        TotalGameTime = audioSource.clip.length;
    }





    // GAMEUI에 버튼추가필요
    public void HomeGoClick()
    {

        Application.LoadLevel("Home");

    }



    IEnumerator GameCubeCreat2e()
    {
        for (int i = 0; i < TotalGameTime; i++)
        {
            float RamdomZ = Random.Range(-2.0f, 2.0f);

            int ranNum = Random.Range(0, 2);

            GameObject ContentP = Instantiate(ContentPObject[ranNum]);

            ContentP.transform.parent = ContentParanet.transform;
            ContentP.transform.rotation = ContentParanet.transform.rotation;
            ContentP.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);


            Vector3 randomPos = ContentParanet.transform.position;

            randomPos.z += RamdomZ;

            ContentP.transform.position = randomPos;


            ContentP.name = i.ToString();

            yield return new WaitForSeconds(CubeCraetTime);
        }

        yield return new WaitForSeconds(4.0f);
        ChangeGameScene();

    }

    // 노래가 끝나면 홈씬으로 넘어간다.
    public void ChangeGameScene()
    {
        SceneManager.LoadScene("Home");
    }
}
