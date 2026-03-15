using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationInput : MonoBehaviour
{
    public GameObject tornillo;
    public float angleBasis;
    public float valorent;

    public void Start()
    {
        angleBasis = tornillo.transform.rotation.eulerAngles.z;
    }
    public void Update()
    {
        if(Input.GetMouseButton(0))
        {
            float angle = tornillo.transform.rotation.eulerAngles.z;

            valorent = angle - angleBasis;
            valorent = Mathf.Repeat(valorent,360f);
            valorent = Mathf.Sin(Mathf.Deg2Rad * valorent);
            valorent = (float)(valorent * 1);
 
            angleBasis = tornillo.transform.rotation.eulerAngles.z;
            
            return;
        }

        if(Input.GetMouseButtonUp(0))
        {
            valorent = 0f;

            angleBasis = tornillo.transform.rotation.eulerAngles.z;
        }

    }
}