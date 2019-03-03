using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float Speed = 10f;
    public float LiveTime = 15f;

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * Speed);
        Destroy(gameObject, LiveTime);
    }
}
