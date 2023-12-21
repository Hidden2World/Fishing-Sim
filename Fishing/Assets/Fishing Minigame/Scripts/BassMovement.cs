using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BassMovement : FishMovement
{
    public int outOfPercentBass = 4;
    private void Start()
    {
        outOfPercent = outOfPercentBass;
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
