using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceScript : MonoBehaviour
{
    public float smooth;
    public Vector3 offset;

    public ArduinoInputHandler arduino;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.MoveRotation(Quaternion.Lerp(rb.rotation, Quaternion.Euler(arduino.buttonGyro + offset), Time.deltaTime * smooth));
    }
}
