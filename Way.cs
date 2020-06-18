using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way : MonoBehaviour
{
    public GameObject Wshot;
    public float speed;
    public int number;

     public void WayChange()
     {
        for (int i = 0; i < number; i++)
         {
             //生成する
             GameObject WshotShot = Instantiate(Wshot, this.transform.position, Quaternion.Euler(0, -30 + (15 * i), 0));

             Rigidbody2D WshotShotRb = WshotShot.GetComponent<Rigidbody2D>();

             WshotShotRb.AddForce(transform.up * speed);

             //時間削除
             Destroy(WshotShot, 5.0f);
         }
    }
}
