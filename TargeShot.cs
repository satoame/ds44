using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargeShot : MonoBehaviour
{
    public GameObject Tshot;
    public float speed;

    public void TargeShotChange()
    {
      
            //生成する
            GameObject TshotShot = Instantiate(Tshot, this.transform.position, Quaternion.identity);

            Rigidbody2D TshotShotShotRb = TshotShot.GetComponent<Rigidbody2D>();

            TshotShotShotRb.AddForce(transform.up * speed);

            //時間削除
            Destroy(TshotShot, 20.0f);
        
    }
}