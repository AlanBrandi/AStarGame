using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UITorres : MonoBehaviour
{

    Camera m_Camera;
    Canvas canvas;

    private void Awake()
    {
        m_Camera = FindAnyObjectByType<Camera>();
    }

    private void Start()
    {
        canvas = GetComponent<Canvas>();
    }


    // Update is called once per frame
    void Update()
    {
        Click();
    }

    private void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = m_Camera.ScreenPointToRay(mousePos);
            
            



        }
    }
   
    
}
