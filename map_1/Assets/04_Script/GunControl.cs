using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class GunControl : MonoBehaviour
{


    public SteamVR_TrackedObject mTracjedObj;
    private Hand hand;

    
    void Start()
    {
        hand = gameObject.GetComponent<Hand>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
