using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class is here to manage the inventory, displaying each fish as a seperate panel
/// </summary>
public class InventoryManager : MonoBehaviour
{
    [Header("References")]
    // referencing the gameobjects used to display the information taken from FishTracker
    public PlayerInventory PlayerInventoryReference;
    public FishInfo AnyFishInventoryDisplay;
    public GameObject InventoryContents;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        // clearing all the children(gameobjects) that are currently being displayed in the inventory
        foreach(Transform child  in InventoryContents.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        // adding the information for every single fish in the inventory
        foreach(FishTracker Fish in PlayerInventoryReference.FishBucket)
        {
            FishInfo _FishDisplay = Instantiate (AnyFishInventoryDisplay, InventoryContents.transform);
            _FishDisplay.MyFish = Fish;
            _FishDisplay.DisplayFishInformation();
        }

    }
}
