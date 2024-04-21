using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public Vector3 pos;

    public float sprig;
    public float damp;

    public bool button;
    public int dir = 1;

    HingeJoint hinge;
    
    [Space(10)]

    public float flipperSpeed = 10;
    public float flipperRot = 20;

    void Awake()
    {
        hinge = GetComponent<HingeJoint>();
    }

    void FixedUpdate()
    {
        flipperRot = -Mathf.Sign(System.Convert.ToByte(button) - .5f) * 20;

        JointSpring spring = new();
        spring.spring = sprig;
        spring.damper = damp;

        spring.targetPosition = flipperRot * dir;

        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
