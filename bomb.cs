﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    void OnAnimationFinish()
    {
        Destroy(gameObject);
    }
}
