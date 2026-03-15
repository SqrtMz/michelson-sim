using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public String sceneName;
    public Animator transition;
    public float timeTransition = 0.5f;
    
    public void SceneChange()
    {
        StartCoroutine(LoadTransition(sceneName));
    }

    IEnumerator LoadTransition(string name)
    {
        transition.SetTrigger("Change");

        yield return new WaitForSeconds(timeTransition);

        SceneManager.LoadScene(name);
    }
}