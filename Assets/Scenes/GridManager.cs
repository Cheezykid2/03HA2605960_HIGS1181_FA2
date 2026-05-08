using UnityEngine;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public GameObject enemyPrefab;   // Drag your Enemy prefab here
    public int gridSize = 12;        // 12x12 grid
    public int enemyCount = 5;       // Minimum 5 enemies
    private List<Vector2> usedPositions = new List<Vector2>();

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 pos = GetRandomGridPosition();
            Instantiate(enemyPrefab, pos, Quaternion.identity);
            usedPositions.Add(pos);
        }
    }

    Vector2 GetRandomGridPosition()
    {
        Vector2 pos;
        do
        {
            pos = new Vector2(Random.Range(0, gridSize), Random.Range(0, gridSize));
        } while (usedPositions.Contains(pos)); // Prevent overlap
        return pos;
    }
}
