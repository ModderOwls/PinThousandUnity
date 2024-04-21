using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballController : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;

    [HideInInspector] public CameraMain cam;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
}
