using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PageChanger : MonoBehaviour
{
    public TextMeshProUGUI guidePage;
    public float minPage= 0f;
    public float maxPage = 4f;
    public void NextPage()
    {
        guidePage.pageToDisplay += 1;
    }
    public void PreviousPage()
    {
        guidePage.pageToDisplay -= 1;
    }
    public void Update()
    {
        if(guidePage.pageToDisplay == minPage)
        {
            guidePage.pageToDisplay += 1;
        }
        else if(guidePage.pageToDisplay == maxPage)
        {
            guidePage.pageToDisplay -= 1;
        }
    }
}
