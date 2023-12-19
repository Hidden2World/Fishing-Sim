using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SharkMovement : FishMovement
{
    public int outOfPercentClownFish = 4;
    private void Start()
    {
        outOfPercent = outOfPercentClownFish;
    }
    private void Update()
    {
        if (randomPercent == 1)
        {
            speed = speed * -1;
            Debug.Log("random swtich direction");
            randomPercent = 0;
        }
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            // Execute  code 
            randomPercent = Random.Range(0, outOfPercent);
            Debug.Log(randomPercent);

            // Reset the timer
            timer = 0f;

        }


    }



}


