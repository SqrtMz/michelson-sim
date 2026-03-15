using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePlaneButton : MonoBehaviour
{
public GameObject buttonUp, buttonDown, buttonRight, buttonLeft;
public Transform actualPos;
private float horizontalInput = 0f, verticalInput = 0f;
public float xLimMax, xLimMin, yLimMax, yLimMin, movement;

    public void Up()
    {
        verticalInput = movement;
    }
    public void Down()
    {
        verticalInput = -movement;
    }
    public void Right()
    {
        horizontalInput = movement;
    }
    public void Left()
    {
        horizontalInput = -movement;
    }
    private void Update()
    {
        Vector3 moveDirection = new(horizontalInput, verticalInput, 0);

        transform.position = transform.position + moveDirection;
        
        horizontalInput = 0f;
        verticalInput = 0f;

        actualPos.position = new Vector3(Mathf.Clamp(actualPos.position.x, xLimMin, xLimMax), Mathf.Clamp(actualPos.position.y, yLimMin, yLimMax), actualPos.position.z);
    }
}
