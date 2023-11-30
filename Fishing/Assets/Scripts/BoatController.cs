using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{

    public Rigidbody rb;
    public float moveSpeed = 12;
    public float turnSpeed;
    [SerializeField]
    private float moveInputValue;
    private float turnInputValue;

    void Start()
    {
        
    }


    void Update()
    {
        moveInputValue = Input.GetAxis("Vertical");
        turnInputValue = Input.GetAxis("Horizontal");
        if (moveInputValue <= 0)
        {
            //moveInputValue = 0;
            moveSpeed = 6;
        }
        if (moveInputValue >= 0)
        {
            moveSpeed = 12;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * moveInputValue * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void Turn()
    {
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
