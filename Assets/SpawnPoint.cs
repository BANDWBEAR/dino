using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public float difficulty;
    public float timeBetweenSpawns;
    float timeLeftToNextSpawn;

    public GameObject[] patterns;

    private void Start()
    {
        timeLeftToNextSpawn = timeBetweenSpawns;
    }

    private void Update()
    {
        if (timeLeftToNextSpawn <= 0) {
            
            int randomNumber = Random.Range(0, patterns.Length);
            GameObject randomPattern = patterns[randomNumber];
            Instantiate(randomPattern, transform.position, Quaternion.identity);

            timeLeftToNextSpawn = timeBetweenSpawns;
        } else {
            timeLeftToNextSpawn -= Time.deltaTime;
        }

    }




}
