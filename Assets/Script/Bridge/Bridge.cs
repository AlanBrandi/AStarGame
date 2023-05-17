using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QPathFinder;
using TMPro;

public class Bridge : MonoBehaviour
{
    [Header("Configuration")] [SerializeField]
    private float _timeToLower;

    //Path to disable.
    [SerializeField] private int _pathIndex;

    //Pathfinder with nodes and path using.
    [SerializeField] private PathFinder _pathFinder;

    //Disable brigde gameobject
    [SerializeField] private GameObject _bridge;

    //WhereToSpawnFx
    [SerializeField] private GameObject _WhereToSpawn;

    [Header("Canvas")] [SerializeField] private GameObject _canvas;

    private TMP_Text countdownText;

    [Header("Visual FX")] [SerializeField] private GameObject _breakFX;
    [SerializeField] private GameObject _buildCompleteFX;

    [Header("Sound FX")] [SerializeField] private AudioSource _breakSound;
    [SerializeField] private AudioSource _buildCompleteSound;

    public void Raise()
    {
        _pathFinder.graphData.GetPath(_pathIndex).isOpen = false;
        _bridge.SetActive(false);
        SpawnEffect(_breakFX, _breakSound);
        _canvas.SetActive(true);
        NotifyObservers();
        countdownText = _canvas.GetComponentInChildren<TMP_Text>();
        _canvas.SetActive(true);
        StartCountdown();
    }

    public void Lower()
    {
        _bridge.SetActive(true);
        _pathFinder.graphData.GetPath(12).isOpen = true;
        SpawnEffect(_buildCompleteFX, _buildCompleteSound);
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        BridgeRaise.Instance.NotifyObservers();
    }

    private void SpawnEffect(GameObject fx, AudioSource soundFx)
    {
        Instantiate(fx, _WhereToSpawn.transform.position, Quaternion.identity);
        soundFx.Play();
    }

    private void StartCountdown()
    {
        StartCoroutine(StartCountdownCou());
    }
    private IEnumerator StartCountdownCou()
    {
        float currentTime = _timeToLower;
        while (currentTime > 0)
        {
            countdownText.text = currentTime.ToString("0");

            yield return new WaitForSeconds(1f);

            currentTime--;
        }
        if (currentTime <= 0)
        {
            _canvas.SetActive(false);
            StopCoroutine(StartCountdownCou());
            Lower();
        }
    }
}
