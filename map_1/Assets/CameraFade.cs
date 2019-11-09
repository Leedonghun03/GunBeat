using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CameraFade : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SteamVR_Fade.Start(Color.black, 4.0f, true);
        }    
    }
}
