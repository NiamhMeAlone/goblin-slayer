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
        timeCounter += Time.deltaTime;
        if (timeCounter > 1.5f)
        {
            timeCounter -= 1.5f;
        }
        if (attached && myMonster.moving)
        {
            transform.localPosition = new Vector3(xCoord.Evaluate(timeCounter), yCoord.Evaluate(timeCounter), zCoord.Evaluate(timeCounter));
        }
        else if (attached && myMonster.attacking)
        {
            transform.localPosition = new Vector3(xCoordAttack.Evaluate(timeCounter), yCoordAttack.Evaluate(timeCounter), zCoordAttack.Evaluate(timeCounter));
            transform.localRotation = Quaternion.Euler(0, attackingYRot.Evaluate(timeCounter), 0);
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
