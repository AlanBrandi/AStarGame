using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class UITorres : MonoBehaviour
{

    Camera m_Camera;

    [SerializeField] List<Canvas> canvasList;
    [SerializeField] List<Button> buttonList;

    private RaycastHit hitTemp;

    

    bool openTab = false;

    private void Awake()
    {
        m_Camera = FindAnyObjectByType<Camera>();
        Canvas[] canvas = FindObjectsOfType<Canvas>();
        canvasList = new List<Canvas>(canvas);
        Button[] btn = FindObjectsOfType<Button>();
        buttonList = new List<Button>(btn);
    }

    private void Start()
    {
        foreach (Canvas canvas in canvasList)
        {
            canvas.GetComponent<Canvas>().enabled = false;
        }
        foreach(Button button in buttonList)
        {
            button.GetComponent<Button>();
        }
       
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
            
            if(openTab != true)
            {
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform.tag == "TowerSpot")
                    {
                        Debug.Log(hit.transform.tag);
                        hit.collider.GetComponentInChildren<Canvas>().enabled = true;
                        hitTemp = hit;
                        openTab = true;

                    }

                }
            }

            



        }
    }
   
    public void CloseTab()
    {
        hitTemp.collider.GetComponentInChildren<Canvas>().enabled = false;
        openTab = false;
    }
    
}
