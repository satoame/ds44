using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BossShot : MonoBehaviour
{
    public GameObject eShotPrefab;
    public float speed;
    private int timeCount = 0;

    void Update()
    {
        timeCount += 1;

        if (timeCount % 60 == 0)
        {
            //生成する
            GameObject enemyShot = Instantiate(eShotPrefab, transform.position, Quaternion.identity);

            Rigidbody2D enemyShotRb = enemyShot.GetComponent<Rigidbody2D>();

            enemyShotRb.AddForce(transform.up * speed);

            //削除
            Destroy(enemyShot, 5.0f);
        }

    }

}