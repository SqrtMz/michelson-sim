using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RingsDrawing : MonoBehaviour
{
    LineRenderer ringDraw;
    float theta = 0f;
    float thetaScale = 0.01f;
    int size;
    public MeshRenderer ringPlane;
    public float radio;
    public float ringsSpeed = 0.1f;
    public float lambdaMultiplier = 1f;
    public int nRings;
    public ColorChange factorLambda;

    private void Start()
    {
        ringDraw = this.GetComponent<LineRenderer>();
    }

    [Obsolete]
    private void Update()
    {
        lambdaMultiplier = 1/(1f +((factorLambda.longitudDeOnda - 380f) / (700f - 380f)));

        if(ringPlane.enabled)
        {
            ringDraw.enabled = true;
            DrawRing(radio);

            if(radio > 5f)
            {
                radio = 0f;
                nRings += 1;
            }
            else if(radio < 0f)
            {
                radio = 5f;    
                nRings -= 1;
            }
        }
        else
        {
            ringDraw.enabled = false;
        }
    }

    public void DownBig()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        InvokeRepeating("DragBig", 0, 0.05f);
    }

    public void DragBig()
    {
        radiusGoesBig();
    }

    public void UpBig()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        CancelInvoke("DragBig");
    }

    public void DownSmall()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        InvokeRepeating("DragSmall", 0, 0.05f);
    }

    public void DragSmall()
    {
        radiusGoesSmall();
    }

    public void UpSmall()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        CancelInvoke("DragSmall");
    }

    public void radiusGoesBig()
    {
        radio += ringsSpeed * lambdaMultiplier;
    }

    public void radiusGoesSmall()
    {
        radio -= ringsSpeed * lambdaMultiplier;
    }

    [Obsolete]
    void DrawRing(float radio)
    {
        theta = 0f;
        size = (int)((1f / thetaScale) + 1f);
        ringDraw.SetVertexCount(size);

        for(int i = 0; i < size; i++)
        {
            theta += (2.0f * Mathf.PI * thetaScale);
            
            float x = radio * Mathf.Cos(theta);
            float y = radio * Mathf.Sin(theta);

            ringDraw.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}