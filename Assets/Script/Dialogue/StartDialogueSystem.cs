using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class StartDialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI speechBubbleText; // Referência ao componente TextMeshProUGUI
    public string[] dialogueTexts; // Textos do diálogo definidos pelo Inspector
    public AudioSource audioSource;
    private Queue<string> dialogueQueue = new Queue<string>(); // Fila de diálogos
    private bool isAnimating = false; // Flag para verificar se a animação está ocorrendo
    void Awake()
    {
        StartDialogue();
    }

    void OnEnable()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        // Limpa a fila de diálogos e adiciona os novos diálogos à fila
        dialogueQueue.Clear();
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
        yield return new WaitForSeconds(2f);

        // Verifica se há mais diálogos na fila
        if (dialogueQueue.Count > 0)
        {
            // Inicia a animação do próximo diálogo
            StartCoroutine(AnimateDialogue());
        }
        else
        {
            isAnimating = false;
        }
    }
}