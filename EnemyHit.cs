using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHit : MonoBehaviour
{
    //HP
    public int hpMax;
    public int f_exp;
    //ダメージ
    public int damage;
    private int e_hp;
    //爆発
    public Explosion explosionPrefab;
    //アイテム
    public Fuel[] f_fuelPrefabs;
    public float fuelSpeedmin;
    public float fuelSpeedmax;
    //音
    public AudioClip deathSE;
    //カウント
    public int count;
    //スコア
    public int scoreV;
    private ScoreManager sm;

    void Start()
    {
        e_hp = hpMax;
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // 弾当たり判定
        if (collider.gameObject.tag == "shot")
        {
            Instantiate(explosionPrefab, collider.transform.localPosition, Quaternion.identity);

            Destroy(collider.gameObject);
            e_hp--;
            if (0 < e_hp) return;

            // 敵を倒した時の SE を再生する
            var audioSource = FindObjectOfType<AudioSource>();
            audioSource.PlayOneShot(deathSE);
            Destroy(gameObject);
            count++;
            var exp = f_exp;
            sm.Scorel(scoreV);
            //アイテム
            while (0 < exp)
            {
                var fuelPrefabs = f_fuelPrefabs.Where(c => c.f_exp <= exp).ToArray();

                var f_fuelPrefab = fuelPrefabs[Random.Range(0, fuelPrefabs.Length)];

                var gem = Instantiate(f_fuelPrefab, transform.localPosition, Quaternion.identity);

                gem.Init(f_exp, fuelSpeedmin, fuelSpeedmax);

                exp -= gem.f_exp;
            }

        }
    }
}
