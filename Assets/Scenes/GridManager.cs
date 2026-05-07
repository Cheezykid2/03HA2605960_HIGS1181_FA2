using UnityEngine;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int gridSize = 12;
    public int enemyCount = 5;
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
        } while (usedPositions.Contains(pos));
        return pos;
    }
}
