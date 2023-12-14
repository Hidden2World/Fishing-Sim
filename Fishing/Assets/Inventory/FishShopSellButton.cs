using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishShopSellButton : MonoBehaviour
{
    [Header("References")]
    public PlayerInventory InventoryID;
    public FishInfo WhichFish;

    // Start is called before the first frame update
    void Start()
    {
        WhichFish = GetComponent<FishInfo>();
        InventoryID = FindObjectOfType<PlayerInventory>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SellFish()
    {
        InventoryID.SellFish(WhichFish.MyFish);
        Destroy(gameObject);
    }


}
