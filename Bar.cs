using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    //最大
    int maxHp = 100;
    //今
    int Hp; 

    public Slider slider;

    void Start()
    {
        //フル
        slider.value = 1;

        Hp = maxHp;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            int damage = 10;
            // Debug.Log("damage : " + damage);

            Hp = Hp - damage;

            slider.value = (float)Hp / (float)maxHp;
           
        }
    }
}
