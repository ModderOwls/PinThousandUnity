using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceScript : MonoBehaviour
{
    public Vector3 rotation;
    public Vector3 offset;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.MoveRotation(Quaternion.Euler(rotation + offset));
    }
}
