using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall: Trap
{

    float moveX;
    float moveY;
    float moveZ;
    float speed;

    float step;
    bool goBack = false;
    Vector3 origin;
    Vector3 destination;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 弾当たり判定
        if (collision.name.Contains("shot"))
        {
            Destroy(collision.gameObject);
        }
    }
}