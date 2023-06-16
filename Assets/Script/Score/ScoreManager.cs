using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float pontosPorSegundo = 1f;
    public TMP_Text scoreTXT;

    private int score;

    private static ScoreManager instance;

    // Ensure that only one instance of the Singleton exists
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static ScoreManager Instance
    {
        get { return instance; }
    }
    public void IncreaseScore(int i)
    {
        score += i;
        scoreTXT.text = score.ToString();
    }

}
