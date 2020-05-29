using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    //パネル
    public GameObject Panelfade;
    Image fadealpha;

    private float alpha;
    //フラグ変数
    private bool fadeout;
    private bool fadein;      　　 

    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); 
        alpha = fadealpha.color.a;                
        fadein = true;                            
    }

    void Update()
    {
        //フラグ処理
        if (fadein == true)
        {
            FadeIn();
        }
        if (fadeout == true)
        {
            FadeOut();
        }
    }

    //イン
    void FadeIn()
    {
        alpha -= 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha <= 0)
        {
            fadein = false;
            Panelfade.SetActive(false);

        }
    }

    //アウト
    void FadeOut()
    {
        alpha += 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            fadeout = false;
        }
    }

   /* public void SceneMove()
    {
        fadeout = true;
        Panelfade.SetActive(true);
    }*/
}