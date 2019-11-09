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

    public float Combo;

    // 왼손은 1번, 오른손은 2번
    public int cubeNum;

    public int ComboNum;

    private UserInterFace manager;

    private GameControl control;

    Material mat;

    Material childMat;

    BoxCollider boxColl;

    void Start()
    {
        manager = GameObject.Find("Manage").GetComponent<UserInterFace>();
        control = GameObject.Find("Manage").GetComponent<GameControl>();

        boxColl = GetComponent<BoxCollider>();

        if (GetLevelString == "easy")
        {
            Cubespeed = 40;
        }
        if (GetLevelString == "nomal")
        {
            Cubespeed = 60;
        }
        if (GetLevelString == "hard")
        {
            Cubespeed = 85;
        }

        mat = GetComponent<MeshRenderer>().material;
        childMat = transform.GetChild(0).GetComponent<MeshRenderer>().material;
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

            //터치시 삭제
            StartCoroutine(CubeDissolve());
            boxColl.enabled = false;
        }
        if (ComboNum == gunNum)
        {
            control.GameComboCountFloat += Combo;
            control.GameComboCountText.text = control.GameComboCountFloat.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CubeDestroyZone"))
        {         
            manager.healthBar1();

            Destroy(this.gameObject);
        }        
    }



    IEnumerator CubeDissolve()
    {
        float currentTime = 0;

        while (currentTime < 0.5f)
        {
            currentTime += Time.deltaTime;
            mat.SetFloat("_DissolveAmount", Mathf.Sin(currentTime * 2f));
            childMat.SetFloat("_DissolveAmount", Mathf.Sin(currentTime * 2f));
            yield return null;
        }

        childMat.SetFloat("_DissolveAmount", 1);

        Destroy(gameObject);
    }
}
