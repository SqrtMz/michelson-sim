using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class LaserFire : MonoBehaviour
{
    public Material material;
    private LaserBeam beam;
    private void Update()
    {
        if(beam != null)
        {
            Destroy(beam.laserObj);
        }
        beam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material);
    }
}