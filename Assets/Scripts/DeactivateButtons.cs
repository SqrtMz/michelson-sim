using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateButtons : MonoBehaviour
{
    public UnityEngine.UI.Button button;
    public GameObject guide;
    public void Update()
    {   
        if(!guide.activeInHierarchy)
        {
            button.interactable = true;
        }
        else if(guide.activeInHierarchy)
        {
            button.interactable = false;
        }
    }
}
