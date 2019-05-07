using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Limb body;
    protected Limb limb1, limb2, limb3, limb4, limb5, limb6, limb7, limb8;
    protected GameObject weapon;
    protected GameObject player;
    public float timeCounter;
    public float animationLength;
    public Limb attackLimb;
    public float attackInterval;
    public float dismemForce;
    public float speed;
    public int health;
    public bool moving, attacking, attacked;

    public virtual void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("Weapon");
        if (weapon == null)
        {
            weapon = GameObject.FindGameObjectWithTag("Shield");
        }
        player = GameObject.FindGameObjectWithTag("Player");
        attacked = false;
    }

    public virtual void Update()
    {
        timeCounter += Time.deltaTime;
        if (attacking && timeCounter > attackInterval && !attacked)
        {
            Player.player.health--;
            attacked = true;
        }
        if (timeCounter > animationLength)
        {
            timeCounter -= animationLength;
            attacked = false;
        }
        RaycastHit monsterHit;
        if (Mathf.Abs(transform.position.z - player.transform.position.z) > 1.5f 
            && !(Physics.Raycast(transform.position, transform.forward, out monsterHit, 1f) 
            && monsterHit.collider.CompareTag("Monster") 
            && monsterHit.collider.GetComponent<Limb>().myMonster.health > 0))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, player.transform.position.z), speed * Time.deltaTime);
            moving = true;
            attacking = false;
        }
        else if (Mathf.Abs(transform.position.z - player.transform.position.z) > 1.5)
        {
            moving = true;
            attacking = false;
        }
        else
        {
            moving = false;
            attacking = true;
            Vector3 newForward = player.transform.position - transform.position;
            newForward.y = 0;
            transform.forward = newForward.normalized;
        }

        RaycastHit limb1Hit, limb2Hit, limb3Hit, limb4Hit, limb5Hit, limb6Hit, limb7Hit, limb8Hit;
        if (limb1 && (health <= 0 || Physics.Raycast(limb1.rayStart.position, limb1.transform.position - limb1.rayStart.position, out limb1Hit) && (limb1Hit.transform.gameObject.CompareTag("Weapon") || limb1Hit.transform.gameObject.CompareTag("Shield"))))
        {
            limb1.transform.SetParent(null);
            limb1.GetComponent<Rigidbody>().useGravity = true;
            limb1.GetComponent<Rigidbody>().AddForce((limb1.transform.position - weapon.transform.position).normalized * dismemForce);
            limb1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            limb1.attached = false;
            health -= 3;
            limb1 = null;
        }
        if (limb2 && (health <= 0 || Physics.Raycast(limb2.rayStart.position, limb2.transform.position - limb2.rayStart.position, out limb2Hit) && (limb2Hit.transform.gameObject.CompareTag("Weapon") || limb2Hit.transform.gameObject.CompareTag("Shield"))))
        {
            limb2.transform.SetParent(null);
            limb2.GetComponent<Rigidbody>().useGravity = true;
            limb2.GetComponent<Rigidbody>().AddForce((limb2.transform.position - weapon.transform.position).normalized * dismemForce);
            limb2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            limb2.attached = false;
            health -= 3;
            limb2 = null;
        }
        if (limb3 && (health <= 0 || Physics.Raycast(limb3.rayStart.position, limb3.transform.position - limb3.rayStart.position, out limb3Hit) && (limb3Hit.transform.gameObject.CompareTag("Weapon") || limb3Hit.transform.gameObject.CompareTag("Shield"))))
        {
            limb3.transform.SetParent(null);
            limb3.GetComponent<Rigidbody>().useGravity = true;
            limb3.GetComponent<Rigidbody>().AddForce((limb3.transform.position - weapon.transform.position).normalized * dismemForce);
            limb3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            limb3.GetComponent<Limb>().attached = false;
            health -= 2;
            limb3 = null;
        }
        if (limb4 && (health <= 0 || Physics.Raycast(limb4.rayStart.position, limb4.transform.position - limb4.rayStart.position, out limb4Hit) && (limb4Hit.transform.gameObject.CompareTag("Weapon") || limb4Hit.transform.gameObject.CompareTag("Shield"))))
        {
            limb4.transform.SetParent(null);
            limb4.GetComponent<Rigidbody>().useGravity = true;
            limb4.GetComponent<Rigidbody>().AddForce((limb4.transform.position - weapon.transform.position).normalized * dismemForce);
            limb4.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            limb4.GetComponent<Limb>().attached = false;
            health -= 2;
            limb4 = null;
        }
        if (limb5 && (health <= 0 || Physics.Raycast(limb5.rayStart.position, limb5.transform.position - limb5.rayStart.position, out limb5Hit) && (limb5Hit.transform.gameObject.CompareTag("Weapon") || limb5Hit.transform.gameObject.CompareTag("Shield"))))
        {
            limb5.transform.SetParent(null);
            limb5.GetComponent<Rigidbody>().useGravity = true;
            limb5.GetComponent<Rigidbody>().AddForce((limb5.transform.position - weapon.transform.position).normalized * dismemForce);
            limb5.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            limb5.GetComponent<Limb>().attached = false;
            health -= 5;
            limb5 = null;
        }
        if (limb6 && (health <= 0 || Physics.Raycast(limb6.rayStart.position, limb6.transform.position - limb6.rayStart.position, out limb6Hit) && (limb6Hit.transform.gameObject.CompareTag("Weapon") || limb6Hit.transform.gameObject.CompareTag("Shield"))))
        {
            limb6.transform.SetParent(null);
            limb6.GetComponent<Rigidbody>().useGravity = true;
            limb6.GetComponent<Rigidbody>().AddForce((limb6.transform.position - weapon.transform.position).normalized * dismemForce);
            limb6.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            limb6.GetComponent<Limb>().attached = false;
            health -= 5;
            limb6 = null;
        }
        if (limb7 && (health <= 0 || Physics.Raycast(limb7.rayStart.position, limb7.transform.position - limb7.rayStart.position, out limb7Hit) && (limb7Hit.transform.gameObject.CompareTag("Weapon") || limb7Hit.transform.gameObject.CompareTag("Shield"))))
        {
            limb7.transform.SetParent(null);
            limb7.GetComponent<Rigidbody>().useGravity = true;
            limb7.GetComponent<Rigidbody>().AddForce((limb7.transform.position - weapon.transform.position).normalized * dismemForce);
            limb7.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            limb7.GetComponent<Limb>().attached = false;
            health -= 5;
            limb7 = null;
        }
        if (limb8 && (health <= 0 || Physics.Raycast(limb8.rayStart.position, limb8.transform.position - limb8.rayStart.position, out limb8Hit) && (limb8Hit.transform.gameObject.CompareTag("Weapon") || limb8Hit.transform.gameObject.CompareTag("Shield"))))
        {
            limb8.transform.SetParent(null);
            limb8.GetComponent<Rigidbody>().useGravity = true;
            limb8.GetComponent<Rigidbody>().AddForce((limb8.transform.position - weapon.transform.position).normalized * dismemForce);
            limb8.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            limb8.GetComponent<Limb>().attached = false;
            health -= 5;
            limb8 = null;
        }
        if (body && health <= 0)
        {
            body.transform.SetParent(null);
            body.GetComponent<Rigidbody>().useGravity = true;
            body.GetComponent<Rigidbody>().AddForce((body.transform.position - weapon.transform.position).normalized * dismemForce);
            body.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            body.GetComponent<Limb>().attached = false;
            body = null;
        }
    }
}
