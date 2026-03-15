using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPrinting : MonoBehaviour
{
    public TextMeshProUGUI text;
    public ColorChange lambda;

    void Update()
    {
        PrintValue();
    }

    void PrintValue()
    {
        text.text = lambda.longitudDeOnda.ToString() + "nm";
    }
}