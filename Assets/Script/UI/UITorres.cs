using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UITorres : MonoBehaviour
{

    Camera m_Camera;

    [SerializeField]  List<Canvas> canvasList;
   


    private void Awake()
    {
        m_Camera = FindAnyObjectByType<Camera>();
    }

    private void Start()
    {
        Canvas[] canvas = FindObjectsOfType<Canvas>();
        canvasList = new List<Canvas>(canvas);
       
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

            if (Physics.Raycast(ray, out RaycastHit hit) || hit.transform.tag == "TowerSpot")
            {
                
            }



        }
    }
   
    
}
