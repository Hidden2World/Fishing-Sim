using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// this class is used to store our items
/// </summary>
public class PlayerInventory : MonoBehaviour
{
    // float used to store money
    public float Money;
    // storing the fish
    public List<FishTracker> FishBucket = new List<FishTracker>();

    // Start is called before the first frame update
    void Start()
    {

    }

    static private PlayerInventory playerinventory = null;

    private void Awake() // called when the object is created (before start)
    {
        if (playerinventory == null)
        {
            DontDestroyOnLoad(gameObject);
            playerinventory = this; //this means THIS script

        }
        else
        {
            Destroy(this);
        }

    }

}
