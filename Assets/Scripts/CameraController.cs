using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using JetBrains.Annotations;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] views;
    public float transitionSpeed = 10f, timeToWait, timeToWaitGuide;
    public Transform currentView;
    public Camera mainCamera;
    public GameObject pantallaCamera;
    public GameObject buttonIncrease, buttonDecrease, buttonUp, buttonDown, buttonRight, buttonLeft;
    public GameObject guide, switchGuideRotation, switchGuideAlign, switchGuideScrew, switchGuideCount;
    public GameObject equations;
    public RingsAppear isRing;
    public TextMeshProUGUI switchViewRotation, switchViewScrew, alignText;
    public OnOffLaser completed, skip;
    public SkipMiniGuide kill;
    public bool view3, completed2 = false, completed3 = false, completed4 = false;

     void Start()
     {
        currentView = transform;
        mainCamera = this.GetComponent<Camera>();
     }

     void Update() 
     {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !guide.activeInHierarchy && !equations.activeInHierarchy)
        {
            currentView = views[0];
            view3 = false;

            pantallaCamera.SetActive(false);
            mainCamera.rect = new Rect(0f, 0f, 1f, 1f);

            buttonIncrease.SetActive(false);
            buttonDecrease.SetActive(false);

            buttonUp.SetActive(false);
            buttonDown.SetActive(false);
            buttonRight.SetActive(false);
            buttonLeft.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2) && !guide.activeInHierarchy && !equations.activeInHierarchy)
        {
            currentView = views[1];
            view3 = false;

            pantallaCamera.SetActive(false);
            mainCamera.rect = new Rect(0f, 0f, 1f, 1f);

            buttonIncrease.SetActive(false);
            buttonDecrease.SetActive(false);

            buttonUp.SetActive(false);
            buttonDown.SetActive(false);
            buttonRight.SetActive(false);
            buttonLeft.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && !guide.activeInHierarchy && !equations.activeInHierarchy)
        { 
            currentView = views[2];
            view3 = true;

            pantallaCamera.SetActive(true);
            mainCamera.rect = new Rect(0f, 0f, 0.5f, 1f);

            buttonIncrease.SetActive(false);
            buttonDecrease.SetActive(false);

            buttonUp.SetActive(true);
            buttonDown.SetActive(true);
            buttonRight.SetActive(true);
            buttonLeft.SetActive(true);

            if(!completed2 && completed.completed1 && !skip.skipMiniGuide)
            {
                StartCoroutine(SwitchView(switchGuideRotation, switchGuideAlign, switchViewRotation));

                completed2 = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && !guide.activeInHierarchy && !equations.activeInHierarchy)
        { 
            currentView = views[3];
            view3 = false;

            pantallaCamera.SetActive(true);
            mainCamera.rect = new Rect(0f, 0f, 0.5f, 1f);

            if (isRing.ringsRender.enabled)
            {
                buttonIncrease.SetActive(true);
                buttonDecrease.SetActive(true);
            }

            buttonUp.SetActive(false);
            buttonDown.SetActive(false);
            buttonRight.SetActive(false);
            buttonLeft.SetActive(false);

            if(!completed4 && completed.completed1 && completed2 && completed3 && !skip.skipMiniGuide)
            {
                StartCoroutine(SwitchView(switchGuideScrew, switchGuideCount, switchViewScrew));

                completed4 = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && !guide.activeInHierarchy && !equations.activeInHierarchy)
        { 
            currentView = views[4];
            view3 = false;

            pantallaCamera.SetActive(false);
            mainCamera.rect = new Rect(0f, 0f, 1f, 1f);

            buttonIncrease.SetActive(false);
            buttonDecrease.SetActive(false);

            buttonUp.SetActive(false);
            buttonDown.SetActive(false);
            buttonRight.SetActive(false);
            buttonLeft.SetActive(false);
        }

        if(isRing.ringsRender.enabled && !completed3 && completed2 && completed.completed1 && !skip.skipMiniGuide)
        {
            completed3 = true;
            StartCoroutine(SwitchView(switchGuideAlign, switchGuideScrew, alignText));
        }

        if(kill.killCoroutines)
        {
            StopAllCoroutines();
        }
     }

     private void LateUpdate() 
     {
        transform.position = Vector3.Lerp(transform.position,currentView.position,Time.deltaTime * transitionSpeed);

        Vector3 currentAngle = new Vector3(
            Mathf.Lerp(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
            Mathf.Lerp(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),    
            Mathf.Lerp(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed)
        );

        transform.eulerAngles = currentAngle;
     }

        IEnumerator SwitchView(GameObject fistGuide, GameObject nextGuide, TextMeshProUGUI text)
    {   
        text.color = Color.green;

        yield return new WaitForSeconds(timeToWaitGuide);

        fistGuide.SetActive(false);
        nextGuide.SetActive(true);
    }
}