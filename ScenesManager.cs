using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    //スコア
    private ScoreManager sm;
    //hp
    private BossHp boss;

    void Start()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }


    void Update()
    { 
        //次のステージ移動
      /*  if (sm.score >= 50)
        {
            SceneManager.LoadScene("Hard");
        }*/
        
        if(sm.score >= 50)
        {
            SceneManager.LoadScene("Very Hard");
        }
    }
}
