using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class TimeShot : MonoBehaviour
{
    public float speed;
    public float nextSpeed;

    private Rigidbody2D rb;
    private GameObject TShot;

    private float timeCount = 0;
    public float stopTime; 

    private float stopTimeCount = 0;
    private float nextStartTime = 2; 

    private bool stopflage;

    void Start()
    {
        TShot = GameObject.Find("Player");
        stopflage = false;
    }

    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);

        timeCount += Time.deltaTime;

        if(timeCount >= stopTime && stopflage == false)
        {
           
            stopTimeCount += Time.deltaTime;
            rb.velocity = Vector3.zero;

            //プレイヤー方向
            if (stopTimeCount >= nextStartTime)
            {
                //this.gameObject.transform.LookAt(TShot.transform.position);
                //Debug.Log("");
                rb.AddForce(transform.up * nextSpeed);
                stopflage = true;
            }
        }
    }
}
