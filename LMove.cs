using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMove : MonoBehaviour
{
    public float speed;
    private Vector3 pos;
    private bool isReturn = false;

    void Update()
    {
        pos = transform.position;

        if (pos.y > 0 && isReturn == false)
        {
            // 下方向
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        else
        {
            // 右方向
            isReturn = true;
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}
