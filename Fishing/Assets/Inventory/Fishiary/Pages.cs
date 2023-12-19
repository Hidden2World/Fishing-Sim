using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pages : MonoBehaviour
{

    public Transform[] page;
    public TMP_Text PageNumber;
    private int pageNumberInt ; //has to be an int!


    private void Start()
    {
        pageNumberInt = 0;
       
    }

    private void Update()
    {
        
    }


    public void Next()
    {
        if (pageNumberInt < 19)
        {
            page[pageNumberInt].gameObject.SetActive(false);
            pageNumberInt++;
            PageNumber.text = $"Page: {pageNumberInt + 1}";
            page[pageNumberInt].gameObject.SetActive(true);
        }
    }
    public void Back()
    {
        if (pageNumberInt >= 1)
        {
            page[pageNumberInt].gameObject.SetActive(false);
            pageNumberInt--;
            PageNumber.text = $"Page: {pageNumberInt + 1}";
            page[pageNumberInt].gameObject.SetActive(true);
        }
   
    }
}
