using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    private GameObject target;

    void Start()
    {
        target = GameObject.Find("Player");
    }

    void Update()
    {
        this.gameObject.transform.LookAt(target.transform.position);
    }
}
