using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathMoment : MonoBehaviour
{
    public RingsDrawing ring1;
    public RingsDrawing ring2;
    public RingsDrawing ring3;
    public RingsDrawing ring4;
    public RingsDrawing ring5;
    public int totalrings;
    void Update()
    {
        totalrings = ring1.nRings + ring2.nRings + ring3.nRings + ring4.nRings + ring5.nRings;
    }
}
