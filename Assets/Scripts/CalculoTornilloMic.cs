using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculoTornilloMic : MonoBehaviour
{
    public float pasoDelTornillo = 5f / (2 * Mathf.PI); 
    private float rotacionInicial;
    private float vueltasCompletas = 0f;
    private float sentidoRotacion = 0f; 

    private void Start()
    {
        rotacionInicial = transform.rotation.eulerAngles.y;
    }

    private void Update()
    {
       
        float anguloActual = transform.rotation.eulerAngles.y;

        anguloActual = Mathf.Repeat(anguloActual,360f);

        float deltaAngulo = anguloActual - rotacionInicial;
        
        if (anguloActual < 360f  && sentidoRotacion == 1)
        {
            vueltasCompletas+=1f;
        }
       
        else if (anguloActual < 360f  && sentidoRotacion == -1)
        {
            vueltasCompletas+=-1f;
        }

      
        sentidoRotacion = (deltaAngulo > 0f) ? 1 : (deltaAngulo < 0f) ? -1 : sentidoRotacion;
        rotacionInicial = anguloActual;
        
        float distanciaMicrometros = (anguloActual + (360f * vueltasCompletas)) * Mathf.Deg2Rad * pasoDelTornillo;

        
        Debug.Log("Distancia: " + distanciaMicrometros + " milimetros");
        Debug.Log("Vueltas Completas: " + vueltasCompletas);
        Debug.Log("Angulo: " + anguloActual);
    }
}