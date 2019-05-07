using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{
    public AnimationCurve xCoord, yCoord, zCoord;
    public AnimationCurve xCoordAttack, yCoordAttack, zCoordAttack;
    public AnimationCurve attackingYRot;
    public float timeCounter;
    public bool attached;
    public float despawnTimer = 15;
    public Monster myMonster;
    public Transform rayStart;

    // Start is called before the first frame update
    void Start()
    {
        timeCounter = 0;
        attached = true;
        myMonster = GetComponentInParent<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attached && myMonster.moving)
        {
            transform.localPosition = new Vector3(xCoord.Evaluate(myMonster.timeCounter), yCoord.Evaluate(myMonster.timeCounter), zCoord.Evaluate(myMonster.timeCounter));
        }
        else if (attached && myMonster.attacking)
        {
            transform.localPosition = new Vector3(xCoordAttack.Evaluate(myMonster.timeCounter), yCoordAttack.Evaluate(myMonster.timeCounter), zCoordAttack.Evaluate(myMonster.timeCounter));
            transform.localRotation = Quaternion.Euler(0, attackingYRot.Evaluate(myMonster.timeCounter), 0);
        }
        else
        {
            despawnTimer -= Time.deltaTime;
            if (despawnTimer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
