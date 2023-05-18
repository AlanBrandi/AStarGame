using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Text txtHealth;
    private int maxHealth = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            maxHealth--;
            txtHealth.text = maxHealth.ToString();
            Destroy(other.gameObject);

            if (maxHealth <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
