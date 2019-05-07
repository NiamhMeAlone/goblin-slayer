using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;

    public int health = 60;

    // Start is called before the first frame update
    void Start()
    {
        player = this;
    }
}
