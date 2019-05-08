using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    public static WeaponSelect wheel;

    public Vector3 rotatingTo;
    public bool rotating;
    public bool removing;
    public Transform weaponParent;
    public GameObject goblinSpawner;
    public Transform Pedestal;
    public Sword[] weapons;
    public int weaponSelected = 0;

    private void Awake()
    {
        wheel = this;
    }

    void Start()
    {
        rotatingTo = Vector3.zero;
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].transform.localPosition = PointOnCircle(-1.5f, -i * 2f * Mathf.PI / 3f) + Vector3.up * weapons[i].transform.localPosition.y;
        }
    }

    private void Update()
    {
        if (!removing) {
            if (!rotating && Input.GetKeyDown(KeyCode.Space))
            {
                rotatingTo = rotatingTo + Vector3.up * 120;
                rotating = true;
            }
            if (rotatingTo.y > 360)
            {
                rotatingTo = rotatingTo - Vector3.up * 360;
            }
            if (rotating)
            {
                weaponParent.rotation = Quaternion.Euler(Vector3.MoveTowards(weaponParent.rotation.eulerAngles, rotatingTo, Time.deltaTime * 100));
                if (Vector3.Distance(weaponParent.rotation.eulerAngles, rotatingTo) < 1)
                {
                    weaponParent.rotation = Quaternion.Euler(rotatingTo);
                    rotating = false;
                    weapons[weaponSelected].selected = false;
                    weaponSelected++;
                    if (weaponSelected > 2)
                    {
                        weaponSelected -= 3;
                    }
                    weapons[weaponSelected].selected = true;
                }
            }
            if (!removing && Input.GetKeyDown(KeyCode.R))
            {
                removing = true;
                Instantiate(goblinSpawner);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.down * 10, Time.deltaTime * 3);
            if (transform.position.y < -8)
            {
                Destroy(gameObject);
            }
        }
    }

    public static Vector3 PointOnCircle(float radius, float angle)
    {
        return new Vector3(radius * Mathf.Sin(angle), 0, radius * Mathf.Cos(angle));
    }
}
