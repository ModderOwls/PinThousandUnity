using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    public PinballController player;

    public bool focusPlayer;

    public float offsetForward = 10;

    Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        transform.parent = null;
    }

    void Update()
    {

        if (focusPlayer) ShotPlayer(); else ShotWide();
    }

    void ShotPlayer()
    {
        Vector3 camPos = player.transform.position - Vector3.forward * (offsetForward + player.transform.position.z*.3f);
        transform.position = Vector3.Lerp(transform.position, camPos, Time.deltaTime * 6);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 35, Time.deltaTime * 4);
    }

    void ShotWide()
    {
        Vector3 camPos = new Vector3(0, -2.7f, -28);
        transform.position = Vector3.Lerp(transform.position, camPos, Time.deltaTime * 10);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 50, Time.deltaTime * 3);
    }
}
