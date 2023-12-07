using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook : MonoBehaviour
{



    public bool isHooked;

    public GameObject fishCaughtDisplay;

    public Rigidbody rb;
    bool isWater;
    public bool caught;
    PlayerInventory inventory;
    FIshingHookMovement hookMovementScript;
    FishTracker caughtFish;
    

    private void Start()
    {
        hookMovementScript = GetComponent<FIshingHookMovement>();

        inventory = FindObjectOfType<PlayerInventory>();    //find objectoftype finds the object in teh scene instead of the object.


    }
    private void Update()
    {
        if (caught)
        {
            rb.isKinematic = true;

        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Sky Box")
        {
            if (isHooked)
            {
                Debug.Log("Fish Caught");
                fishCaughtDisplay.SetActive(true);
                caught = true;

                if (caughtFish != null)
                {
                    inventory.FishBucket.Add(caughtFish);
                }
            }
        }
        caughtFish = collision.GetComponent<FishTracker>();
        if (caughtFish != null && !isHooked)
        {
            Debug.Log("HOOKED");

            caughtFish.GetComponent<FishMovement>().hook = true;
           
            isHooked = true;

        }

    }
    
}
