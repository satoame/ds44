using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall: Trap
{
    
    public float moveX;
    public float moveY;
    public float moveZ;
    public float speed;

    float step;
    bool goBack = false;
    Vector3 origin;
    Vector3 destination;
    public float accel;
    
    void Start()
    {
        origin = transform.position;
        destination = new Vector3(origin.x - moveX, origin.y - moveY, origin.z - moveZ);
    }

    void Update()
    {
        if (stop)
        {
            return;
        }

        step = speed * Time.deltaTime;

        if (!goBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, step);

            if (transform.position == destination)
            {
                goBack = true;

                StartCoroutine(Wait());
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, origin, step);

            if (transform.position == origin)
            {
                goBack = false;

                StartCoroutine(Wait());
            }
        }
    }

   /* void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "shot")
        {
            Debug.Log("collision");
        }
    }*/
}