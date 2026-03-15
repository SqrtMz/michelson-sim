using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextChange : MonoBehaviour
{
    public TextMeshPro textoTMP;
    public MathMoment tRings;
    public ColorChange lDeOnda;
    void Update()
    {
        CambioDeTexto();
    }

    public void CambioDeTexto()
    {
        float resultado_math = ((tRings.totalrings * (lDeOnda.longitudDeOnda * 1e-9f)) / 2) * 1e6f;
        string resultado_string = Math.Abs(resultado_math).ToString("0.000");
        textoTMP.text = ("Medida del Tornillo Micrométrico: \n" + resultado_string + "µm");   
    }
}