using UnityEngine;

public class SeaHorseMovement : MonoBehaviour
{
    public float moveSpeed = 2f;        // Speed of fish movement
    public float switchInterval = 3f;   // Interval to switch direction in seconds

    private float moveTimer = 0f;
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

    private void Start()
    {
        // Initialize the fish's initial movement direction
        SetRandomMoveDirection();
        hookPos = FindObjectOfType<hook>().transform;
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

        // Move the fish in its current direction
        if (!hooked)
        {
            MoveFish();
        }

        else if (hooked)
        {
            Debug.Log("seahorse hooked");
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
    }

    private void SetRandomMoveDirection()
    {
        // Generate a random angle in radians
        if (skyBoxHit)
        {
            randomAngle = Random.Range(180f, 360f) * Mathf.Deg2Rad;
        }

        if (rightBoundryHit)
        {
            randomAngle = Random.Range(270f, 90f) * Mathf.Deg2Rad;
        }

        if (leftBoundryHit)
        {
            randomAngle = Random.Range(270f, 450f) * Mathf.Deg2Rad;
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
            Debug.Log("Right Boundry Hit");
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
