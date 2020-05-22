using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShot : MonoBehaviour
{
    //public Player player;
    public GameObject EshotPrefab;
    public float speed;
    private int timeCount = 0;
    void Update()
    {
        timeCount += 1;

        if (timeCount % 100 == 0)
        {
            //生成する
            GameObject enemyshot = Instantiate(EshotPrefab, transform.position, Quaternion.identity);

            Rigidbody2D enemyshotRb = enemyshot.GetComponent<Rigidbody2D>();

            //飛ばす方向
            enemyshotRb.AddForce(transform.forward * speed);

            Destroy(enemyshot, 5.0f);
        }
    }
}