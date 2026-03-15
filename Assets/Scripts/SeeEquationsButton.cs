using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SeeEquationsButton : MonoBehaviour
{
    public TextMeshProUGUI guideText;
    public GameObject equations;

    public void Update()
    {
        if(guideText.pageToDisplay == 3) 
        {
            equations.SetActive(true);
        }
        else
        {
            equations.SetActive(false);
        }
    }
}
