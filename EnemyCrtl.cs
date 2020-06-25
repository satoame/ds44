using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrtl : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float speed;

    private void Start()
    {
        StartCoroutine(GeneEnemy());
    }

    IEnumerator GeneEnemy()
    {
        for (int j = 0; j < 10; j++)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject enemey = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                Rigidbody2D enemyRb = enemey.GetComponent<Rigidbody2D>();
                enemyRb.AddForce(transform.up * -speed);
                Destroy(enemey, 10f);

                // 0.2秒
                yield return new WaitForSeconds(5f);
            }

            // 3秒
            yield return new WaitForSeconds(3f);
        }
    }
}


