using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeWork : MonoBehaviour
{
    [SerializeField] private GameObject bridgeManager;
    private void Start()
    {
        bridgeManager.GetComponent<BridgeRaise>().enabled = true;
    }
}
