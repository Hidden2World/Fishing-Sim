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
    bool up;
    public bool inWater;
    public GameObject waterCollider;
    public Rigidbody rb;
    public float leftMove;
    public float rightMove;
    bool left;
    bool right;
    

    // Start is called before the first frame update
    void Start()
    {
         SpringJoint joint = GetComponent<SpringJoint>();
        down = true;
    }

    // Update is called once per frame
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
        /*if (Input.GetKeyDown("right"))
        {
            rb.AddForce(rightMove, 0, 0);
            Debug.Log("right");
        }
        */
        // Debug.Log("inwater");
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
        // if (!down && Input.GetMouseButtonUp(0))
        //{

        //down = true;
        // }


        if (down)
        {
            //Debug.Log("down is ture");
        }
    }
    

        void FixedUpdate()
        {
        if (left)
        {
            // rb.AddForce(-leftMove, 0, 0);
            //Vector3 transform = new Vector3(0, 0, 0,);
            transform.position += new Vector3(-leftMove, 0, 0);
        }
        if (right)
        {
            //rb.AddForce(rightMove, 0, 0);
            transform.position += new Vector3(rightMove, 0, 0);
            
        }


        if (down)
        {
            joint.maxDistance = joint.maxDistance + jointIncrease * Time.deltaTime;
            //rb.AddForce(0, -1, 0);
            
            
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
    }
    private void OnTriggerExit(Collider collision)
    {
        //if (inWater)
       // {
        //    inWater = false; 
        //
    }
}

