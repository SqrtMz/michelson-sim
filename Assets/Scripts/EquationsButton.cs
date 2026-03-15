using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationsButton : MonoBehaviour
{
    bool equationOn = false;
    public GameObject equationisImg;

    public void EnableEquationsButton()
    {
        if(!equationOn)
        {
            equationOn = true;

            equationisImg.SetActive(true);
        }
        else if(equationOn)
        {
            equationOn = false;

            equationisImg.SetActive(false);
        }
    }
}
