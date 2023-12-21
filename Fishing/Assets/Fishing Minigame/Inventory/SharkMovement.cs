using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SharkMovement : FishMovement
{
    public int outOfPercentShark = 4;
    private void Start()
    {
        outOfPercent = outOfPercentShark;
    }
    private void Update()
    {
        if (randomPercent == 1)
        {
            speed = speed * -1;
            randomPercent = 0;
        }
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            // Execute  code 
            randomPercent = Random.Range(0, outOfPercent);

            // Reset the timer
            timer = 0f;

        }


    }



}


