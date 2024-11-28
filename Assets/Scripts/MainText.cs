using UnityEngine;
using UnityEngine.UI;

public class MainGameUI : MonoBehaviour
{
    public Text healthText;     // Assign via Inspector
    public Text pointsText;     // Assign via Inspector
    public Text waveText;       // Assign via Inspector
    public Text enemiesText;    // Assign via Inspector

    private int health = 100;
    private int points = 0;
    private int wave = 1;
    private int enemies = 5;

    void Start()
    {
        UpdateUI();
    }

    public void UpdateHealth(int amount)
    {
        health += amount;
        UpdateUI();
    }

    public void AddPoints(int enemyLevel, int killCount)
    {
        points += enemyLevel * killCount;
        UpdateUI();
    }

    public void NextWave(int newEnemyCount)
    {
        wave++;
        enemies = newEnemyCount;
        UpdateUI();
    }

    void UpdateUI()
    {
        healthText.text = $"Health: {health}";
        pointsText.text = $"Points: {points}";
        waveText.text = $"Wave: {wave}";
        enemiesText.text = $"Enemies: {enemies}";
    }
}
