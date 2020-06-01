using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 pos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        pos = transform.position;

        if (pos.y < 0)
        {
            // 速度を０。
            rb.velocity = Vector3.zero;

            //力を加える
            //
        }
    }
}