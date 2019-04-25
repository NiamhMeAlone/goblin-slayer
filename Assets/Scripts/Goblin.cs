 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Monster
{
    public Limb head, leftFoot, rightFoot, leftHand, rightHand;

    public override void Start()
    {
        base.Start();
        limb1 = head;
        limb2 = leftFoot;
        limb3 = rightFoot;
        limb4 = leftHand;
        limb5 = rightHand;
    }
}
