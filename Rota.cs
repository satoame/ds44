using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rota : MonoBehaviour
{
    public Vector2 pos;

    void Update()
    {
        transform.Rotate(new Vector3(pos.x, pos.y) * Time.deltaTime);
    }
}