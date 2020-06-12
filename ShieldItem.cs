using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    public GameObject shieldPrefab;
    private GameObject player;
    private Vector2 pos;
    float time = 2.0f;

    void Start()
    {
        Destroy(gameObject, time);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == ("Player"))
        {
            //位置取得
            player = GameObject.FindWithTag("Player");
            pos = player.transform.position;

            // プレーヤー位置生成
            GameObject shield = Instantiate(shieldPrefab, new Vector3(pos.x, pos.y + 1f), Quaternion.identity);

            shield.transform.SetParent(player.transform);

            // シールドを５秒後消滅
            Destroy(shield, 5);

            //破壊する
            Destroy(gameObject);
        }
    }
}