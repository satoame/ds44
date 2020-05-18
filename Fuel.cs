using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    //経験値
    public int f_exp;
    public float brake;

    //方向
    private Vector3 direction;
    private float speed;

    // Update is called once per frame
    void Update()
    {
        //散らばる速さ
        var velocity = direction * speed;

        transform.localPosition += velocity;

        speed *= brake;

        transform.localPosition = Scroll.ClampPosition(transform.localPosition);
    }
}
