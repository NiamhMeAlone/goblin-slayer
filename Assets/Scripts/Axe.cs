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
        if (linearVelocity.magnitude > .5f)
        {
            thrown = true;
            base.GrabEnd(linearVelocity * 5, angularVelocity * 12);
        }
        else
        {
            base.GrabEnd(linearVelocity, angularVelocity);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        thrown = false;
    }
}
