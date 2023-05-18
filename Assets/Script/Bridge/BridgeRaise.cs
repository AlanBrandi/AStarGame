using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void NotifyBridgeRaise();
}
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void NotifyObservers();
}
public class BridgeRaise : MonoBehaviour, ISubject
{
    private Camera mainCamera;
    public List<IObserver> _observers = new List<IObserver>();
    public static BridgeRaise Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        mainCamera = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Bridge"))
                {
                    if (!hit.collider.GetComponent<Bridge>().isBroken)
                    {
                        Debug.Log("Hit bridge");
                        hit.collider.GetComponent<Bridge>().Raise();
                        RaiseBridge();
                    }
                }
            }
        }
    }
    #region Observer
    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in _observers)
        {
            observer.NotifyBridgeRaise();
        }
    }
    #endregion
    public void RaiseBridge()
    {
        NotifyObservers();
    }
}
