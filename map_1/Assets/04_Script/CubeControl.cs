using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeControl : MonoBehaviour
{
    private float Cubespeed = 10f;

    [HideInInspector]
    public string GetLevelString;

    //큐브 없애면 획득포인트
    public float CubePoint;

    // 왼손은 1번, 오른손은 2번
    public int cubeNum;

    public GameObject sphere;

    private UserInterFace manager;

    private GameControl control;


    void Start()
    {
        manager = GameObject.Find("Manage").GetComponent<UserInterFace>();
        control = GameObject.Find("Manage").GetComponent<GameControl>();

        if (GetLevelString == "easy")
        {
            Cubespeed = 15;
        }
        if (GetLevelString == "nomal")
        {
            Cubespeed = 30;
        }
        if (GetLevelString == "hard")
        {
            Cubespeed = 50;
        }
    }


    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * Cubespeed);
    }


    //총이 성공적으로 큐브를 쏘았을때
    public void SuccessClick(int gunNum)
    {
        if (cubeNum == gunNum)
        {
            //점수반영
            control.GamePointCountFloat += CubePoint;
            control.GamePointCountText.text = control.GamePointCountFloat.ToString();


            //터지는 애니메이션 부분
            GameObject sphereObject = Instantiate(sphere, transform.position, Quaternion.identity);
            Destroy(sphereObject, 0.40f );

            //터치시 삭제
            Destroy(this.gameObject);
        }      
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CubeDestroyZone"))
        {
            Destroy(this.gameObject);

            manager.healthBar1();
        }
    }
}
