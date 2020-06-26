using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class TimeShot : MonoBehaviour
{
    public float speed;
    public float nextSpeed;

    private Rigidbody2D rb;
    private GameObject target;

    private float timeCount = 0;
    public float stopTime; 

    private float stopTimeCount = 0;
    private float nextStartTime = 2; 

    private bool stopflage = false;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);
        target = GameObject.Find("Player");
    }

    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount >= stopTime && stopflage == false)
        {
            stopTimeCount += Time.deltaTime;
            rb.velocity = Vector3.zero;
            Debug.Log("b");
            //プレイヤー方向
            if(stopTimeCount >= nextStartTime)
            {
                Debug.Log("a");
                this.gameObject.transform.LookAt(target.transform.position); 
                rb.AddForce(transform.up * nextSpeed);
                stopflage = true;
            }
           
        }
        stopflage = false;
    }
}
