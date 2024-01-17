using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PufferFishMovement : MonoBehaviour
{
    public float moveSpeed = 2f;        // Speed of fish movement
    public float switchInterval = 3f;   // Interval to switch direction in seconds
    public float puffInerval = 5f;

    public float puffedTime = 2f;

    public float moveTimer = 0f;
    public float puffTimer;
    


    private Vector2 moveDirection;
    public bool hooked;

    Transform hookPos;

    public string topBoundry;
    public string leftBoundry;
    public string rightBoundry;


    public float randomAngle;

    public bool skyBoxHit;
    public bool leftBoundryHit;
    public bool rightBoundryHit;

    public bool move;

    public GameObject puffedFish;
    public GameObject flaccidFish;

    public bool puffed;

  
    private void Start()
    {
        // Initialize the fish's initial movement direction
        SetRandomMoveDirection();
        puffedFish.SetActive(false);
        flaccidFish.SetActive(true);

    }

    private void Update()
    {


        if (hookPos == null)
        {
            hookPos = FindObjectOfType<hook>().transform;
        }


        if (Input.GetKey(KeyCode.R) && hooked)
        {
            hooked = false;
            transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
            Debug.Log("release");
        }


        // Update the timer
        moveTimer += Time.deltaTime;
        puffTimer += Time.deltaTime;

        if (puffTimer >= puffInerval)
        {
            if (!hooked && !puffedFish.activeSelf) //if pufferfish is in flaccid mode
            {
                puffedFish.SetActive(true);
                flaccidFish.SetActive(false);
                moveSpeed = moveSpeed / 2;
                puffTimer = 0;
                puffed = true;
            }
        }
        if (puffed == true)
        {
            if (puffTimer >= puffedTime)
            {
                puffedFish.SetActive(false);
                flaccidFish.SetActive(true);
                puffTimer = 0;
                moveSpeed = moveSpeed * 2;
                puffed = false;
            }
        }


        // Move the fish in its current direction
        if (!hooked && move)
        {
            MoveFish();
        }
        if (hooked)
        {
            transform.position = hookPos.position;
        }
        if (moveTimer <= 1f)
        {
            move = true;
        }
        else if (moveTimer > 1f)
        {
            move = false;
        }

        else if (hooked)
        {
            transform.position = hookPos.position;

        }
        // Check if it's time to switch direction
        if (moveTimer >= switchInterval)
        {
            // Set a new random direction
            SetRandomMoveDirection();

            // Reset the timer
            moveTimer = 0f;
        }
    }

    private void MoveFish()
    {
        // Move the fish based on the current direction and speed

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Calculate the angle in degrees and set the rotation
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);


    }

    private void SetRandomMoveDirection()
    {
        // Generate a random angle in radians
        if (skyBoxHit)
        {
            randomAngle = Random.Range(180f, 360f) * Mathf.Deg2Rad;
            moveTimer = 0f;

        }


        if (rightBoundryHit)
        {
            randomAngle = Random.Range(270f, 90f) * Mathf.Deg2Rad;
            moveTimer = 0f;


        }

        if (leftBoundryHit)
        {
            randomAngle = Random.Range(270f, 450f) * Mathf.Deg2Rad;
            moveTimer = 0f;

        }

        if (!skyBoxHit && !rightBoundryHit && !leftBoundryHit)
        {
            randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;



        }

        // Calculate the new move direction using trigonometry
        moveDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
    }

    private void OnTriggerEnter(Collider other)
    {
        //
        if (other.gameObject.name == topBoundry)
        {
            skyBoxHit = true;
            moveTimer = switchInterval;


            Debug.Log("Top Boundry Hit");
        }

        if (other.gameObject.name == leftBoundry)
        {
            leftBoundryHit = true;
            moveTimer = switchInterval;

            Debug.Log("Left Boundry Hit");
        }
        if (other.gameObject.name == rightBoundry)
        {
            rightBoundryHit = true;
            moveTimer = switchInterval;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (skyBoxHit)
        {
            skyBoxHit = false;
        }
        if (rightBoundryHit)
        {
            rightBoundryHit = false;
        }
        if (leftBoundryHit)
        {
            leftBoundryHit = false;
        }
    }
}