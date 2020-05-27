using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject eShotPrefab;
    public float eShotSpeed;
    private int timeCount;

    void Start()
    {
        timeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += 1;

        if (timeCount % 100 == 0)
        {
            //生成
            GameObject enemyShot = Instantiate(eShotPrefab, transform.position, Quaternion.identity);
            Rigidbody2D enemyShotRb = enemyShot.GetComponent<Rigidbody2D>();

            //方向
            enemyShotRb.AddForce(transform.forward * eShotSpeed);

            //削除
            Destroy(enemyShot, 20.0f);
        }
    }
}
