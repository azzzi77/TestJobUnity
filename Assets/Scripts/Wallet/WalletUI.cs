using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletUI : MonoBehaviour
{
   
    [SerializeField] private Text TextMoney;
    [SerializeField] private Text TextCrystal;
   
 
    public void ResetBalans(TypeBalans type)
    {
        switch (type)
        {
            case TypeBalans.Money:
                {
                    TextMoney.text = "0";
                    break;
                }
            case TypeBalans.Crystal:
                {
                    TextCrystal.text = "0";
                    break;
                }

        }
    }

    public void SetBalans(TypeBalans type, int balans)
    {
        if (type == TypeBalans.Money)
            TextMoney.text = balans.ToString();
        if (type == TypeBalans.Crystal)
            TextCrystal.text = balans.ToString();
    }

    
}
