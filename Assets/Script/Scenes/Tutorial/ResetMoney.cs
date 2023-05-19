using System;
using System.Collections;
using System.Collections.Generic;
using Script.Money;
using UnityEngine;

public class ResetMoney : MonoBehaviour
{
    private void Start()
    {
        Currency.Instance.SetMoneyTo(80);
    }
}
