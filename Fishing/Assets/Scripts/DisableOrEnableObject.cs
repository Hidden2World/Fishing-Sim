using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class DisableOrEnableObject : MonoBehaviour
    //naomi

    
{
    public GameObject questionMarkPanel = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool isPaused;
    public void WhenButtonIsClicked()
    {
        if (questionMarkPanel.activeInHierarchy == true)
        {
            questionMarkPanel.SetActive(false);
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
        }


        else
        {

            questionMarkPanel.SetActive(true);
            Resume();
        }

        


    }
    public void Resume()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;

    }

}
