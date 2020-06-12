using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if ((collider.gameObject.tag == "Enemy") || (collider.gameObject.tag == "EnemyS") || (collider.gameObject.tag == "Eshot"))
        {
            Destroy(collider.gameObject);
        }
    }
}