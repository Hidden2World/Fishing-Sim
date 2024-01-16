using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FishCaught : MonoBehaviour
{
    public TMP_Text text;

    public GameObject hook;
    private GameObject hookedFish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hook.GetComponent<hook>().hookedFish != null)
        {
            
            hookedFish = hook.GetComponent<hook>().hookedFish;
            string fishName = hookedFish.GetComponent<FishTracker>().type.ToString();
            float fishWeight = hookedFish.GetComponent<FishTracker>().weight;
            if (fishName != null && fishWeight != null)
            text.text = ("Caught " + fishName + "!" + "Weight: " + fishWeight + "KGS");
        }
    }
}
