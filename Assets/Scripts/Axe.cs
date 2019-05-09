using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Sword
{
    public bool thrown = false;
    public float throwSpinSpeed;

    protected override void Start()
    {
        base.Start();
        selected = false;
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity * 5, angularVelocity);
        if ((linearVelocity * 5).magnitude > 5)
        {
            thrown = true;
            angularVelocity = new Vector3(40, 0, 0);
            rb.angularVelocity = transform.TransformVector(angularVelocity);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        thrown = false;
    }
}
