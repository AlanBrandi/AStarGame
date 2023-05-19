using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Search;
using UnityEngine.SceneManagement;

public class SetActiveGO : MonoBehaviour
{
   [SerializeField] private GameObject _panel;
   [SerializeField] private DialogueSystem _dialogueSystem;

   void Update()
   {
      if (_dialogueSystem.spoke)
      {
         SceneManager.LoadScene("Tutorial2");
      }
   }

   public void SetActiveTrue()
   {
      _panel.SetActive(true);
   }
}
