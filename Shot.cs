using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    //速度
    private Vector3 velocity;
    // Update is called once per frame
    void Start()
    {
        var shot = gameObject.GetComponent<Rigidbody2D>();
        var canvas = GetComponentInParent<Canvas>();
    }

    void Update()
    {
        transform.localPosition += velocity; 
    }

    public void Init(float angle, float speed)
    {
        var direction = Scroll.GetDirection(angle);

        velocity = direction * speed;

        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;

        Destroy(gameObject, 2);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            //Debug.Log("collision");
            Destroy(this.gameObject);
        }
    }
}
