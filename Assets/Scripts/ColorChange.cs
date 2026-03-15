using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material material;
    public float longitudDeOnda = 532.0f;
    public float velocidadCambio;

    void Update()
    {
        longitudDeOnda = Mathf.Clamp(longitudDeOnda, 380.0f, 700.0f);
        CambiarColorSegunLongitudDeOnda();
    }

    public void DownInc()
    {
        InvokeRepeating("DragInc", 0, 0.1f);
    }

    public void DragInc()
    {
        IncreaseLambda();
    }

    public void UpInc()
    {
        CancelInvoke("DragInc");
    }

    public void DownDec()
    {
        InvokeRepeating("DragDec", 0, 0.1f);
    }

    public void DragDec()
    {
        DecreaseLambda();
    }

    public void UpDec()
    {
        CancelInvoke("DragDec");
    }

    public void IncreaseLambda()
    {
        if(longitudDeOnda != 700f)
        {
            longitudDeOnda += velocidadCambio;
        }
    }

    public void DecreaseLambda()
    {
        if(longitudDeOnda != 380)
        {
            longitudDeOnda -= velocidadCambio;
        }
    }

    void CambiarColorSegunLongitudDeOnda()
    {
        Color color = CalcularColorDesdeLongitudDeOnda(longitudDeOnda);
        material.SetColor("_EmissionColor", color);
    }

    Color CalcularColorDesdeLongitudDeOnda(float longitudDeOnda)
    {
        float r = 0.0f;
        float g = 0.0f;
        float b = 0.0f;

        if (longitudDeOnda >= 380 && longitudDeOnda < 440)
        {
            r = -(longitudDeOnda - 440) / (440 - 380);
            b = 1.0f;
        }
        else if (longitudDeOnda >= 440 && longitudDeOnda < 490)
        {
            g = (longitudDeOnda - 440) / (490 - 440);
            b = 1.0f;
        }
        else if (longitudDeOnda >= 490 && longitudDeOnda < 510)
        {
            g = 1.0f;
            b = -(longitudDeOnda - 510) / (510 - 490);
        }
        else if (longitudDeOnda >= 510 && longitudDeOnda < 580)
        {
            r = (longitudDeOnda - 510) / (580 - 510);
            g = 1.0f;
        }
        else if (longitudDeOnda >= 580 && longitudDeOnda < 701)
        {
            r = 1.0f;
            g = -(longitudDeOnda - 701) / (701 - 580);
        }

        float attenuationFactor = 0.5f;

        return new Color(r * attenuationFactor, g * attenuationFactor, b * attenuationFactor);
    }
}