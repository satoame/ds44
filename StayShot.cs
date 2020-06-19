using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayShot : MonoBehaviour
{
    public GameObject eshot;
    public float speed;

    public void StayChange()
    {

        //生成する
        GameObject EshotShot = Instantiate(eshot, this.transform.position, Quaternion.identity);

        Rigidbody2D EshotShotRb = EshotShot.GetComponent<Rigidbody2D>();

        EshotShotRb.AddForce(transform.forward * speed);

        //時間削除
        Destroy(EshotShot, 20.0f);

    }
}