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

    public GameObject hookedFish;
    

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
                    inventory = FindObjectOfType<PlayerInventory>();
                    inventory.FishBucket.Add(caughtFish);
                }


            }
        }
        caughtFish = collision.GetComponent<FishTracker>();
        if (caughtFish != null && !isHooked)
        {
            hookedFish = collision.gameObject;
            Debug.Log("HOOKED");

            turnHookOff();

        }
    }

        private void turnHookOff()
        {
            if (hookedFish.gameObject.name == "ClownFish(Clone)")
            {
                 hookedFish.GetComponent<ClownFishMovement>().hook = true;
                  isHooked = true;
            }

            if (hookedFish.gameObject.name == "SeaBass(Clone)")
            {
                hookedFish.GetComponent<BassMovement>().hooked = true;
                isHooked = true;

            }


            if (hookedFish.gameObject.name == "Shark(Clone)")
            {
                hookedFish.GetComponent<SharkMovement>().hooked = true;
                isHooked = true;

            } 

            if (hookedFish.gameObject.name == "SeaHorse(Clone)")

            {
                Debug.Log("sea horse touched");

                hookedFish.GetComponent<SeaHorseMovement>().hooked = true;
                isHooked = true;
            }
            if (hookedFish.gameObject.name == "Squid(Clone)")

            {
                Debug.Log("SQUID TOUCHED");

                hookedFish.GetComponent<SquidMovement>().hooked = true;
                isHooked = true;
            }
            if (hookedFish.gameObject.name == "BasicFish2(Clone)")
            {
                Debug.Log("Basic Fish Touched");

                hookedFish.GetComponent<BassMovement>().hooked = true;
                isHooked = true;
            }



    }
       
   
    }

    
