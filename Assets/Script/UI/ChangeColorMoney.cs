using System;
using System.Collections;
using System.Collections.Generic;
using Script.Money;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorMoney : MonoBehaviour
{
    [SerializeField] private Image image;
    public int value;
    private void Update()
    {
        if (Currency.Instance.currentMoney < value)
        {
            image.color = new Color(1, 1, 1, .75f);
        }
        else
        {
            image.color = new Color(1, 1, 1, 1);
        }
    }
}
