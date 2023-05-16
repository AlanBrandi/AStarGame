using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;

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
            //Dar dinheiro para o player
        }
    }

    private void Die()
    {
        BridgeRaise.Instance.Detach(gameObject.GetComponent<QPathFinder.Enemy>());
        Destroy(gameObject);
    }
}
