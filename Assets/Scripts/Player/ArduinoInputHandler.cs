using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class ArduinoInputHandler : MonoBehaviour
{
    public string port;
    SerialPort stream;

    public bool buttonL;
    public bool buttonR;


    string lastStream;
    public void OnMessageArrived(string msg)
    {
        if (lastStream == msg) return;
        lastStream = msg;

        int id = 0;
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
