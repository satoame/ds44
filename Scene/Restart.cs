using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public ScoreManager sm;

    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("Game");

        //スコアリセット
        sm.score = 0;
    }
}