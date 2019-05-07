using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Sword : OVRGrabbable
{
    public Vector3 floatPos;
    public Rigidbody rb;
    public float rotateSpeed;
    public bool selectMode;
    public bool selected;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected override void Start()
    {
        selectMode = true;
        selected = true;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (selectMode)
        {
            rb.isKinematic = true;
            if (selected)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, Time.deltaTime * rotateSpeed, 0));
            }
            if (isGrabbed)
            {
                selectMode = false;
                transform.parent = WeaponSelect.wheel.transform.parent;
            }
        }
    }
}
