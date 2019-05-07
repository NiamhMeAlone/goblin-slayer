using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Sword
{
    protected override void Start()
    {
        base.Start();
        selected = false;
    }

    protected override void Update()
    {
        base.Update();
    }
}
