using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class ArduinoInputHandler : MonoBehaviour
{
    SerialPort stream = new SerialPort("\\.\\COM7", 9600);

    public bool buttonL;
    public bool buttonR;

    void Start()
    {
        stream.Open();
    }

    void Update()
    {
        string value = stream.ReadLine();
        Debug.Log(value);
        switch (int.Parse(value.Substring(0, 2)))
        {
            case 8:
                buttonL = bool.Parse(value[2..^(-1)]);
                break;
            case 9:
                buttonR = bool.Parse(value[2..^(-1)]);
                break;
        }
    }
}
