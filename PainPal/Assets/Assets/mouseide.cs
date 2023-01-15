using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mouseide : MonoBehaviour
{

    public Material material;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenpos=Input.mousePosition;
        Ray ray=Camera.main.ScreenPointToRay(screenpos);
        if(Physics.Raycast(ray,out RaycastHit hitData)){
            Vector3 worldPosition=hitData.point;
            //mouse.position=worldPosition;
            //Material PalaceMaterial = material.GetComponent <Renderer> () .material;
            //material._displacementeffect = 1;
            material.SetVector("_worldposition",worldPosition);
            material.SetFloat("_effectradius",1);
            material.SetFloat("_displacementeffect",0.1f);
            //Debug.Log("a");

        }
        else{
            return;
        }
            
    }
}
