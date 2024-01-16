using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

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

    public GameObject skyBox;
    public GameObject hookedFish;
    

    private void Start()
    {
        hookMovementScript = GetComponent<FIshingHookMovement>();

        inventory = FindObjectOfType<PlayerInventory>();    //find objectoftype finds the object in teh scene instead of the object.


    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("SampleScene");
            Debug.Log("Load Scene");
        }
        if (Input.GetKeyDown(KeyCode.R)&& caught)
        {
            caught = false;
            isHooked = false;
            Destroy(hookedFish);
            rb.isKinematic = false;
            fishCaughtDisplay.SetActive(false);
            Debug.Log("r");
            hookedFish = null;

        }
    }
    
    private void OnTriggerEnter(Collider collision)
    {


        if (collision.gameObject == skyBox)
        {
            Debug.Log("Sky box was indeed hit");
            if (isHooked)
            {
                Debug.Log("Fish Caught");
                fishCaughtDisplay.SetActive(true);
                rb.isKinematic = true;
                caught = true;
                Debug.Log("caught");

                if (caughtFish != null)
                {
                    inventory = FindObjectOfType<PlayerInventory>();
                    inventory.FishBucket.Add(caughtFish);
                }


            }
        }
        caughtFish = collision.gameObject.GetComponent<FishTracker>();
        if (caughtFish != null && !isHooked)
        {
            hookedFish = collision.gameObject;
            Debug.Log("HOOKED");

            turnHookOff();

        }
    }

        private void turnHookOff()
        {
            if (hookedFish.name == "ClownFish(Clone)")
            {
                hookedFish.GetComponent<ClownFishMovement>().hook = true;
                isHooked = true;
                hookedFish.GetComponent<BoxCollider>().enabled = false;
            
            }

            if (hookedFish.gameObject.name == "SeaBass(Clone)")
            {
                hookedFish.GetComponent<BassMovement>().hooked = true;
                isHooked = true;
                hookedFish.GetComponent<BoxCollider>().enabled = false;


        }


        if (hookedFish.gameObject.name == "Shark(Clone)")
            {
                hookedFish.GetComponent<SharkMovement>().hooked = true;
                isHooked = true;
                hookedFish.GetComponent<BoxCollider>().enabled = false;


        }

        if (hookedFish.gameObject.name == "SeaHorse(Clone)")

            {
                Debug.Log("sea horse touched");

                hookedFish.GetComponent<SeaHorseMovement>().hooked = true;
                isHooked = true;
                hookedFish.GetComponent<BoxCollider>().enabled = false;
        }
            if (hookedFish.gameObject.name == "Squid(Clone)")

            {
                Debug.Log("SQUID TOUCHED");

                hookedFish.GetComponent<SquidMovement>().hooked = true;
                isHooked = true;
                hookedFish.GetComponent<BoxCollider>().enabled = false;
        }
            if (hookedFish.gameObject.name == "BasicFish2(Clone)")
            {
                Debug.Log("Basic Fish Touched");

                hookedFish.GetComponent<BassMovement>().hooked = true;
                isHooked = true;
                hookedFish.GetComponent<BoxCollider>().enabled = false;
        }



    }
       
   
    }

    
