using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners;
    public float timer = 0;
    [SerializeField] private float waveInterval = 5f;
    public int waveNumber = 1;
    public int totalEnemies = 0;

    private bool isWaveActive = false;

    private void Update()
    {
        if (!isWaveActive)
        {
            timer += Time.deltaTime;

            if (timer >= waveInterval)
            {
                StartWave();
                timer = 0;
            }
        }
        else if (totalEnemies <= 0)
        {
            EndWave();
        }
    }

    private void StartWave()
    {
        isWaveActive = true;
        waveNumber++;
        totalEnemies = 0;

        foreach (var spawner in enemySpawners)
        {
            spawner.isSpawning = true;
            spawner.spawnCount = waveNumber;
            spawner.ResetSpawner();
            spawner.StartSpawning();
            totalEnemies += spawner.spawnCount;
        }
    }

    private void EndWave()
    {
        isWaveActive = false;

        foreach (var spawner in enemySpawners)
        {
            spawner.StopSpawning();
        }
    }

    public void EnemyDefeated()
    {
        totalEnemies--;
    }
}
