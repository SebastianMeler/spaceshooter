using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 1f;

    public GameObject BulletEnemy;
    public float SpawnTimer = 5f;

    void Start()
    {
        InvokeRepeating("SpawnBullet", 0f, SpawnTimer);
    }

    void SpawnBullet()
    {
        Instantiate(BulletEnemy, transform.position, Quaternion.identity);
    }

    void Update()
    {
           transform.Translate(Vector3.back * Time.deltaTime * Speed);    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            GameManager.Instance.ScorePoints();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    
}
