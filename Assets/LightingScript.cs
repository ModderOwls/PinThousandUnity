using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingScript : MonoBehaviour
{
    Light directionalLight;

    float flicker;

    void Start()
    {
        directionalLight = GetComponent<Light>();
    }

    void Update()
    {
        //flickering.

        flicker += Time.deltaTime * 1.75f;

        directionalLight.intensity = 2 + Mathf.Sin(flicker) * .3f;

        Vector3 angles = transform.eulerAngles;

        angles.x = 60 - Mathf.Sin(flicker) * 4;

        transform.eulerAngles = angles;
    }


}
