using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTrigger : MonoBehaviour
{
    public LeftController leftController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MenuButton"))
        {
            leftController.ischecking = true;

            menubring test = other.GetComponent<menubring>();

            if (test != null)
            {
                leftController.number = test.uiNumber;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MenuButton"))
        {
            leftController.ischecking = false;
        }
    }
}
