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
    public float leftMove;
    public float rightMove;

    bool down;
    bool up;
    public bool inWater;
    bool left;
    bool right;

    public GameObject waterCollider;

    public Rigidbody rb;
    public SpringJoint joint;

    string hookType;

  




    void Start()
    {
         SpringJoint joint = GetComponent<SpringJoint>();
         down = true;
         
    }

 
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            left = true;
        }
        else
        {
            left = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            right = true;

        }
        else
        {
            right = false;
        }
        if (Input.GetMouseButton(0) && inWater)
        {
            down = false;
            up = true;
        }
        else
        {
            down = true;
            up = false;
        }
    }
    

        void FixedUpdate()
        {
        if (left)
        {
            
            transform.position += new Vector3(-leftMove, 0, 0);
        }
        if (right)
        {
            transform.position += new Vector3(rightMove, 0, 0);        
        }


        if (down)
        {
            joint.maxDistance = joint.maxDistance + jointIncrease * Time.deltaTime;
        }
        if (up)
        {
            joint.maxDistance = joint.maxDistance - jointDecrease * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == waterCollider)
        {
            inWater = true; 
        }

        if (collision.gameObject.name == "Sky Box") ;
            
    }

   
}

