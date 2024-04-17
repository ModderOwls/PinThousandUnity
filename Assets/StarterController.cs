using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterController : MonoBehaviour
{
    public bool touchingBall;

    void OnCollisionEnter(Collision coll)
    {
        touchingBall = true;
    }

    void OnCollisionExit(Collision coll)
    {
        touchingBall = false;
    }
}
