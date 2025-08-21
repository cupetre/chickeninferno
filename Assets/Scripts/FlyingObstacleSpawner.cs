using UnityEngine;

public class FlyingObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform player;

    float minSpawnInterval;
    float maxSpawnInterval;
    float minY, maxY, minX, maxX;
    float spawnDistanceAhead;

    float spawnTimer;

    void Start()
    {
        ChickenMovement cm = player.GetComponent<ChickenMovement>();
        minY = cm.minHeight;
        maxY = cm.maxHeight;
        minX = cm.maxLeft;
        maxX = cm.maxRight;
        spawnDistanceAhead = 30f;

        string diff = PlayerPrefs.GetString("Difficulty", "Medium");

        switch (diff)
        {
            case "Easy":
                minSpawnInterval = 1.5f;
                maxSpawnInterval = 2.0f;
                break;
            case "Medium":
                minSpawnInterval = 1.0f;
                maxSpawnInterval = 1.5f;
                break;
            case "Hard":
                minSpawnInterval = 0.1f;
                maxSpawnInterval = 0.5f;
                break;
        }

        ResetTimer();
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnObstacle();
            ResetTimer();
        }
    }

    void SpawnObstacle()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY),
            player.position.z + spawnDistanceAhead
        );

        GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }

    void ResetTimer()
    {
        spawnTimer = Random.Range(minSpawnInterval, maxSpawnInterval);
    }
}