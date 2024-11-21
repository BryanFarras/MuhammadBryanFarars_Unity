using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public Enemy spawnedEnemy;

    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3;
    public int totalKill = 0;
    private int totalKillWave = 0;

    [SerializeField] private float spawnInterval = 3f;

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0;
    public int defaultSpawnCount = 1;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;

    public CombatManager combatManager;
    public bool isSpawning = false;

    private void Start()
    {
        if (isSpawning)
        {
            StartSpawning();
        }
    }

    private void StartSpawning()
    {
        StartCoroutine(SpawnEnemies());
    }

    private System.Collections.IEnumerator SpawnEnemies()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(spawnInterval);
            for (int i = 0; i < spawnCount; i++)
            {
                SpawnEnemy();
            }
            CheckSpawnIncreaseCondition();
        }
    }

    private void SpawnEnemy()
    {
        if (spawnedEnemy == null) return;
        Instantiate(spawnedEnemy, transform.position, Quaternion.identity);
        spawnCount++;
    }

    private void CheckSpawnIncreaseCondition()
    {
        if (totalKillWave >= minimumKillsToIncreaseSpawnCount)
        {
            totalKillWave = 0;
            spawnCountMultiplier += multiplierIncreaseCount;
            spawnCount = defaultSpawnCount * spawnCountMultiplier;
        }
    }

    public void EnemyKilled()
    {
        totalKill++;
        totalKillWave++;
    }

    public void StopSpawning()
    {
        isSpawning = false;
        StopAllCoroutines();
    }

    public void ResetSpawner()
    {
        spawnCount = defaultSpawnCount;
        spawnCountMultiplier = 1;
        totalKill = 0;
        totalKillWave = 0;
        isSpawning = false;
    }
}\
