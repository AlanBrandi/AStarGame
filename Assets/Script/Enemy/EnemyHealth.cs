using System.Collections;
using System.Collections.Generic;
using QPathFinder;
using Script.Money;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    [SerializeField] private int _dropMoneyQuantity;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float value)
    {
        currentHealth -= value;
        if(currentHealth <= 0)
        {
            Die();
            Currency.Instance.AddMoney(_dropMoneyQuantity);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        BridgeRaise.Instance.Detach(this.GetComponent<Enemy>());
    }
}
