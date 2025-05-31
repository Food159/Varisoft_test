using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHP : MonoBehaviour
{
    private int maxHp = 15;
    public TMP_Text hpAmountTxt;
    public int hp;
    private void Start()
    {
        hp = maxHp;
        hpAmountTxt.text = "HP : " + hp.ToString();
    }
    private void Update()
    {
        if (hp >= maxHp) 
        {
            hp = maxHp;
        }
        else if(hp <= 0)
        {
            hp = 0;
            gameObject.SetActive(false);

            //Destroy(gameObject); //If you use this it will cause an error

        }
        hpAmountTxt.text = "HP : " + hp.ToString();
    }
}
