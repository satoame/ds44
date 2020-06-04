using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SwayMove : MonoBehaviour
{
   
    void Update()
    {
        transform.Translate(5.0f * Time.deltaTime * Mathf.Sin(Time.time * 2), 
                            -Time.deltaTime * Mathf.Sin(Time.time), 0);
    }
}
