using System;
using System.Collections;
using System.Collections.Generic;
using Script.Money;
using UnityEngine;

public class TowerInstance : MonoBehaviour
{

    [SerializeField] private GameObject tower1;
    [SerializeField] private GameObject tower2;
    [SerializeField] private GameObject tower3;

    private GameObject tmpTower;
    private RaycastHit hitTemp;
    private Camera m_Camera;
    
    private bool openTab = false;

    private void Awake()
    {
        m_Camera = Camera.main;
    }

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
            
            if(!openTab)
            {
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform.tag == "TowerSpot")
                    {
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
        openTab = false;
    }
    
    public void AddTower1()
    {
        if (tmpTower != null)
        {
            DeleteTower();
        }
        if (Currency.Instance.CanPurchase(80))
        {
            Currency.Instance.TakeMoney(80);
            tmpTower = Instantiate(tower1, new Vector3(this.transform.position.x, (this.transform.position.y + 6.8f),this.transform.position.z), Quaternion.identity);
        }
    }
    public void AddTower2()
    {
        if (tmpTower != null)
        {
            DeleteTower();
        }
        if (Currency.Instance.CanPurchase(120))
        {
            Currency.Instance.TakeMoney(120);
            tmpTower = Instantiate(tower2, new Vector3(this.transform.position.x, (this.transform.position.y + 6.8f),this.transform.position.z), Quaternion.identity);
        }
    }
    public void AddTower3()
    {
        if (tmpTower != null)
        {
            DeleteTower();
        }
        if (Currency.Instance.CanPurchase(250))
        {
            Currency.Instance.TakeMoney(250);
            tmpTower = Instantiate(tower3, new Vector3(this.transform.position.x, (this.transform.position.y + 6.8f),this.transform.position.z), Quaternion.identity);
        }
    }
    public void DeleteTower()
    {
        if (tmpTower != null)
        {
          if (tmpTower.GetComponent<Tower>().currentTowerLevel == 3)
          {
              Currency.Instance.AddMoney(250);
              Destroy(tmpTower);
          } 
          else if (tmpTower.GetComponent<Tower>().currentTowerLevel == 2)
          {
              Currency.Instance.AddMoney(120);
              Destroy(tmpTower);
          }
          else if (tmpTower.GetComponent<Tower>().currentTowerLevel == 1)
          {
              Currency.Instance.AddMoney(80);
              Destroy(tmpTower);
          }
        }
    }
}
