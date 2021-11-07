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
        GameObject spawnedPrefab = Instantiate(enemyPrefab, generateSpawnPosition(), transform.rotation);
       
    }

    private Vector3 generateSpawnPosition()
    {
        List<Transform> spawnTransforms = new List<Transform>(this.GetComponentsInChildren<Transform>()); //get transforms of all spawnPositions
        spawnTransforms.RemoveAt(0);//remove the parent's (this EnemySpawner's) transform component from the list
        Transform pickedSpawnTransform = spawnTransforms[Random.Range(0, spawnTransforms.Count-1)];
        return pickedSpawnTransform.position;
    }
    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
}
