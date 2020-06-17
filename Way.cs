using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way : MonoBehaviour
{
    public GameObject eShotPrefab;
    public float speed;
    public int number;

    public void Start()
    {
        for (int i = 0; i < number; i++)
        {
            //生成する
            GameObject enemyShot = Instantiate(eShotPrefab, transform.position, Quaternion.Euler(0, -30 + (15*i),0));

            Rigidbody2D enemyShotRb = enemyShot.GetComponent<Rigidbody2D>();

            enemyShotRb.AddForce(transform.up * -speed);

            //削除
            Destroy(enemyShot, 5.0f);
        }
    }
}
