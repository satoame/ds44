using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    //public Player player;
    public Vector2 s_respawnPosition;
    public Vector2 o_respawnPosition;
    //速度
    public float speed;
    //HP
    public int hpMax;
    public int f_exp;
    //ダメージ
    public int damage;
    private int e_hp;
    private Vector3 direction;
    //爆発
    public Explosion explosionPrefab;
    public bool isFollow;
    //アイテム
    public Fuel[] f_fuelPrefabs;
    public float fuelSpeedmin;
    public float fuelSpeedmax;
    //音
    public AudioClip deathSE;

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
   
    private void OnTriggerEnter2D(Collider2D collider)
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

            var exp = f_exp;

        //アイテム
        while ( 0 < exp)
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
