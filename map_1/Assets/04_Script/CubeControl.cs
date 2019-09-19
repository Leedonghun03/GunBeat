﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{
    //큐브속도
    public float Cubespeed;

    //큐브 없애면 획득포인트
    public float CubePoint;

    void Start()
    {
        
    }

  
    void Update()
    {
   
        if(this.transform.position.z <= 2)
        {
            //z좌표가 2일때 삭제
            Destroy(this.gameObject);
        }
        else
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * Cubespeed);

        }


        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit = new RaycastHit();

            if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //마우스 근처에 오브젝트가 있는지 확인
            {
                //더치한 오브젝트 이름과 스크립트 포함한 오브젝트가 같으면 실행
                if(hit.collider.name==this.gameObject.name)
                {

                    print(hit.collider.name);

                    GameObject.Find("Manage").GetComponent<GameControl>().GamePointCountFloat = GameObject.Find("Manage").GetComponent<GameControl>().GamePointCountFloat + CubePoint;
                    GameObject.Find("Manage").GetComponent<GameControl>().GamePointCountText.text = GameObject.Find("Manage").GetComponent<GameControl>().GamePointCountFloat.ToString();

                    //더치시 삭제
                    Destroy(this.gameObject);

                }
               

            }

        }



    }
}
