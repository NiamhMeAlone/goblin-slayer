 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Monster
{
    public Limb head, leftFoot, rightFoot, leftHand, rightHand;

    public override void Start()
    {
        base.Start();
        limb1 = leftFoot;
        limb2 = rightFoot;
        limb3 = leftHand;
        limb4 = rightHand;
        limb5 = head;
    }
}
