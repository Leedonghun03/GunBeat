using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class GunControl : MonoBehaviour
{

    public SteamVR_Input_Sources handType;  //모두 사용 왼손, 오른손
    public SteamVR_Action_Boolean teleprotAction;   //텔레포트 액션
    public SteamVR_Action_Boolean TriggerAction;   //트리거 액션

    public ParticleSystem MuzzleEffecrt;
    public GameObject fpsCam;

    float range = 100.0f;
    float damage = 100.0f;

    //큐브들이 생성되는 부모 오보젝트
    public GameObject P_CubeZoom;

    // 왼손은 1번, 오른손은 2번
    public int gunNum;


    void OnCreate() { }
    void OnUpdate() { }

    void OnDrawGizmos()
    {

        float maxDistance = 100;
        RaycastHit hit;
        // Physics.Raycast (레이저를 발사할 위치, 발사 방향, 충돌 결과, 최대 거리)
        bool isHit = Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, maxDistance);

        Gizmos.color = Color.red;
        if (isHit)
        {
            Gizmos.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * hit.distance);
            //요기요기!!

            if (GetTrigger())
            {
                Debug.Log("Grab" + handType);
                Debug.Log(hit.transform.name);

               if (P_CubeZoom.transform.Find(hit.transform.name)==true)
                {
                    P_CubeZoom.transform.Find(hit.transform.name).GetComponent<CubeControl>().SuccessClick(gunNum);
                }


            }
        }
        else
        {
            Gizmos.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * maxDistance);
         
        }
    }
   



    void Start()
    {
        
    }

    
    void Update()
    {
        if (GetTeleportDown())
        {
            Debug.Log("Teleport" + handType);
        }

        if(GetTrigger())
        {
            Debug.Log("Grab" + handType);
            MuzzleEffecrt.Play();
        }


    }

    // 텔레포트가 활성화되면 true 반환
    public bool GetTeleportDown()
    {
        return teleprotAction.GetStateDown(handType);
    }

    // 잡기 액션이 활성화되어 있으면 true 반환
    public bool GetTrigger()
    {
        return TriggerAction.GetState(handType);
    }

}
