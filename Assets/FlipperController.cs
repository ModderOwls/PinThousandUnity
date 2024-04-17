using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public int button;
    public int dir = 1;
    
    [Space(10)]

    public float flipperSpeed = 10;
    public float flipperRot = 20;

    void Update()
    {
        flipperRot = Mathf.Lerp(flipperRot, -Mathf.Sign(button-.5f)*20, Time.deltaTime*flipperSpeed);
        transform.localEulerAngles = new Vector3(0, 0, flipperRot * dir);
    }
}
