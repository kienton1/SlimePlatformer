using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    [SerializeField] float innerRadiusLight;
    [SerializeField] float outerRadiusLight;
    [SerializeField] float secondsBetweenFlickers;

    Light2D myLight;

    private void Start ()
    {
        myLight = GetComponent<Light2D>();
        StartCoroutine(LightFlickers());
    }


    IEnumerator LightFlickers()
    {
        yield return new WaitForSeconds(secondsBetweenFlickers);
        myLight.pointLightOuterRadius = Random.Range(innerRadiusLight, outerRadiusLight);
        StartCoroutine(LightFlickers());

    }
        
}

