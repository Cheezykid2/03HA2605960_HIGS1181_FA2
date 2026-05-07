using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int enemyCount;
    public Text enemyCounter;
    public GameObject winScreen;

    void StartGame()
    {
        UpdateUI();
    }

    public void OnEnemyDestroyed()
    {
        enemyCount--;
        UpdateUI();
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        if (enemyCount <= 0)
        {
            ShowWinScreen();
        }
    }

    void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }

    void UpdateUI()
    {
        enemyCounter.text = "Enemies Remaining: " + enemyCount;
    }
}
