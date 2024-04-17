using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 launchPos;

    [Header("Refs")]

    ArduinoInputHandler arduino;

    public Rigidbody ball;

    public FlipperController flipperL;
    public FlipperController flipperR;

    public StarterController starter;

    void Awake()
    {
        arduino = GetComponent<ArduinoInputHandler>();
    }

    void Update()
    {
        flipperL.button = arduino.buttonL;
        flipperR.button = arduino.buttonR;

        if (starter.touchingBall)
        {
            if (flipperR || flipperL)
            {
                ball.velocity += launchPos;
                starter.touchingBall = false;
            }
        }
    }
}
