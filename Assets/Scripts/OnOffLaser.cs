using System.Collections;
using TMPro;
using UnityEngine;

public class OnOffLaser : MonoBehaviour
{
    public GameObject laserDiodeIn;
    public GameObject laserDiodeInOut1;
    public GameObject laserDiodeInOut2;
    public GameObject laserDiodeOut;
    public GameObject laserPlane1;
    public GameObject laserPlane2;
    public MeshRenderer ringsRender;
    public CameraController tornilloMicButtons;
    public AudioSource turnOnLaser;
    public AudioSource turnOffLaser;
    public GameObject guide, turnOnGuide, switchViewGuide;
    public GameObject equations;
    public TextMeshProUGUI onLaserText;
    public SkipMiniGuide kill;
    public bool on = false, completed1 = false, skipMiniGuide = false;
    public float timeToWait;
  
    void Update()
    {
        if(Input.GetKeyDown("f") && !on && !guide.activeInHierarchy && !equations.activeInHierarchy)
        {
            on = true;
            turnOnLaser.Play();
            laserDiodeIn.SetActive(true);
            
            if(!completed1 && !skipMiniGuide)
            {
                StartCoroutine(OnLaser(turnOnGuide, switchViewGuide, onLaserText));
            }
        }
        else if (Input.GetKeyDown("r") && on && !guide.activeInHierarchy && !equations.activeInHierarchy)
        {
            on = false;
            turnOffLaser.Play();
            laserDiodeIn.SetActive(false);
            ringsRender.enabled = false;

            tornilloMicButtons.buttonIncrease.SetActive(false);
            tornilloMicButtons.buttonDecrease.SetActive(false);
        }

        ActivateLasers();

        if(tornilloMicButtons.currentView == tornilloMicButtons.views[3] && ringsRender.enabled)
        {
            tornilloMicButtons.buttonIncrease.SetActive(true);
            tornilloMicButtons.buttonDecrease.SetActive(true);
        }

        if(kill.killCoroutines)
        {
            StopAllCoroutines();
        }
    }

    void ActivateLasers()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(on && Physics.Raycast(ray, out hit))
        {
            if(hit.collider.name == "BeamSplitter")
            {
                laserDiodeInOut1.SetActive(true);
                laserDiodeInOut2.SetActive(true);
                laserDiodeOut.SetActive(true);
                laserPlane1.SetActive(true);
                laserPlane2.SetActive(true);
            }
            else if(hit.collider.name == "BaseInterferometro")
            {
                laserDiodeInOut1.SetActive(false);
                laserDiodeInOut2.SetActive(false);
                laserDiodeOut.SetActive(false);
                laserPlane1.SetActive(false);
                laserPlane2.SetActive(false);
                ringsRender.enabled = false;
                Destroy(GameObject.Find("Laser Beam"));
            }
        }
        else
        {
            laserDiodeInOut1.SetActive(false);
            laserDiodeInOut2.SetActive(false);
            laserDiodeOut.SetActive(false);
            laserPlane1.SetActive(false);
            laserPlane2.SetActive(false);
            ringsRender.enabled = false;
            Destroy(GameObject.Find("Laser Beam"));
        }
    }

    IEnumerator OnLaser(GameObject fistGuide, GameObject nextGuide, TextMeshProUGUI text)
    {   
        text.color = Color.green;

        yield return new WaitForSeconds(timeToWait);

        fistGuide.SetActive(false);
        nextGuide.SetActive(true);

        completed1 = true;
    }
}