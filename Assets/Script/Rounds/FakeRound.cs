using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Search;
using UnityEngine.UI;

public class FakeRound : MonoBehaviour
{
   [SerializeField] private int qtdEnemies;
   [SerializeField] private float interval;
   [SerializeField] private SpawnEnemy _spawnEnemy;
   [SerializeField] private GameObject _enemyType;


   private int _enemyCount;
    private void Start()
    {
        StartButtonClicking();
        _enemyCount = qtdEnemies;
    }

    public  void StartButtonClicking()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < qtdEnemies; i++)
        {
            _spawnEnemy.SpawnEnemyToPlace(_enemyType);
            yield return new WaitForSeconds(interval);
            _enemyCount--;
        }

        if (_enemyCount < 1)
        {
            StopCoroutine(SpawnEnemy());
            _enemyCount = qtdEnemies;
            StartButtonClicking();
        }
    }
}
