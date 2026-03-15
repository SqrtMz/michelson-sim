using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsAppear : MonoBehaviour
{
    public MeshRenderer ringsRender, fpRender, mpRender;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FixedCollider")
        {
            fpRender.enabled = false;
            mpRender.enabled = false;
            ringsRender.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        fpRender.enabled = true;
        mpRender.enabled = true;
        ringsRender.enabled = false;
    }
}