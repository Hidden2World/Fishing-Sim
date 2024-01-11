using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Milla

public class FishingHook : MonoBehaviour
{
    public float waterGravity = 30;

    bool inWater;

    Vector3 horizontalMovement;
    Vector3 verticalMovement;

    bool left;
    bool right;
    bool up;


    // Start is called before the first frame update
    void Start()
    {
        inWater = true;
        horizontalMovement = new Vector3(0.1f, 0, 0);
        verticalMovement = new Vector3(0, 0.1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(0, -waterGravity, 0);

        if (Input.GetKey(KeyCode.A))
        {
            left = true;
        }
        else { left = false; }
        if (Input.GetKey(KeyCode.D))
        {
            right = true;
        }
        else {  right = false; }
        if (Input.GetKey(KeyCode.Mouse0) && inWater || Input.GetKey(KeyCode.W) && inWater) 
        {
            up = true;
        } 
        else { up = false; }
    }

    void FixedUpdate()
    {
        if (left)
        {
            transform.position -= horizontalMovement;
        }
        if (right)
        {
            transform.position += horizontalMovement;
        }
        if (up)
        {
            transform.position += verticalMovement;
        }
        else
        {
            transform.position -= verticalMovement;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "water")
        {
            inWater = true;
        }
        else { inWater = false; }

        if (other.tag == "SkyBox")
        {
            inWater = false;
        }
        else { inWater = true; }
    }
}
