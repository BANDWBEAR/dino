using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float TimeBetweenWaves = 2f;
    public float AltitudeModifier = 0.1f;
    public GameObject[] GroundEnemies;
    public GameObject[] FlyingEnemies;


    private float Countdown;


    private void Update()
    {
        if (Countdown <= 0)
        {
            SpawnWave();
            Countdown = TimeBetweenWaves;
        }
        else
        {
            Countdown -= Time.deltaTime;
        }
    }


    private void SpawnWave()
    {
        int pattern = UnityEngine.Random.Range(1, 4);
        do
        {
            GetRandomObjectFor(pattern);
            pattern -= 1;
        } while (pattern > 0);


    }

    private void GetRandomObjectFor(int pattern)
    {
        if (pattern == 1)
        {
            int randomObject = UnityEngine.Random.Range(0, GroundEnemies.Length);
            Instantiate(GroundEnemies[randomObject], transform.position, Quaternion.identity);

        }
        else
        {
            if (UnityEngine.Random.value > 0.5f)
            {
                Vector3 NewTransform = new Vector3(transform.position.x, AltitudeModifier * (pattern * pattern), transform.position.z);
                int randomObject = UnityEngine.Random.Range(0, FlyingEnemies.Length);
                Instantiate(FlyingEnemies[randomObject], NewTransform, Quaternion.identity);
            }
        }

    }
}
