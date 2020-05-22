using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy[] enemyPrefabs;
    //間隔
    public float interval;
    //出現
    public float intervalFrom;
    public float intervalTo;
    //最大
    public float maxTime;
    //経過
    public float progressTime;
    private float timer;

    void Update()
    {
        // タイマーを更新する
        progressTime += Time.deltaTime;

        // タイマーをリセットする
        timer += Time.deltaTime;

        var t = progressTime / maxTime;
       // var interval = Mathf.Lerp

        // 出現する敵をランダムに決定する
        var enemyIndex = Random.Range(0, enemyPrefabs.Length);

        var enemyPrefab = enemyPrefabs[enemyIndex];

        var enemy = Instantiate(enemyPrefab);

        var respawnType = (E_TYPE)Random.Range(
            0, (int)E_TYPE.NUMBER);

        // 敵を初期化する
        enemy.Init(respawnType);
    }
}
