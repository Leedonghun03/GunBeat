using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{
   
    //큐브속도
    private float Cubespeed = 15f;

    //큐브 없애면 획득포인트
    public float CubePoint;

    // 왼손은 1번, 오른손은 2번
    public int cubeNum;

    public GameObject sphere;


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

            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //RaycastHit hit = new RaycastHit();

            //if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //마우스 근처에 오브젝트가 있는지 확인
            //{
                //더치한 오브젝트 이름과 스크립트 포함한 오브젝트가 같으면 실행
              //  if(hit.collider.name==this.gameObject.name)
               // {

                 //   print(hit.collider.name);

                  //  GameObject.Find("Manage").GetComponent<GameControl>().GamePointCountFloat = GameObject.Find("Manage").GetComponent<GameControl>().GamePointCountFloat + CubePoint;
                  //  GameObject.Find("Manage").GetComponent<GameControl>().GamePointCountText.text = GameObject.Find("Manage").GetComponent<GameControl>().GamePointCountFloat.ToString();

                    //더치시 삭제
                   // Destroy(this.gameObject);

                //}
               

            //}

        }

    }

    //총이 성공적으로 큐브를 쏘았을때
    public void SuccessClick(int gunNum)
    {
        if (cubeNum == gunNum)
        {
            //점수반영
            GameObject.Find("Manage").GetComponent<GameControl>().GamePointCountFloat = GameObject.Find("Manage").GetComponent<GameControl>().GamePointCountFloat + CubePoint;
            GameObject.Find("Manage").GetComponent<GameControl>().GamePointCountText.text = GameObject.Find("Manage").GetComponent<GameControl>().GamePointCountFloat.ToString();


            //터지는 애니메이션 부분
            GameObject sphereObject = Instantiate(sphere, transform.position, Quaternion.identity);
            Destroy(sphereObject, 0.40f );

            //더치시 삭제
            Destroy(this.gameObject);
        }      
    }
}
