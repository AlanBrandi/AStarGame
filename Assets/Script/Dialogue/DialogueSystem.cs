using System;
using System.Collections;
using System.Collections.Generic;
using Script.Scenes.Tutorial;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI speechBubbleText; // Referência ao componente TextMeshProUGUI
    public string[] dialogueTexts; // Textos do diálogo definidos pelo Inspector

    public Animator anim;
    public AudioSource audioSource;
    private Queue<string> dialogueQueue = new Queue<string>(); // Fila de diálogos
    private bool isAnimating = false; // Flag para verificar se a animação está ocorrendo
    public bool spoke = false; // Flag para verificar se a animação está ocorrendo
    public bool startAlone;

    public EnumTutorialState changeToThisState;
    private void Start()
    {
        if (startAlone)
        {
            StartDialogue();
        }
    }

    private void Update()
    {
        if (spoke)
        {
            TutorialManager.Instance.ChangeState(changeToThisState);
        }
    }

    public void StartDialogue()
    {
        // Limpa a fila de diálogos e adiciona os novos diálogos à fila
        spoke = false;
        dialogueQueue.Clear();
        anim.SetBool("Speaking", true);
        foreach (string text in dialogueTexts)
        {
            dialogueQueue.Enqueue(text);
        }

        // Inicia a animação do próximo diálogo
        if (!isAnimating)
        {
            StartCoroutine(AnimateDialogue());
        }
    }

    private IEnumerator AnimateDialogue()
    {
        isAnimating = true;

        // Aguarda um pequeno atraso antes de começar a animação
        yield return new WaitForSeconds(0.5f);

        // Obtém o próximo diálogo da fila
        string dialogueText = dialogueQueue.Dequeue();

        // Configura o texto no balão de fala
        speechBubbleText.text = dialogueText;

        // Animação do texto
        int totalVisibleCharacters = speechBubbleText.text.Length;
        int visibleCount = 0;

        while (visibleCount <= totalVisibleCharacters)
        {
            speechBubbleText.maxVisibleCharacters = visibleCount;
            visibleCount++;
            audioSource.pitch = (Random.Range(1.8f, 2.1f));
            audioSource.Play();
            yield return new WaitForSeconds(0.06f); // Ajuste a velocidade da animação aqui
        }

        // Aguarda um pequeno atraso após a animação
        if (anim != null)
        {
            anim.SetBool("Speaking", false);
        }
        yield return new WaitForSeconds(2f);

        // Verifica se há mais diálogos na fila
        if (dialogueQueue.Count > 0)
        {
            // Inicia a animação do próximo diálogo
            if (anim != null)
            {
             anim.SetBool("Speaking", true);
            }
            StartCoroutine(AnimateDialogue());
        }
        else
        {
            isAnimating = false;
            if (anim != null)
            {
             anim.SetBool("Speaking", false);
            }

            spoke = true;
        }
    }
}