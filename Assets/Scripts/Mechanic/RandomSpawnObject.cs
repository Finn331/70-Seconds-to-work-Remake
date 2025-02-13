using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnObject : MonoBehaviour
{
    public Transform[] spawnPoints;

    void Start()
    {
        SpawnRandomObject();
    }

    void SpawnRandomObject()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("Spawn points atau objectSpawn belum diset!");
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        transform.position = spawnPoints[randomIndex].position;
    }
}