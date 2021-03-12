using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public int spawnDelay, maxActiveEnemies;
    public GameObject enemy;
    public static int currentActiveEnemies;
    public GameObject[] spawnLocations;

    // Start is called before the first frame update
    void Start()
    {
        //Repeat function, starting in x seconds, every spawnDelay seconds.
        InvokeRepeating("SpawnEnemy", 0f, spawnDelay);
    }

    private void SpawnEnemy() 
    {
        if (currentActiveEnemies >= maxActiveEnemies)
        {
            return;
        }
        else if (currentActiveEnemies < maxActiveEnemies)
        {
            Instantiate(enemy, spawnLocations[Random.Range(0,spawnLocations.Length)].transform.position, Quaternion.identity);
            currentActiveEnemies++;
            return;
        }
    }
}
