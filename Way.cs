using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Way : MonoBehaviour
{
    public BossHP boss;
    public GameObject eShotPrefab;
    public float speed;
    public bool eshotflag = false;
    private int timeCount = 0;

    void Update()
    {
        eshotflag = true;
        timeCount += 1;
        if (boss.bossHP <= 100)
        {
            if (timeCount % 60 == 0)
            {
                //生成する
                GameObject enemyShot = Instantiate(eShotPrefab, transform.position, Quaternion.Euler(0, 0, 180));

                Rigidbody2D enemyShotRb = enemyShot.GetComponent<Rigidbody2D>();

                enemyShotRb.AddForce(transform.up * speed);

                //削除
                Destroy(enemyShot, 5.0f);
            }
        }
    }
}
