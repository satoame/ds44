using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class BossHP : MonoBehaviour
{
    public TargeShot targe;
    public StayShot stay;
    public GameObject effectPrefab;
    public AudioClip destroySound;
    public int bossHP;
    //音
    public AudioClip deathSE;

    void Start()
    {
        targe = GameObject.Find("Targe").GetComponent<TargeShot>();
        stay = GameObject.Find("Stay").GetComponent<StayShot>();
    }

    void Damege()
    {
        int damege = 10;

        bossHP -= damege;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "shot")
        {
            //エフェクト
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

            //HP
            Damege();

            //以下で変更
            if (bossHP <= 150)
            {
                targe.TargeShotChange();
                stay.StayChange();
            }
            
            //削除弾
            Destroy(collider.gameObject);

            if (bossHP == 0)
            {
                // 敵SE
                var audioSource = FindObjectOfType<AudioSource>();
                audioSource.PlayOneShot(deathSE);
                Destroy(gameObject);
            }
        }
    }
}
