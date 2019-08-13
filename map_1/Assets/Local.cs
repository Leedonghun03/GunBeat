using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Local : MonoBehaviour
{
    public string StringValue;

    void Start()
    {
        
    }
    
    public void SaveClick()
    {
        PlayerPrefs.SetString("KimVaule", StringValue);
    }
}
