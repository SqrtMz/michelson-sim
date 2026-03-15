using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MovePlane : MonoBehaviour
{
    public float planeMoveSpeed;
    public float xLimMax, xLimMin, yLimMax, yLimMin;
    public Transform actualPos;
    public Transform rotationHRef, rotationVRef;
    float angleH, angleV;
    float horizontalInput = 0f, verticalInput = 0f;
    public RotationInput inputH;
    public RotationInput inputV;

    public void Start()
    {
        actualPos.position = new Vector3(actualPos.position.x + UnityEngine.Random.Range(0f,1.70f), actualPos.position.y + UnityEngine.Random.Range(-2f, 2f), actualPos.position.z);
    }

    private void Update()
    {
        horizontalInput = -inputH.valorent;
        verticalInput = inputV.valorent;

        Vector3 moveDirection = new(horizontalInput, verticalInput, 0);
        
        transform.position = transform.position + planeMoveSpeed * Time.deltaTime * moveDirection;
        actualPos.position = new Vector3(Mathf.Clamp(actualPos.position.x, xLimMin, xLimMax), Mathf.Clamp(actualPos.position.y, yLimMin, yLimMax), actualPos.position.z);
    }
}