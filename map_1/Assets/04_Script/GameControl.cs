using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;


public class GameControl : MonoBehaviour
{
    //홈씬에서 저장한 로컬변수를 Game씬에서 시작시 불러오기
    [HideInInspector] public string GetGameModeString;
    [HideInInspector] public string GetLevelString;
    [HideInInspector] public string GetGunModeString;
    [HideInInspector] public string GetSongString;

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

    private AudioSource audioSource = null;
    private float volumeDownSpeed = 0.8f;

    private float currentTime = 0;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // PlayerPrefs 값 획득
        GetPlayerPrefs();
        // 게임 초기 세팅
        InitializeSetting();
        //오디오 세팅
        SetAudioClip();

        // 큐브 생성
        StartCoroutine(GameCubeCreate());
    }

    void Update()
    {
        GamePointCountText.text = GamePointCountFloat.ToString();
        GameComboCountText.text = GameComboCountFloat.ToString();

        currentTime += Time.deltaTime;
    }

    void InitializeSetting()
    {
        GamePointCountFloat = 0;
        GameComboCountFloat = 0;
        GamePointCountText.text = GamePointCountFloat.ToString();
        GameComboCountText.text = GameComboCountFloat.ToString();

        if (GetLevelString == "easy")
        {
            CubeCraetTime = 1f;
        }
        else if (GetLevelString == "nomal")
        {
            CubeCraetTime = 0.5f;
        }
        else if (GetLevelString == "hard")
        {
            CubeCraetTime = 0.25f;
        }
    }


    private void GetPlayerPrefs()
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



    void SetAudioClip()
    {
        if (GetSongString == "CorporateSong")
        {
            audioSource.clip = AlexNekitaCorporateSong;
        }
        else if (GetSongString == "Bad Bounce")
        {
            audioSource.clip = ArtegonBadBounce;
        }
        else if (GetSongString == "Chamber")
        {
            audioSource.clip = MonaWonderlickChamber;
        }
        else if (GetSongString == "Night Lights")
        {
            audioSource.clip = NightLightsMarkTynerYouTube;
        }
        else if (GetSongString == "Peyruis")
        {
            audioSource.clip = PeyruisFeelinMe;            
        }

        audioSource.Play();
        TotalGameTime = audioSource.clip.length;
        Debug.Log(TotalGameTime);
    }

       

    // GAMEUI에 버튼추가필요
    public void HomeGoClick()
    {
        SceneManager.LoadScene("Home");
    }


    IEnumerator GameCubeCreate()
    {
        int i = 1;

        //                      90
        while(currentTime < TotalGameTime)
        {                 
            // 큐브 생성
            int ranNum = Random.Range(0, 2);

            GameObject ContentP = Instantiate(ContentPObject[ranNum]);

            ContentP.transform.parent = ContentParanet.transform;
            ContentP.transform.rotation = ContentParanet.transform.rotation;
            ContentP.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

            float RamdomZ = Random.Range(-2.0f, 2.0f);
            Vector3 randomPos = ContentParanet.transform.position;

            randomPos.z += RamdomZ;

            ContentP.transform.position = randomPos;

            ContentP.name = i.ToString();
            i++;

            yield return new WaitForSeconds(CubeCraetTime);
        }

        yield return new WaitForSeconds(5.0f);

        GameOver();
    }

    public void GameOver()
    {
        StartCoroutine(Co_GameOver());
    }

    private IEnumerator Co_GameOver()
    {
        StartCoroutine(Co_VolumeDown());
        SteamVR_Fade.Start(Color.black, 5.0f, true);
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Home");
    }

    private IEnumerator Co_VolumeDown()
    {
        while (audioSource.volume > 0.01f)
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, 0, volumeDownSpeed * Time.deltaTime);
            yield return null;
        }        
    }
}
