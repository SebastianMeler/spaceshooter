using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Speed;

    public GameObject BulletPrefab;
    public Text PointsText;
    public Text LivesText;

    private void Start()
    {
        PointsText.text = "Points: 0";
        GameManager.Instance.Points = 0;
        LivesText.text = "Lives: " + GameManager.Instance.Lives;
    }

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

        PointsText.text = "Points: " + GameManager.Instance.Points;
        LivesText.text = "Lives: " + GameManager.Instance.Lives;
    }

    void Shoot()
    {
        Instantiate(BulletPrefab, transform.position, Quaternion.identity);
    }

    public void Scorepoint()
    {
        GameManager.Instance.Points += 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "BulletEnemy")
        {
            GameManager.Instance.Lives--;
            Destroy(other.gameObject);
            if (GameManager.Instance.Lives <= 0)
            {
                Destroy(gameObject);
                GameManager.Instance.Lives = 5;
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
