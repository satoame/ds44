using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private Text scoreLabel;

    void Start()
    {
        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
        //scoreLabel.text = "SCORE" + score;
    }

    public void Scorel(int add)
    {
        score += add;
        scoreLabel.text = "SCORE" + score;

        //次のステージ移動
        if(score >= 500)
        {
            SceneManager.LoadScene("Hard");
        }
    }
}
