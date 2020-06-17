using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class BossHP : MonoBehaviour
{
    public Way way;
    public GameObject effectPrefab;
    public AudioClip destroySound;
    public int bossHP;
    //音
    public AudioClip deathSE;

    void Start()
    {
        way = GameObject.Find("Way").GetComponent<Way>();
    }

    void Update()
    {
        if(bossHP <= 150)
        {
            way.Start(); 
        }
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
