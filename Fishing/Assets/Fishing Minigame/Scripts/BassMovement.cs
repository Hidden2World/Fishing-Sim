using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;



public class BassMovement : MonoBehaviour
{
    bool goingRight = true; // Start by going right
    Transform hookPos;
    public bool hooked;

    int randomValue;
    public int outOfValue;


    private float moveTimer = 0f;


    private Vector2 moveDirection;
    public float moveSpeed = 2f;        // Speed of fish movement
    public float switchInterval = 3f;   // Interval to switch direction in seconds

    private void Start()
    {
        hookPos = FindObjectOfType<hook>().transform;
        generateRandomAngle();
    }

    private void Update()
    {
        moveTimer += Time.deltaTime;


        if (!hooked)
        {
            MoveFish();
        }
        else if (hooked)
        {
            Debug.Log("Bass hooked");
            transform.position = hookPos.position;
        }
        if (moveTimer >= switchInterval)
        {
            // Set a new random direction
            generateRandomAngle();
            randomValue = Random.Range(0, outOfValue);



            // Reset the timer
            moveTimer = 0f;
        }
        if (randomValue == outOfValue)
        {
            randomDirection();
        }
    }
    private void randomDirection()
    {
        int i = Random.Range(1, 2);
        if (i == 1)
        {
            goingRight = true;
            
        }
        if (i == 2)
        {
            goingRight = false;
         }
    }
    private void MoveFish()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void generateRandomAngle()
    {
        if (goingRight)
        {
            moveDirection = new Vector2(Mathf.Cos(Random.Range(350f, 370f) * Mathf.Deg2Rad), Mathf.Sin(Random.Range(350f, 370f) * Mathf.Deg2Rad));
        }
        else
        {
            moveDirection = new Vector2(Mathf.Cos(Random.Range(170f, 190f) * Mathf.Deg2Rad), Mathf.Sin(Random.Range(170, 190) * Mathf.Deg2Rad));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Wall Box Right")
        {
            Debug.Log("Right wall hit bass");
            goingRight = false;
            generateRandomAngle();
        }
        else if (other.gameObject.name == "Wall Box Left")
        {
            Debug.Log("Left wall hit bass");
            goingRight = true;
            generateRandomAngle();
        }
    }
}


    

  
