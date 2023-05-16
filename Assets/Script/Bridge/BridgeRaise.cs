using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

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
    //Colocar no lugar certo
    public Animator Ponte1a;
    public Animator Ponte1b;
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
            //colocar no lugar certo
            Ponte1a.SetBool("Idle",false);
            Ponte1a.SetBool("Raise", true);
            Ponte1b.SetBool("Idle", false);
            Ponte1b.SetBool("Raise", true);
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Bridge"))
                {
                    Debug.Log("Hit bridge");
                    hit.collider.GetComponent<Bridge>().Raise();
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
            Debug.LogWarning("Avisou");
        }
    }
    #endregion

    public void RaiseBridge()
    {
        NotifyObservers();
    }
}
