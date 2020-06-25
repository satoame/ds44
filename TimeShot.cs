using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class TimeShot : MonoBehaviour
{
    public float MinSpeed = 60;
    public float MaxSpeed = 300;
    public float nextSpeed;

    private Rigidbody rb;
    private GameObject target;

    private float timeCount = 0;
    public float stopTime = 3; 

    private float stopTimeCount = 0;
    private float nextStartTime = 2; 

    private bool stopflage = false;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.forwrd * Random.Range(MinSpeed, MaxSpeed));
        target = GameObject.Find("Player");
    }

    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount >= stopTime && stopflage == false)
        {
            stopTimeCount += Time.deltaTime;
            rb.velocity = Vector.zero;

            //プレイヤー方向

        }
    }
}
