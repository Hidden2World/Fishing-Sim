using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Written by Milla > Discord me with any complaints

public class GameManager : MonoBehaviour
{
    private bool inventoryMenu;
    public GameObject inventoryObject;

    void Start()
    {
        inventoryMenu = false;        //inventory is closed on startup
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))     //Key subject to change in future
        {
            inventoryMenu = !inventoryMenu;  //toggles boolean with 'I' so player can both open and close the inventory with the same button
        }
    }

    void FixedUpdate()
    {
        if (inventoryMenu)
        {
            inventoryObject.SetActive(true);     //inventory is activated when bool is true
        }
        else
        {
            inventoryObject.SetActive(false);    //and closed when bool is false
        } 
    }
}
