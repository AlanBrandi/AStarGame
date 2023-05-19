using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inimigo
{
    public string nome;
    public int poder;
    public GameObject prefab;
}

[System.Serializable]
public class Wave
{
    public int numero;
    public float intervaloEntreInimigos;
    public int quantidadeInimigos;
    public List<Inimigo> possiveisInimigos;
}

public class WaveManager : MonoBehaviour
{
    public List<Wave> waves;
    public Transform[] spawnPoints;
    public float intervaloEntreWaves = 5f;

    private int waveAtual = 0;
    private WaitForSeconds waveDelay;

    private void Start()
    {
        waveDelay = new WaitForSeconds(intervaloEntreWaves);
        StartCoroutine(ExecutarWaves());
    }

    private IEnumerator ExecutarWaves()
    {
        while (waveAtual < waves.Count)
        {
            yield return waveDelay;

            waveAtual++;
            Debug.Log("Iniciando Wave " + waveAtual);

            Wave wave = waves[waveAtual - 1];
            float intervaloEntreInimigos = wave.intervaloEntreInimigos;

            for (int i = 0; i < wave.quantidadeInimigos; i++)
            {
                Inimigo inimigoEscolhido = EscolherInimigoAleatorio(wave.possiveisInimigos);
                if (inimigoEscolhido != null)
                {
                    Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                    GameObject spawnedEnemy = Instantiate(inimigoEscolhido.prefab, spawnPoint.position, spawnPoint.rotation);
                    // Personalize o comportamento do inimigo conforme necessário.

                    Debug.Log("Instanciando " + inimigoEscolhido.nome + " na posição " + spawnPoint.position);
                }
                else
                {
                    Debug.LogWarning("Nenhum inimigo disponível para a Wave " + wave.numero);
                }

                yield return new WaitForSeconds(intervaloEntreInimigos);
            }
        }
    }

    private Inimigo EscolherInimigoAleatorio(List<Inimigo> possiveisInimigos)
    {
        if (possiveisInimigos.Count == 0)
        {
            return null;
        }

        int indiceAleatorio = Random.Range(0, possiveisInimigos.Count);
        return possiveisInimigos[indiceAleatorio];
    }
}