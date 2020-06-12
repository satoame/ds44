using System.Collections;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public GameObject effectPrefab;
    public GameObject[] items;
    public AudioClip sound;
    public int enemyHP;
    //スコア
    public int scoreV;
    private ScoreManager sm;
    //爆発
    public Explosion explosionPrefab;
    //ダメージ
    public int damage;
    //音
    public AudioClip deathSE;
  
    void Start()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        // 弾当たり判定
        if (collider.gameObject.tag == "shot")
        {
            Instantiate(explosionPrefab, collider.transform.localPosition, Quaternion.identity);

            Destroy(collider.gameObject);
            enemyHP--;

            if (enemyHP == 0)
            {
                // 敵SE
                var audioSource = FindObjectOfType<AudioSource>();
                audioSource.PlayOneShot(deathSE);
                Destroy(gameObject);
                sm.Scorel(scoreV);
                //アイテム
                if (items.Length != 0)
                {
                    int itemNumber = Random.Range(0, items.Length);
                    //出現確率
                    if (Random.Range(0, 4) == 0)
                    {
                        Instantiate(items[itemNumber], transform.position, Quaternion.identity);
                    }
                }
            }
            
        }
    }

}
