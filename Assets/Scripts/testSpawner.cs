using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSpawner : MonoBehaviour
{
    public GameObject obstacle;

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public float timeDecrease;
    public float minTime;

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            Instantiate(obstacle, transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
            if (startTimeBtwSpawns > minTime)
            {
                startTimeBtwSpawns -= timeDecrease;
            }
        }
        else {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
