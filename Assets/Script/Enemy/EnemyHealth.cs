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
    [SerializeField] private GameObject _visualFX;
    [SerializeField] private GameObject _sfxObject;
    [SerializeField] private int score;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float value)
    {
        Instantiate(_sfxObject, transform.position, Quaternion.identity);
        currentHealth -= value;
        if(currentHealth <= 0)
        {
            Currency.Instance.AddMoney(_dropMoneyQuantity);
            ScoreManager.Instance.IncreaseScore(score);
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        BridgeRaise.Instance.Detach(this.GetComponent<Enemy>());
    }
}
