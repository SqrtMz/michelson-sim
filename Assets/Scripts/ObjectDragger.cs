using System.Collections;
using UnityEngine;

public class ObjectDragger : MonoBehaviour
{
    public double spring = 50.0;
    public double damper = 5.0;
    public double drag = 10.0;
    public double angularDrag = 100;
    public double distance = 0.2;
    public double pushForce = 0.2;
    public bool attachToCenterOfMass = false;
    public Material highlightMaterial;
    private GameObject highlightObject;
    private SpringJoint springJoint;
    public AudioSource selectingAudio;

    void Update()
    {
        Camera mainCamera = FindCamera();

        highlightObject = null;
        if (springJoint != null && springJoint.connectedBody != null)
        {
            highlightObject = springJoint.connectedBody.gameObject;
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if (hit.rigidbody && !hit.rigidbody.isKinematic)
                {
                    highlightObject = hit.rigidbody.gameObject;
                }
            }
        }

        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        RaycastHit hitInfo;
        if (!Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hitInfo, 100))
        {
            return;
        }

        if (!hitInfo.rigidbody || hitInfo.rigidbody.isKinematic)
        {
            return;
        }

        if (!springJoint)
        {
            GameObject go = new GameObject("Rigidbody dragger");
            Rigidbody body = go.AddComponent<Rigidbody>();
            springJoint = go.AddComponent<SpringJoint>();
            body.isKinematic = true;
        }

        springJoint.transform.position = hitInfo.point;
        if (attachToCenterOfMass)
        {
            Vector3 anchor = transform.TransformDirection(hitInfo.rigidbody.centerOfMass) + hitInfo.rigidbody.transform.position;
            anchor = springJoint.transform.InverseTransformPoint(anchor);
            springJoint.anchor = anchor;
        }
        else
        {
            springJoint.anchor = Vector3.zero;
        }

        springJoint.spring = (float)spring;
        springJoint.damper = (float)damper;
        springJoint.maxDistance = (float)distance;
        springJoint.connectedBody = hitInfo.rigidbody;

        StartCoroutine(DragObject(hitInfo.distance, hitInfo.point, mainCamera.ScreenPointToRay(Input.mousePosition).direction));
    }

    IEnumerator DragObject(float distance, Vector3 hitpoint, Vector3 dir)
    {
        float startTime = Time.time;
        Vector3 mousePos = Input.mousePosition;

        float oldDrag = springJoint.connectedBody.drag;
        float oldAngularDrag = springJoint.connectedBody.angularDrag;
        springJoint.connectedBody.drag = 1e+8f;
        springJoint.connectedBody.angularDrag = 1e+8f;
        Camera mainCamera = FindCamera();
        
        while (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            springJoint.transform.position = ray.GetPoint(distance);
            yield return null;
        }

        if (Mathf.Abs(mousePos.x - Input.mousePosition.x) <= 2 && Mathf.Abs(mousePos.y - Input.mousePosition.y) <= 2 && Time.time - startTime < 0.2 && springJoint.connectedBody)
        {
            dir.y = 0;
            dir.Normalize();
            springJoint.connectedBody.AddForceAtPosition(dir * (float)pushForce, hitpoint, ForceMode.VelocityChange);
            ToggleLight(springJoint.connectedBody.gameObject);
        }

        if (springJoint.connectedBody)
        {
            springJoint.connectedBody.drag = oldDrag;
            springJoint.connectedBody.angularDrag = oldAngularDrag;
            springJoint.connectedBody = null;
        }
    }

    void ToggleLight(GameObject go)
    {
        Light theLight = go.GetComponentInChildren<Light>();
        if (!theLight)
            return;

        theLight.enabled = !theLight.enabled;
        bool illumOn = theLight.enabled;
        MeshRenderer[] renderers = go.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer r in renderers)
        {
            if (r.gameObject.layer == 1)
            {
                r.material.shader = Shader.Find(illumOn ? "Standard" : "Standard");
            }
        }
    }

    Camera FindCamera()
    {
        if (Camera.main != null)
            return Camera.main;
        else
            return Camera.current;
    }

    void OnPostRender()
    {
        if (highlightObject == null)
            return;

        GameObject go = highlightObject;
        highlightMaterial.SetPass(0);
        MeshFilter[] meshes = go.GetComponentsInChildren<MeshFilter>();
        foreach (MeshFilter m in meshes)
        {
            Graphics.DrawMeshNow(m.sharedMesh, m.transform.position, m.transform.rotation);
        }
    }
}