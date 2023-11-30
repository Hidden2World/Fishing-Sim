using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousSound : MonoBehaviour
    //naomi
{
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("PlaySFX");
        if( musicObj.Length > 1 )
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
