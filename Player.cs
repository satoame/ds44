using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    // 弾のプレハブ
    public Shot shotPrefab;
    // 弾の移動の速さ
    public float shotSpeed;
    // 複数の弾を発射する時の角度
    public float shotAngleRange;
    // 弾の発射タイミングを管理するタイマー
    public float shotTimer;
    // 弾の発射数
    public int shotCount;
    // 弾の発射間隔（秒）
    public float shotInterval;
    //HP最大
    public int hpMax;
    //HP
    public int hp;
    //管理
    public static Player instance;
    public GameObject bomb;
    public GameObject bomb1;
    // 宝石を引きつける距離
    public float magnetDistance;
    public AudioClip damageSE;

    void Awake()
    {
        hp = hpMax;
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {

        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        var velocity = new Vector3(h, v) * speed;
        transform.localPosition += velocity;

        // プレイヤーが画面外に出ないように位置を制限する
        transform.localPosition = Scroll.ClampPosition(transform.localPosition);

        // プレイヤーのスクリーン座標を計算する
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // プレイヤーから見たマウスカーソルの方向を計算する
       var direction = Input.mousePosition - screenPos;

        // マウスカーソルが存在する方向の角度を取得する
        var angle = Scroll.GetAngle(Vector3.zero, direction);

        // プレイヤーがマウスカーソルの方向を見るようにする
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;

        //タイマー管理
        shotTimer += Time.deltaTime;

        //撃つ時間じゃないなら終わる
        if (shotTimer < shotInterval) return;

        //リセット
        shotTimer = 0;

        //撃つ
        P_Shot(angle, shotAngleRange, shotSpeed, shotCount);
    }

    public void P_Shot(float angleBase, float angleRange, float speed, int count)
    {
        var pos = transform.localPosition;
        var rot = transform.localRotation;

        //撃つ
        if (1 < count)
        {
            //ループする
            for (int i = 0; i < count; ++i)
            {
                //角度
                var angle = angleBase + angleRange * (i / (count - 1) - 0.5f);
                //生成
                var shot = Instantiate(shotPrefab, pos, rot);
                //方向、速さ
                shot.Init(angle, speed);
            }
        }
        // 弾を 1 つだけ
        else if (count == 1)
        {
            //生成する
            var shot = Instantiate(shotPrefab, pos, rot);

            shot.Init(angleBase, speed);
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
