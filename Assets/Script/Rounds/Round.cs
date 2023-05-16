using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    public Button buttonToClick;
    public Button buttonToBeClicked;
    public float clickInterval = 0.1f;
    private int clickCount = 0;
    public int qtdEnemies;

    public GameObject torre2;

    private void Start()
    {
        //buttonToClick.onClick.AddListener(StartButtonClicking);
    }

    public  void StartButtonClicking()
    {
        
        StartCoroutine(ClickMultipleTimes());
        torre2.SetActive(true);
    }

    private IEnumerator ClickMultipleTimes()
    {
        for (int i = 0; i < qtdEnemies; i++)
        {
            buttonToBeClicked.onClick.Invoke();
           
            clickCount++;
            yield return new WaitForSeconds(clickInterval);
        }

        Debug.Log("Button clicked " + clickCount + " times.");
    }
}
