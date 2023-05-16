using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QPathFinder;

public class Bridge : MonoBehaviour
{
    [SerializeField] private float _timeToLower;
    [SerializeField] private PathFinder _pathFinder;
    [SerializeField] private GameObject _bridge;
    [SerializeField] private int _pathIndex;

    public void Raise()
    {
        _pathFinder.graphData.GetPath(_pathIndex).isOpen = false;
        Invoke("Lower", _timeToLower);
        _bridge.SetActive(false);
        NotifyObservers();
    }
    public void Lower()
    {
        _pathFinder.graphData.GetPath(_pathIndex).isOpen = true;
        _bridge.SetActive(true);
        NotifyObservers();
    }
    public void NotifyObservers()
    {
        Debug.LogWarning("''''''''''''''''' TOWER BACK '''''''''''''''''''''''''");
        BridgeRaise.Instance.RaiseBridge();
    }
}
