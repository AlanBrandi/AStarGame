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
        private MoneySO _moneySo;
        
        public int currentMoney { get; set; }
        
        void Awake()
        {
            if (!Instance)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
            _moneySo = Resources.Load<MoneySO>("Currency");
            currentMoney = _moneySo.currentMoney;
        }
        #region MoneySet
        public void AddMoney(int quantity)
        {
            currentMoney += quantity;
            _moneySo.currentMoney = currentMoney;
            UpdateMoneyUI(currentMoney);
        }
        public void TakeMoney(int purchaseValue)
        {
            currentMoney -= purchaseValue;
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
            if ((currentMoney -= purchaseValue) < 0)
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
