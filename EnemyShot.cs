using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject eShotPrefab;
    public float speed;
    private int timeCount = 0;

    void Update()
    {
        timeCount += 1;

        if (timeCount % 140 == 0)
        {
            //生成
            GameObject enemyShot = Instantiate(eShotPrefab, transform.position, Quaternion.identity);
            Rigidbody2D enemyShotRb = enemyShot.GetComponent<Rigidbody2D>();

            //方向
            enemyShotRb.AddForce(transform.up * -speed);

            //削除
            Destroy(enemyShot, 20.0f);
        }
    }
}
