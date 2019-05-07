using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpawner : MonoBehaviour
{
    public float goblinTimer;
    public float maxTime, minTime, nextSpawn;

    public float xOffset = 1.85f;

    public GameObject goblinPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnGoblin();
        goblinTimer = 0;
        nextSpawn = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        goblinTimer += Time.deltaTime;
        if (goblinTimer >= nextSpawn)
        {
            SpawnGoblin();
            goblinTimer = 0;
            nextSpawn = Random.Range(minTime, maxTime);
        }
    }

    void SpawnGoblin()
    {
        int lane = Random.Range(-1,2);
        Instantiate(goblinPrefab, transform.position + (Vector3.right * xOffset * lane), Quaternion.Euler(0,180,0));
    }
}
