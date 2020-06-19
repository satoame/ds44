using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour
{
    public int damage;
    public int add;
    //HP
   public int hp;
    //HP最大
    public int hpMax = 100;
    public AudioClip damageSE;
    public GameObject bomb;
    public GameObject bomb1;
   
    void Start()
    {
        hp = hpMax;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //プレイヤー当たり判定
        if ((collider.gameObject.tag == "Enemy") || (collider.gameObject.tag == "EnemyS") || (collider.gameObject.tag == "Eshot"))
        {
            var player = collider.GetComponent<Player>();
            Damage(damage);
        }
        if (collider.gameObject.tag == "HPItem")
        {
            AddHP(add);
        }
    }

    //ダメージ
    public void Damage(int damage)
    {
        // ダメージを受けた時の SE を再生する
        var audioSource = FindObjectOfType<AudioSource>();
        audioSource.PlayOneShot(damageSE);
        hp -= damage;
        Instantiate(bomb1, this.transform.position, Quaternion.identity);
        if (0 < hp) return;
        //爆発
        Instantiate(bomb, this.transform.position, Quaternion.identity);
        gameObject.SetActive(false);

        SceneManager.LoadScene("GameOver");
    }


    //回復
    public void AddHP(int add)
    {
        hp += add;

        if (hp > hpMax)
        {
            hp = hpMax;
        }
    }
}