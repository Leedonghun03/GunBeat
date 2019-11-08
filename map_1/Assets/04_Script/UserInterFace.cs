using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UserInterFace : MonoBehaviour
{
    public Text GameComboCountText; 
    public float Combo;
    public GameObject textObject;
    public Slider healthBar;
    private float currentTime = 0f;
    private float MaxTime = 5.0f;

    private GameControl control;

    private bool isTimeCheck = false;


    

    public void Start()
    {
        control = GameObject.Find("Manage").GetComponent<GameControl>();
        healthBar.maxValue = 100;
        healthBar.value = 100;
        control.GameComboCountFloat = 0;
    }

    public void healthBar1()
    {
        if (isTimeCheck)
            return;

        healthBar.value -= 10;
         if(control.GameComboCountFloat >= 0)
         {
            control.GameComboCountFloat = 0;
            control.GameComboCountText.text = "0Combo";
         }
        if (healthBar.value <= 0)
        {           
            isTimeCheck = true;
            textObject.SetActive(true);
           
        }
  
    }

    public void Update()
    {
        if (isTimeCheck == true)
        {
            currentTime += Time.deltaTime;
        
            if (currentTime > MaxTime)
            {
                currentTime = 0f;
                Debug.Log("5초가 지났다");
                textObject.SetActive(false);
                SceneManager.LoadScene("Home");
            }
        }
    }
}