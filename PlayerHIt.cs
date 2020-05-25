﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHIt : MonoBehaviour
{
    //public Player player;
    public int damage;
    //HP
    public int hp;
    //HP最大
    public int hpMax;
    public AudioClip damageSE;
    public GameObject bomb;
    public GameObject bomb1;

    void Awak()
    {
        hp = hpMax;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //プレイヤー当たり判定
        if ((collider.gameObject.tag == "Enemy")||(collider.gameObject.tag == "EnemyS"))
        {
            var player = collider.GetComponent<Player>();
            Damage(damage);
        }
    }

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
    }
}