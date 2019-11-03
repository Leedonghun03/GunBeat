using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeShader : MonoBehaviour
{
    Material mat;
    Material childMat;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        childMat = transform.GetChild(0).GetComponent<MeshRenderer>().material;

        Debug.Log(childMat.name);
        // mat.SetFloat("_DissolveAmount", )
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(CubeDissolve());
        }

        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(CubeDissolveUp());
        }
    }

    IEnumerator CubeDissolve()
    {
        float currentTime = 0;

        while (currentTime < 1)
        {
            currentTime += Time.deltaTime;
            mat.SetFloat("_DissolveAmount", Mathf.Sin(currentTime));
            childMat.SetFloat("_DissolveAmount", Mathf.Sin(currentTime));
            yield return null;
        }

        childMat.SetFloat("_DissolveAmount", 1);
    }

    IEnumerator CubeDissolveUp()
    {
        float currentTime = 0;
        float cosNum = 1;

        while (cosNum > 0.01f)
        {
            currentTime += Time.deltaTime;

            cosNum = Mathf.Cos(currentTime);

            mat.SetFloat("_DissolveAmount", cosNum);
            childMat.SetFloat("_DissolveAmount", cosNum);
            yield return null;
        }

        childMat.SetFloat("_DissolveAmount", 0);
    }
}
