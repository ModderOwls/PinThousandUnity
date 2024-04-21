using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    public PinballController player;

    public bool focusPlayer;

    public float offsetForward = 23;
    public float velSpeed;

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
        Vector3 camPos = Vector3.Lerp(transform.position, 
            new Vector3(player.transform.position.x*.2f, player.transform.position.y - 1 + player.rb.velocity.y * velSpeed, player.transform.position.z - (offsetForward + player.transform.position.z*.25f))
            , Time.deltaTime * 6);

        camPos.y = Mathf.Clamp(camPos.y, -8f, 100);

        transform.position = camPos;

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 35, Time.deltaTime * 4);
    }

    void ShotWide()
    {
        Vector3 camPos = new(0, -2.7f, -28);
        transform.position = Vector3.Lerp(transform.position, camPos, Time.deltaTime * 10);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 50, Time.deltaTime * 3);
    }
}
