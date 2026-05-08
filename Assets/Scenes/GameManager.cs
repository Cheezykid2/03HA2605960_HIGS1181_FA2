using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public int enemyCount;
    public Text enemyCounter;
    public TMPro.TextMeshProUGUI enemyCounterTMP;
    public GameObject winPanel; // UI panel for win screen
    public GameObject winScreen;

    void Start()
    {
        // Ensure UI is in sync at start
        UpdateUI();
        if (winScreen != null)
            winScreen.SetActive(false);
    }

    public void OnEnemyDestroyed()
    {
        enemyCount = Mathf.Max(0, enemyCount - 1);
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
        if (winScreen != null)
            winScreen.SetActive(true);
    }

    void UpdateUI()
    {
        if (enemyCounter != null)
            enemyCounter.text = "Enemies Remaining: " + enemyCount;
    }
    void update() => UpdateUI();


}
