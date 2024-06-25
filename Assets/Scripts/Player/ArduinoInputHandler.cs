using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class ArduinoInputHandler : MonoBehaviour
{
    public string port;

    public bool buttonL;
    public bool buttonR;
    public Vector3 buttonGyro;

    [HideInInspector] public SerialController serial;
    [HideInInspector] public SerialPort serialPort;

    void Awake()
    {
        serial = GetComponent<SerialController>();
    }

    string lastStream;
    public void OnMessageArrived(string msg)
    {
        if (lastStream == msg) return;
        lastStream = msg;

        
        int id = 0;
        int idVector = 0;
        string number = "";
        foreach(char i in msg)
        {
            if (i == 'a')
            {
                switch (id)
                {
                    case 0:
                        buttonL = !Convert.ToBoolean(int.Parse(number));
                        break;
                    case 1:
                        buttonR = !Convert.ToBoolean(int.Parse(number));
                        break;
                }

                ++id;
                number = "";
            }
            else if (i == ',')
            {
                switch (idVector)
                {
                    case 0:
                        buttonGyro[2] = float.Parse(number);
                        break;
                    case 1:
                        buttonGyro[1] = float.Parse(number);
                        break;
                    case 2:
                        buttonGyro[0] = float.Parse(number);
                        break;
                }

                ++idVector;
                number = "";
            }
            else
            {
                number += i;
            }
        }
    }

    public void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");

    }
}
