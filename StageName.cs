using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageName : MonoBehaviour
{
    //テキスト
    private Text stageNameText;

    void Start()
    {
        stageNameText = this.gameObject.GetComponent<Text>();
    }

    void Update()
    {
        stageNameText.color = Color.Lerp(stageNameText.color, new Color(1, 1, 1, 0), 0.8f * Time.deltaTime);
    }
}