using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    private BossHP boss;

    void Start()
    {
        boss = GameObject.Find("BossHP").GetComponent<BossHP>();
    }

    void Update()
    {
        if(boss.bossHP == 0)
        {
            SceneManager.LoadScene("Clear");
        }
    }

    public void OnRetry()
    {
        SceneManager.LoadScene("Title");
    }
}
