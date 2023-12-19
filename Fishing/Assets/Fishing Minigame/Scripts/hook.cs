using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

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

    GameObject hookedFish;
    

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
        if (caught)
        {
            if (Input.GetKey(KeyCode.R))
            {
                Destroy(hookedFish);
                rb.isKinematic = false;
                fishCaughtDisplay.SetActive(false);
                Debug.Log("r");
                isHooked = false;

                caught = false;
            }
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
            hookedFish = collision.gameObject;
            Debug.Log("HOOKED");
            if (collision.gameObject.name == "ClownFish(Clone)")
            
                caughtFish.GetComponent<ClownFishMovement>().hook = true;
                isHooked = true;

            }
             if (collision.gameObject.name == "SeaBass(Clone)")
            {
                caughtFish.GetComponent<BassMovement>().hook = true;
                isHooked = true;

            }
             if (collision.gameObject.name == "Shark()")
            {
                caughtFish.GetComponent<SharkMovement>().hook = true;
                isHooked = true;

            }

        }

    }
    
