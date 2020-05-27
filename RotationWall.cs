using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class RotationWall : Trap
{
    public Vector3 pos;

    void Update()
    {
        transform.Rotate(new Vector3(pos.x, pos.y, pos.z) * Time.deltaTime);
    }
}
