using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : OVRGrabbable
{
    public Vector3 floatPos;
    public float rotateSpeed;
    public bool thrown = false;
    public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (!isGrabbed && !thrown)
        {
            transform.position = floatPos;
            transform.rotation = Quaternion.Euler(0, Time.time * rotateSpeed, 0);
        }
        else if (!isGrabbed)
        {

        }
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        thrown = true;
        base.GrabEnd(linearVelocity, angularVelocity);
    }

    public void OnCollisionEnter(Collision collision)
    {
        thrown = false;
    }
}
