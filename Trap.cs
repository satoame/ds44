using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    protected float waitTime;

    protected bool stop = false;

    protected IEnumerator Wait()
    {
        stop = true;

        yield return new WaitForSeconds(waitTime);

        stop = false;
    }
}