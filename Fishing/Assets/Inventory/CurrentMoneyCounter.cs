using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentMoneyCounter : MonoBehaviour
{
    [Header("References")]
    public PlayerInventory Inventory;
    public TextMeshProUGUI CurrentMoneyText;

    // Start is called before the first frame update
    void Start()
    {
        CurrentMoneyText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Inventory == null)
        {
            Inventory = FindObjectOfType<PlayerInventory>();
        }
        CurrentMoneyText.text = "$" + Inventory.money;
    }
}
