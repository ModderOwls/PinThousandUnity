using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballController : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;

    [HideInInspector] public CameraMain cam;
    [HideInInspector] public ArduinoInputHandler arduino;

    [HideInInspector] public Vector3 lastPosition;
    LayerMask layerGround;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        layerGround = LayerMask.GetMask("Ground");

        lastPosition = transform.position;
    }

    void FixedUpdate()
    {
        RaycastHit ray;
        Physics.Raycast(lastPosition, rb.position - lastPosition, out ray, Vector3.Distance(rb.position, lastPosition), layerGround);
        Debug.DrawRay(lastPosition, rb.position - lastPosition);

        if (ray.collider)
        {
            rb.position -= (rb.position - ray.point) * 1.2f;
        }

        lastPosition = rb.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bumper"))
        {
            arduino.serial.SendSerialMessage("1");
            Debug.Log("Sent to arduino: Bumper");
        }
    }
}
