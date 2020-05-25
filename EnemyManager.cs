using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy[] enemyPrefabs;

    // 出現間隔（秒）
    public float intervalFrom;
    public float intervalTo;

    // 経過時間最大
    public float TimeMax;
    // 経過時間
    public float elapsedTime;
    // 出現タイミング管理
    private float timer; 

    void Update()
    {
        // 更新する
        elapsedTime += Time.deltaTime;

        // 出現管理する
        m_timer += Time.deltaTime;

        var t = elapsedTime / TimeMax;
        var interval = Mathf.Lerp(intervalFrom, intervalTo, t);

        // 敵が出現するタイミングではない場合
        if (timer < interval) return;

        //タイマーをリセットする
        timer = 0;

        // 出現敵ランダム
        var enemyIndex = Random.Range(0, enemyPrefabs.Length);

        var enemyPrefab = enemyPrefabs[enemyIndex];

        var enemy = Instantiate(enemyPrefab);

        var respawnType = (E_TYPE)Random.Range(
            0, (int)E_TYPE.NUMBER);

        // 初期化
        enemy.Init(respawnType);
    }
}
