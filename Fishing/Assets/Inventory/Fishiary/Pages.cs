using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pages : MonoBehaviour
{

    public Transform[] page;
    private int pageNumber ; //has to be an int!


    private void Start()
    {
        pageNumber = 0;
    }


    public void Next()
    {
        
        page[pageNumber].gameObject.SetActive(false);
        pageNumber++;
        page[pageNumber].gameObject.SetActive(true);
    }
    public void Back()
    {
        page[pageNumber].gameObject.SetActive(false);
        pageNumber--;
        page[pageNumber].gameObject.SetActive(true);
    }
}
