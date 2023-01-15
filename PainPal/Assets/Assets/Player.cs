using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;


public class Player : MonoBehaviour
{

    public Material vertexMaterial;
    public Material colorMaterial;
    [Range(0f,0.2f)]
    public float effectradius=0.03f;
    float radius=0;
    [Range(0f, 0.2f)]
    public float displacementeffect=0.03f;
    float displacement = 0.005f;
    public GameObject pointer;
    bool IsColliding;
    Vector3 worldPosition;

    // Start is called before the first frame update
    void Start()
    {
        vertexMaterial.SetFloat("_effectradius", 0);
        vertexMaterial.SetFloat("_displacementeffect", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 screenpos = Input.mousePosition;
        //Ray ray = Camera.main.ScreenPointToRay(screenpos);
        //if (Physics.Raycast(ray, out RaycastHit hitData))
        //{
        //    Vector3 worldPosition = hitData.point;
        //    //mouse.position=worldPosition;
        //    //Material PalaceMaterial = material.GetComponent <Renderer> () .material;
        //    //material._displacementeffect = 1;
        //    material.SetVector("_worldposition", worldPosition);
        //    material.SetFloat("_effectradius", effectradius);
        //    material.SetFloat("_displacementeffect", displacementeffect);
        //    //Debug.Log("a");

        //}
        //else
        //{
        //    return;
        //}

        if (IsColliding) 
        {
            //Debug.Log("IsColling");

            worldPosition = pointer.transform.position;

            var joysticAxis = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick, OVRInput.Controller.RTouch);

            //Debug.Log("(" + joysticAxis.x + "," +joysticAxis.y+ ")");

            if (joysticAxis.y>0)
            {
                    radius += Time.deltaTime / 50; // Cap at some max value too
                    Debug.Log(radius);
            }
            else if (joysticAxis.y < 0)
            {
                radius -= Time.deltaTime/50; // Cap at some min value too
            }

            if (radius < 0.01f)
            {
                effectradius = 0.01f;
            }
            else if (radius > 0.2f)
            {
                effectradius = 0.2f;
            }
            else
            {
                effectradius = radius;
            }

            if (OVRInput.Get(OVRInput.Touch.One))
            {
                Debug.Log("Button A Pressed");
                displacement -= Time.deltaTime / 50;
                Debug.Log(displacement);
            }

            if (OVRInput.Get(OVRInput.Touch.Two))
            {
                Debug.Log("Button B Pressed");
                displacement += Time.deltaTime / 50;
            }

            if (displacement < 0.005f)
            {
                displacementeffect = 0.005f;
            }

            else if (displacement > 0.4f)
            {
                displacementeffect = 0.4f;
            }

            else
            {
                displacementeffect = displacement;
            }

            vertexMaterial.SetVector("_worldposition", worldPosition);
            vertexMaterial.SetFloat("_effectradius", effectradius);
            vertexMaterial.SetFloat("_displacementeffect", displacementeffect);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        IsColliding = true;
    }
    private void OnTriggerExit(Collider other)
    {
        IsColliding = false;
    }
}
