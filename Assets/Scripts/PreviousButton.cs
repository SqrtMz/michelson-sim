using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PreviousButton : MonoBehaviour
{
    public TextMeshProUGUI guideText;
    public GameObject previousPage;

    public void Update()
    {
        if(guideText.pageToDisplay == 1) 
        {
            previousPage.SetActive(false);
        }
        else 
        {
            previousPage.SetActive(true);
        }
    }
}
