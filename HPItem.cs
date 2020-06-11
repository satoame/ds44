using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : MonoBehaviour
{
    private PlayerHit playerHit;
    private int reward = 10;
    float time = 2.0f;
    void Start()
    {
        // playerHit = GameObject.Find("Player").GetComponent<PlayerHit>();
        Destroy(gameObject, time);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);

           // playerHit.AddHP(reward);
        }
          
    }
}
