using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float nextSpawnTime;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnDelay = 10;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            if (ShouldSpawn())
            {
                Spawn();
            }
        
    }

    private void Spawn()
    {
        nextSpawnTime = Time.time + spawnDelay;
        GameObject spawnedPrefab = Instantiate(enemyPrefab, transform.position, transform.rotation);
       
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
}
