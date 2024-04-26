using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 launchPos;

    [Header("Refs")]

    ArduinoInputHandler arduino;

    public PinballController ball;

    public FlipperController flipperL;
    public FlipperController flipperR;

    public StarterController starter;

    public CameraMain cam;

    void Awake()
    {
        arduino = GetComponent<ArduinoInputHandler>();

        starter.player = ball;
        ball.cam = cam;
    }

    void FixedUpdate()
    {
        if (!arduino.enabled)
        {
            arduino.buttonL = Input.GetKey(KeyCode.A);
            arduino.buttonR = Input.GetKey(KeyCode.D);
        }

        flipperL.button = arduino.buttonL;
        flipperR.button = arduino.buttonR;

        if (starter.touchingBall)
        {
            if (arduino.buttonR && arduino.buttonL)
            {
                ball.rb.velocity = launchPos;
                starter.touchingBall = false;

                cam.focusPlayer = true;
            }
        }
    }
}
