using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HelpButton : MonoBehaviour
{
    bool helpOn = true;
    bool appeared = false;
    public GameObject controlsImg, miniGuide;
    public OnOffLaser skip;

    public void EnableHelpButton()
    {
        if(!helpOn)
        {
            helpOn = true;

            controlsImg.SetActive(true);
        }
        else if(helpOn)
        {
            helpOn = false;

            controlsImg.SetActive(false);
        }

        if(!appeared && !skip.skipMiniGuide)
        {
            appeared = true;

            miniGuide.SetActive(true);
        }
    }
}