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
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float value)
    {
        _audioSource.pitch = Random.Range(1, 1.2f);
        _audioSource.Play();
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
