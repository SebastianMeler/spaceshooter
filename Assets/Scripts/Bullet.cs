using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }
}
