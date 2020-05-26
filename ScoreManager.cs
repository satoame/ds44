using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private Text scoreLabel;

    void Start()
    {
        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
        scoreLabel.text = "SCORE" + score;
    }

    public void Scorel(int add)
    {
        score += add;
        scoreLabel.text = "SCORE" + score;
    }
}
