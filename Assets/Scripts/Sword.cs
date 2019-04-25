using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Sword : OVRGrabbable
{
    public Vector3 floatPos;
    public float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        if (!isGrabbed)
        {
            transform.position = floatPos;
            transform.rotation = Quaternion.Euler(0, Time.time * rotateSpeed, 0);
        }
    }
}
