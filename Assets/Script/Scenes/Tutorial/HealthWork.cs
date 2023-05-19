using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthWork : MonoBehaviour
{
    [SerializeField] private GameObject _healthManager;
    [SerializeField] private DialogueSystem _dialogueSystem;
    private bool activated = false;

    private void Update()
    {
        if (!activated)
        {
            if (_dialogueSystem.spoke)
            {
                _healthManager.SetActive(true);
                activated = true;
            } 
        }
      
    }
}
