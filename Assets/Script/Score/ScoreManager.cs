using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float pontosPorSegundo = 1f;
    public TMP_Text scoreTXT;

    private float pontuacao = 0f;

    private void Update()
    {
        pontuacao += pontosPorSegundo * Time.deltaTime;
        int pontuacaoInteira = Mathf.FloorToInt(pontuacao);
        scoreTXT.text = pontuacaoInteira.ToString();
    }

}
