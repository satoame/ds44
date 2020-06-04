using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : MonoBehaviour
{
    private PlayerHit playerHit;
    private int reward = 10;
   
    void Start()
    {
        playerHit = GameObject.Find("Player").GetComponent<PlayerHit>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

            playerHit.AddHP(reward);
        }
          
    }
}
