using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botshot : MonoBehaviour
{
    public GameObject eshotPrefab;
    public float speed;
    private int timeCount = 0;

    void Update()
    {
        timeCount += 1;

        //タイム
        if (timeCount % 30 == 0)
        {
            GameObject enemyShot = Instantiate(eshotPrefab, transform.position, Quaternion.identity);
            Rigidbody2D enemyShotRb = enemyShot.GetComponent<Rigidbody2D>();
            enemyShotRb.AddForce(transform.up * -speed);
            Destroy(enemyShot, 20.0f);
        }
        
        if (timeCount ==  500)
        {
            this.gameObject.AddComponent<Rota>().pos = new Vector3(0,0,90);
        }
    }
}
