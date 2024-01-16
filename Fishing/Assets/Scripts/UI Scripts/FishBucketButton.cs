using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBucketButton : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Money;


    public void Bucket()
    {
        if (Inventory.activeSelf == false)
        {
            Debug.Log("Inventory activated");
            Inventory.SetActive(true);
            Money.SetActive(true);
        }
        else 
        {
            Debug.Log("Inventory Deactivated");
            Inventory.SetActive(false);
            Money.SetActive(false);
        }
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
