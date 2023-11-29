using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FIshingHookMovement : MonoBehaviour
{
    public float jointIncrease;
    public float jointDecrease;
    public SpringJoint joint;
    bool down;
    bool inWater; 


    // Start is called before the first frame update
    void Start()
    {
         SpringJoint joint = GetComponent<SpringJoint>();
        down = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (inWater)
            while (Input.GetMouseButtonDown(0))
            {
                Debug.Log("mousebutton");
                down = false;
            }
            else
                down = true;
        if (down)
        {
            Debug.Log("down is ture");
        }

    }

    private void FixedUpdate()
    {
        if (down)
        {
            joint.maxDistance = joint.maxDistance + jointIncrease * Time.deltaTime;
            Debug.Log("goingdown");
        }
        if (!down)
        {
            joint.maxDistance = -jointDecrease * Time.deltaTime;
            Debug.Log("going up");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "water")
        {
            inWater = true; 
        }
    }
    private void OnCollisionExit(Collision collision) 
    {
        if (inWater)
        {
            inWater = false; 
        }
    }
}

