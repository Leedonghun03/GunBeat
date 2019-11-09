using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    public GameObject sphere;

    public LayerMask mask;

    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        Debug.DrawRay(ray.origin, ray.direction * 100f);

        if (Physics.Raycast(ray, out hitInfo, 100f, mask.value))
        {
            Debug.Log("aaaaa");
            sphere.transform.position = hitInfo.point;
        }
    }
}
