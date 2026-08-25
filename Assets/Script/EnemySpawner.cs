using UnityEngine;
using System.Collections;
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform boardTransform;

 public float spawnInterval = 20f;
    public float spawnHeight = 10f;
    public float spawnRangeXZ = 12f;
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }
    IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        float randomX = Random.Range(-spawnRangeXZ,
       spawnRangeXZ);
        float randomZ = Random.Range(-spawnRangeXZ,
       spawnRangeXZ);
        
    Vector3 spawnPos = boardTransform.position + new
Vector3(randomX, spawnHeight, randomZ);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}