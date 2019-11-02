using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class False : MonoBehaviour
{
    public GameObject GameOverText;

    void Start()
    {
        GameOverText.SetActive(false);
    }

    void Update()
    {

    }

    public void ShowGameOver()
    {
        GameOverText.SetActive(true);
    }
}
