using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [Header("Prefabs")]
    [SerializeField] GameObject enemyPrefab = default;
    [SerializeField] GameObject pathPrefab = default;

    [Header("Spawn")]
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;

    [Header("Number of Enemies")]
    [SerializeField] int numberOfEnemies = 5;

    [Header("Speed")]
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform) 
        {
            waveWaypoints.Add(child); 
        }
        return waveWaypoints;
    }
    public float GetTimeBetweenSpawn() { return timeBetweenSpawns; }
    public float GetSpawnRandomFactor() { return spawnRandomFactor; }
    public int GetNumberOfEnemies() { return numberOfEnemies; }
    public float GetMoveSpeed() { return moveSpeed; }
}
