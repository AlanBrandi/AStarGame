using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    [SerializeField] private DialogueSystem _dialogueSystem;
    private bool activated = false;

    private void Update()
    {
        if (!activated)
        {
            if (_dialogueSystem.spoke)
            {
                dialogue.SetActive(false);
                activated = true;
            } 
        }
      
    }
}
