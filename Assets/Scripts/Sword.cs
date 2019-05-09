using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Sword : OVRGrabbable
{
    public Vector3 floatPos;
    public Rigidbody rb;
    public float rotateSpeed;
    public GameObject hand;
    public bool selectMode;
    public bool selected;
    public bool returning;

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
            if (isGrabbed && selected)
            {
                selectMode = false;
                transform.parent = WeaponSelect.wheel.transform.parent;
                WeaponSelect.wheel.Remove();
                hand = grabbedBy.gameObject;
            }
        }
        else
        {
            if (OVRInput.GetDown(OVRInput.Button.Two) && !isGrabbed)
            {
                returning = true;
                rb.constraints = RigidbodyConstraints.FreezePosition;
            }
            if (OVRInput.GetUp(OVRInput.Button.Two) || isGrabbed)
            {
                returning = false;
                rb.constraints = RigidbodyConstraints.None;
            }
            if (returning)
            {
                transform.position = Vector3.Lerp(transform.position, hand.transform.position, Time.deltaTime * 5);
            }
        }
    }
}
