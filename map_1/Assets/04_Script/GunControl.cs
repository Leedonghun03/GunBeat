using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class GunControl : MonoBehaviour
{
   
    public SteamVR_Input_Sources handType;  //모두 사용 왼손, 오른손
    public SteamVR_Action_Boolean teleprotAction;   //텔레포트 액션
    public SteamVR_Action_Boolean TriggerAction;   //트리거 액션
    public ParticleSystem MuzzleEffecrt; // 파티클
    public GameObject laser;
    private AudioSource audio;
    public AudioClip GunSound;

    float timer;
    float delaytime = 0.2f;
    float fireTime = 0f;
    float fireDelay = 0f;

    float range = 100.0f;
    float damage = 100.0f;

    //큐브들이 생성되는 부모 오보젝트
    public GameObject P_CubeZoom;

    // 왼손은 1번, 오른손은 2번
    public int gunNum;

    float currentTime = 0f;

    public bool isHit;
    private float shootDistance = 7f;

    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.GunSound;
        this.audio.loop = false;
        this.audio.volume = 0.8f;
        timer = 0.0f;    

    }

    void Update()
    {        
        RaycastHit hit;
        isHit = Physics.Raycast(laser.transform.position, laser.transform.forward, out hit, shootDistance);

        Debug.DrawRay(laser.transform.position, laser.transform.forward * shootDistance);
        timer += Time.deltaTime;
       
        if (GetTrigger())
        {
            if (timer > delaytime)
            {
                MuzzleEffecrt.Play();

                Shoot(hit);

                if (Time.time - currentTime > 0.06f)
                {
                    audio.PlayOneShot(audio.clip);
                    currentTime = Time.time;
                    timer = 0.0f;
                }
            }
        }
    }


    void Shoot(RaycastHit hitInfo)
    {
        if (!isHit)
            return;

        CubeControl cubeControl = hitInfo.transform.GetComponent<CubeControl>();

        if (cubeControl != null)
        {
            cubeControl.SuccessClick(gunNum);
            Debug.Log("큐브 맞춤");
        }
    }


    // 텔레포트가 활성화되면 true 반환
    public bool GetTeleportDown()
    {
        return teleprotAction.GetStateDown(handType);;
    }

    // 잡기 액션이 활성화되어 있으면 true 반환
    public bool GetTrigger()
    {
        return TriggerAction.GetState(handType);
    }
}
