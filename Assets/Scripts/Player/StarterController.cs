using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterController : MonoBehaviour
{
    public bool touchingBall;
    public PinballController player;

    void OnTriggerEnter(Collider coll)
    {
        touchingBall = true;
    }

    void OnTriggerExit(Collider coll)
    {
        touchingBall = false;
    }
}
