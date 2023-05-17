using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QPathFinder;

public class Bridge : MonoBehaviour
{
    [SerializeField] private float _timeToLower;
    [SerializeField] private PathFinder _pathFinder;
    [SerializeField] private GameObject _bridge;

    public void Raise()
    {
        _pathFinder.graphData.GetPath(12).isOpen = false;
        Invoke("Lower", _timeToLower);
        _bridge.SetActive(false);
    }
    public void Lower()
    {
        _bridge.SetActive(true);
        _pathFinder.graphData.GetPath(12).isOpen = true;
         NotifyObservers();
    }
    public void NotifyObservers()
    {
      BridgeRaise.Instance.NotifyObservers();
    }
}
