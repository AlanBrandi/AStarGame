using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        Invoke(nameof(DeleteGameObect), 2f);
    }
    private void DeleteGameObect()
    {
        Destroy(gameObject);
    }
}
