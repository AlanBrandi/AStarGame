using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QPathFinder;
using TMPro;
using UnityEditor;
using UnityEngine.Serialization;

public class Bridge : MonoBehaviour
{
    [Header("Configuration")] 
    [SerializeField] private float timeToLower;
    [SerializeField] private float cooldown;
    
    private float _cooldownRemain;
    private bool _isOnCooldown;

    //Path to disable.
    [SerializeField] private int pathIndex;

    //Pathfinder with nodes and path using.
    [SerializeField] private PathFinder pathFinder;

    //Disable bridge gameobject
    [SerializeField] private GameObject bridge;

    //WhereToSpawnFx
    [SerializeField] private GameObject whereToSpawn;
    
    [Header("Canvas")] 
    [SerializeField] private GameObject canvas;

    private TMP_Text countdownText;
    
    [Header("Visual FX")]
    [SerializeField] private GameObject breakFX;
    [SerializeField] private GameObject buildCompleteFX;
    [SerializeField] private GameObject buildingFX;
    [SerializeField] private GameObject cooldownIndicator;


    [Header("Sound FX")] 
    [SerializeField] private AudioSource breakSound;
    [SerializeField] private AudioSource buildCompleteSound;
    [SerializeField] private AudioSource buildingSound;

    //Function variables.
    public bool isBroken;
    public void Raise()
    {
        if (_isOnCooldown)
        {
            Debug.Log("The bridge is on cooldown. Wait for it to be available again.");
            return;
        }

        isBroken = true;
        pathFinder.graphData.GetPath(pathIndex).isOpen = false;
        bridge.SetActive(false);
        SpawnEffect(breakFX, breakSound);
        SpawnEffect(buildingFX, buildingSound);
        canvas.SetActive(true);
        countdownText = canvas.GetComponentInChildren<TMP_Text>();
        canvas.SetActive(true);
        buildingFX.SetActive(true);
        _cooldownRemain = cooldown;
        NotifyObservers();
        StartCountdown();
    }

    public void Lower()
    {
        Debug.LogWarning("LOWER");
        if (_isOnCooldown)
        {
            Debug.Log("The bridge is on cooldown. Wait for it to be available again.");
            return;
        }

        bridge.SetActive(true);
        pathFinder.graphData.GetPath(pathIndex).isOpen = true;
        SpawnEffect(buildCompleteFX, buildCompleteSound);
        NotifyObservers();
        isBroken = false;

        _cooldownRemain = cooldown;
        _isOnCooldown = true;
        Debug.LogWarning("CABO O LOWER");
    }

    private void NotifyObservers()
    {
        BridgeRaise.Instance.NotifyObservers();
    }

    private void SpawnEffect(GameObject fx, AudioSource soundFx)
    {
        Instantiate(fx, whereToSpawn.transform.position, fx.transform.rotation);
        soundFx.Play();
    }

    private void StartCountdown()
    {
        StartCoroutine(StartCountdownCou());
    }

    private IEnumerator StartCountdownCou()
    {
        float currentTime = timeToLower;
        while (currentTime > 0)
        {
            countdownText.text = currentTime.ToString("0");

            yield return new WaitForSeconds(1f);

            currentTime--;
        }
        if (currentTime <= 0)
        {
            canvas.SetActive(false);
            Lower();
            buildingFX.SetActive(false);
            buildingSound.Stop();
            StartCountdown();
            Debug.LogWarning("FINISHED COUNTDOWN");
            StopCoroutine(StartCountdownCou());
            StartCoroutine(CooldownCoroutine());
        }
    }

    private IEnumerator CooldownCoroutine()
    {
        _cooldownRemain = cooldown;
        _isOnCooldown = true;
        cooldownIndicator.SetActive(true);
        while (_cooldownRemain > 0)
        {
            yield return new WaitForSeconds(1f);
            _cooldownRemain--;
        }
        _isOnCooldown = false;
        cooldownIndicator.SetActive(false);
        //StopCoroutine(CooldownCoroutine());
    }
}