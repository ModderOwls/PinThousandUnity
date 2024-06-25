using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperHandler : MonoBehaviour
{
    public ArduinoInputHandler arduino;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bumper"))
        {
            arduino.serial.SendSerialMessage("1");
            Debug.Log("Sent to arduino: Bumper");
        }
    }
}
