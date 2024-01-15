using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOrEnableObject : MonoBehaviour
    //naomi

    
{
    public GameObject fishBucketInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void whenFishBucketIsClicked()
    {
        if (fishBucketInventory.activeInHierarchy == true)
            fishBucketInventory.SetActive(false);
        else
            fishBucketInventory.SetActive(true);
    }
}
