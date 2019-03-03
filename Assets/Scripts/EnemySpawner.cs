using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float SpawnTimer = 2f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, SpawnTimer);
    }

    void SpawnEnemy()
    {
        float enemyXPosition = Random.Range(GameManager.LeftSize, GameManager.RightSize);

        Vector3 calculatedPosition = new Vector3(enemyXPosition, transform.position.y, transform.position.z);

        Instantiate(EnemyPrefab, calculatedPosition, Quaternion.identity);
    }
}
