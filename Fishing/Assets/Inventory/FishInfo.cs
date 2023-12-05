using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// this class is here to display the information used in the inventory menu, one class per fish
/// </summary>
public class FishInfo : MonoBehaviour
{
    [Header("References")]
    //referencing the text UI, used in the inventory to provide information on the fish
    public TMP_Text FishDescription;
    //accessing the fish and their types
    public FishTracker MyFish;
    //referencing the Fish image UI used next to the Description
    public Image FishImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //displays the fish information depending on the image and text provided to it by the InventoryManager script
    public void DisplayFishInformation()
    {
        // accessing the sprite saved to the fish
        FishImage.sprite = MyFish.FishImage;
        // accessing the text saved to the fish
        FishDescription.text = MyFish.FishDescription;
    }
}
