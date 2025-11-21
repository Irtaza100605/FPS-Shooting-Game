using UnityEngine;

/// <summary>
/// Spawns enemies at designated spawn points
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int maxEnemies = 5;
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private bool autoSpawn = true;

    private int currentEnemyCount = 0;
    private float nextSpawnTime = 0f;

    void Start()
    {
        if (autoSpawn)
        {
            SpawnInitialEnemies();
        }
    }

    void Update()
    {
        if (autoSpawn && currentEnemyCount < maxEnemies && Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnInitialEnemies()
    {
        int enemiesToSpawn = Mathf.Min(maxEnemies, spawnPoints.Length);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnEnemyAtPoint(i);
        }
    }

    public void SpawnEnemy()
    {
        if (spawnPoints.Length == 0 || enemyPrefab == null)
        {
            Debug.LogWarning("Cannot spawn enemy: missing prefab or spawn points");
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        SpawnEnemyAtPoint(randomIndex);
    }

    private void SpawnEnemyAtPoint(int index)
    {
        if (index >= 0 && index < spawnPoints.Length)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPoints[index].position, spawnPoints[index].rotation);
            currentEnemyCount++;

            // Subscribe to enemy death to update count
            HealthSystem healthSystem = enemy.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.OnDeath.AddListener(() => OnEnemyDeath());
            }
        }
    }

    private void OnEnemyDeath()
    {
        currentEnemyCount--;
    }

    public int GetCurrentEnemyCount()
    {
        return currentEnemyCount;
    }
}
