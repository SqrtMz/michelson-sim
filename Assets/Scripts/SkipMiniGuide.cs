using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipMiniGuide : MonoBehaviour
{
    public OnOffLaser skip, Oncompleted;
    public CameraController completed;
    public GameObject OnGuide, view3Guide, alignGuide, view4Guide, countGuide;

    public bool killCoroutines;

    public void CloseAll()
    {
        StopAllCoroutines();
        OnGuide.SetActive(false);
        view3Guide.SetActive(false);
        alignGuide.SetActive(false);
        view4Guide.SetActive(false);
        countGuide.SetActive(false);

        skip.skipMiniGuide = true;

        Oncompleted.completed1 = true;
        completed.completed2 = true;
        completed.completed2 = true;

        killCoroutines = true;
    }
}
