using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BossHp : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip destroySound;
    public int bossHP;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("shot"))
        {
            //エフェクト
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

            //HP
            bossHP -= 10;

            //削除弾
            Destroy(collider.gameObject);

            //
            if(bossHP == 0)
            {
                Destroy(gameObject);

                //効果音
                AudioSource.PlayClipAtPoint(destroySound, transform.position);
            }
        }
    }
}
