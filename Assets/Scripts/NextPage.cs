using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NextPage : MonoBehaviour
{
    public TextMeshProUGUI guideText;
    public GameObject nextPage;

    public void Update()
    {
        if(guideText.pageToDisplay == 3) 
        {
            nextPage.SetActive(false);
        }
        else
        {
            nextPage.SetActive(true);
        }
    }
}
