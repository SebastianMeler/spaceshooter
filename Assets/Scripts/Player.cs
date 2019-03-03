using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;

    public GameObject BulletPrefab;

    void Update()
    {
        
        float translation = Input.GetAxis("Horizontal") * Speed;

        translation *= Time.deltaTime;

        transform.Translate(translation, 0, 0);
        
        if (transform.position.x < GameManager.LeftSize)
        {
            Vector3 calculatedPosition = new Vector3(GameManager.LeftSize, transform.position.y, transform.position.z);

            transform.SetPositionAndRotation(calculatedPosition, Quaternion.identity);
        }

        if (transform.position.x > GameManager.RightSize)
        {
            Vector3 calculatedPosition = new Vector3(GameManager.RightSize, transform.position.y, transform.position.z);

            transform.SetPositionAndRotation(calculatedPosition, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(BulletPrefab, transform.position, Quaternion.identity);
    }

    public void Scorepoint()
    {
        GameManager.Instance.Points += 1;
    }
}
