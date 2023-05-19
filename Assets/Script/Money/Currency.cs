using System;
using UnityEngine;
using TMPro;

namespace Script.Money
{
    public class Currency : MonoBehaviour
    {
        //Sigleton.
        public static Currency Instance;

        [SerializeField] private TMP_Text _moneyTXT;
        [SerializeField] private MoneySO _moneySo;

        public int currentMoney;
        
        void Awake()
        {
            SetMoneyTo(0);
            if (!Instance)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }

            _moneySo.currentMoney = 80;
            currentMoney = _moneySo.currentMoney;
            UpdateMoneyUI(currentMoney);
        }
        
        #region MoneySet
        public void AddMoney(int quantity)
        {
            currentMoney =  currentMoney + quantity;
            _moneySo.currentMoney = currentMoney;
            UpdateMoneyUI(currentMoney);
        }
        public void TakeMoney(int purchaseValue)
        {
            Debug.LogWarning(currentMoney);
            currentMoney =  currentMoney - purchaseValue;
            Debug.LogWarning(currentMoney);
            _moneySo.currentMoney = currentMoney;
            UpdateMoneyUI(currentMoney);
        }

        public void SetMoneyTo(int value)
        {
            currentMoney = value;
            _moneySo.currentMoney = currentMoney;
            UpdateMoneyUI(currentMoney);
        }
        #endregion
        #region MoneyCalculate
      
        public bool CanPurchase(int purchaseValue)
        {
            if (currentMoney < purchaseValue)
            {
                return false;
            }
            return true;
        }
        #endregion
        private void UpdateMoneyUI(int value)
        {
            _moneyTXT.text = value.ToString();
        }
    }
}
