using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class TextPromptsScript : MonoBehaviour
{
    public GameObject textPromptCanvas;

    void OnTriggerEnter(Collider collider) 
    {
        if(collider.tag == "Player")
        {
            textPromptCanvas.SetActive(true);
        }
    }

    void OnTriggerExit()
    {
        textPromptCanvas.SetActive(false);
    }

}
