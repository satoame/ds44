﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_TYPE
{
    UP,
    DOWN,
    RIGHT,
    LEFT,
    NUMBER,
}


public class Enemy : MonoBehaviour
{
    public Vector2 s_respawnPosition;
    public Vector2 o_respawnPosition;
    public float speed;
    public int hpMax;
    public int f_exp;
    public int damage;
    private int e_hp;
    private Vector3 direction;
    public Explosion explosionPrefab;
    public bool isFollow;
    public Fuel[] f_fuelPrefabs;
    public float fuelSpeedmin;
    public float fuelSpeedmax;
    // Start is called before the first frame update
    void Start()
    {
        e_hp = hpMax;
    }

    // Update is called once per frame
    void Update()
    {
         if(isFollow)
         {
             var angle = Scroll.GetAngle(transform.localPosition, Player.instance.transform.localPosition);
             var direction = Scroll.GetDirection(angle);

             transform.localPosition += direction * speed;

             var angles = transform.localEulerAngles;
             angles.z = angle - 90;
             transform.localEulerAngles = angles;
             return;
         }
        transform.localPosition += direction * speed;
    }

    public void Init(E_TYPE e_type)
    {
        var pos = Vector3.zero;

        switch (e_type)
        {
            //上
            case E_TYPE.UP:
                pos.x = Random.Range(
                    -s_respawnPosition.x, s_respawnPosition.x);
                pos.y = o_respawnPosition.y;
                direction = Vector2.down;
                break;

            // 下
            case E_TYPE.DOWN:
                pos.x = Random.Range(
                    -s_respawnPosition.x, s_respawnPosition.x);
                pos.y = -o_respawnPosition.y;
                direction = Vector2.up;
                break;

            // 右
            case E_TYPE.RIGHT:
                pos.x = o_respawnPosition.x;
                pos.y = Random.Range(
                    -s_respawnPosition.y, s_respawnPosition.y);
                direction = Vector2.left;
                break;

            // 左
            case E_TYPE.LEFT:
                pos.x = -o_respawnPosition.x;
                pos.y = Random.Range(
                    -s_respawnPosition.y, s_respawnPosition.y);
                direction = Vector2.right;
                break;
        }
        transform.localPosition = pos;
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤー当たり判定
        if(collision.name.Contains("Player"))
        {
            var player = collision.GetComponent<Player>();
            player.Damage(damage);
            return;
        }

        // 弾当たり判定
        if (collision.name.Contains("shot"))
        {
            Instantiate(explosionPrefab, collision.transform.localPosition, Quaternion.identity);

            Destroy(collision.gameObject);
            e_hp--;

            if (0 < e_hp) return;

            Destroy(gameObject);
        }
    }
}