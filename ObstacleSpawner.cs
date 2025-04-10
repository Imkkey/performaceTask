using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnRangeX = 8f;
    public float minSpawnDelay = 1f; // Минимальное время задержки
    public float maxSpawnDelay = 3f; // Максимальное время задержки

    private void Start()
    {
        StartCoroutine(SpawnObstaclesCoroutine());
    }

    private IEnumerator SpawnObstaclesCoroutine()
    {
        while (true)
        {
            float randomDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(randomDelay);

            SpawnObstacle();
        }
    }

    private GameObject SpawnObstacle()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector2 spawnPosition = new Vector2(randomX, transform.position.y);
        GameObject randomObstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        GameObject newObstacle = Instantiate(randomObstaclePrefab, spawnPosition, Quaternion.identity);
        return newObstacle;
    }
}
