using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogre : Monster
{
    public Limb leftHead, rightHead, leftFoot, rightFoot, leftHand, rightHand;

    public override void Start()
    {
        base.Start();
        limb1 = leftHead;
        limb2 = rightHead;
        limb3 = leftFoot;
        limb4 = rightFoot;
        limb5 = leftHand;
        limb6 = rightHand;
    }
}
