using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterFace : MonoBehaviour
{

    public Slider healthBar;

    public void healthBar1()
    {
        healthBar.value -= 10;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}