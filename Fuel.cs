using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    //経験値
    public int f_exp;
    public float brake;
    public float obeyAccel = 0.01f;
    //方向
    private Vector3 direction;
    private float speed;
    private bool isObey;
    private float obeySpeed;

    // Update is called once per frame
    void Update()
    {
        //位置取得
        var playerPos = playerPos.instance.transform.localPosition;

        var distance = Vector3.Distance(playerPos, transform.localPosition);

        //近づいたとき
        if(distance < playerPos.instance.magnetDistance)
        {
            isObey = true;
        }

        if (isObey && Player.instance.gameObject.activeSelf)
        {
           
            var direction = playerPos - transform.localPosition;
            direction.Normalize();

            // 宝石をプレイヤーが存在する方向に移動する
            transform.localPosition += direction * obeySpeed;

            // 加速近づく
            speed += obeyAccel;

            return;
        }

        //散らばる速さ
        var velocity = direction * speed;

        transform.localPosition += velocity;

        speed *= brake;

        transform.localPosition = Scroll.ClampPosition(transform.localPosition);
    }

    //初期化
    public void Init(int score, float speedmin, float speedmax)
    {
        //方向ﾗﾝﾀﾞﾑ
        var angle = Random.Range(0, 360);

     
        var j = angle * Mathf.Deg2Rad;

        direction = new Vector3(Mathf.Cos(j), Mathf.Sin(j), 0);

        //速さﾗﾝﾀﾞﾑ
        speed = Mathf.Lerp(speedmin, speedmax, Random.value);

        //削除
        Destroy(gameObject, 4);
    }
}
