using UnityEngine;

public class SmolFishMovement : MonoBehaviour
{
    public float moveSpeed = 2f;        // Speed of fish movement
    public float switchInterval = 3f;   // Interval to switch direction in seconds
    public float burstSpeed = 5f;       // Speed during bursts
    public float burstDuration = 1f;    // Duration of burst in seconds
    public float circleRadius = 2f;     // Radius of the circular movement

    private float moveTimer = 0f;
    private Vector2 moveDirection;
    private bool hooked = false;
    private float burstTimer = 0f;

    private void Start()
    {
        // Initialize the fish's initial movement direction
        SetRandomMoveDirection();
    }

    private void Update()
    {
        if (!hooked)
        {
            // Move the fish in its current direction
            MoveFish();

            // Update the timer
            moveTimer += Time.deltaTime;

            // Check if it's time to switch direction
            if (moveTimer >= switchInterval)
            {
                // Set a new random direction
                SetRandomMoveDirection();

                // Reset the timer
                moveTimer = 0f;
            }

            // Check for burst duration
            if (burstTimer > 0f)
            {
                // Apply burst speed
                moveSpeed = burstSpeed;
                burstTimer -= Time.deltaTime;
            }
            else
            {
                // Return to normal speed
                moveSpeed = 2f;
            }
        }
        else
        {
            // Handle hooked fish behavior (add your specific logic here)
            Debug.Log("Smol fish is hooked!");
        }
    }

    private void MoveFish()
    {
        // Move the fish in a circular pattern
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void SetRandomMoveDirection()
    {
        // Generate a random angle in radians
        float randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;

        // Calculate the new move direction using trigonometry in a circular pattern
        float x = Mathf.Cos(randomAngle) * circleRadius;
        float y = Mathf.Sin(randomAngle) * circleRadius;

        moveDirection = new Vector2(x, y);

        // Start burst timer
        burstTimer = burstDuration;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hook"))
        {
            // Handle the fish being hooked
            HookFish();
        }
    }

    private void HookFish()
    {
        // Disable further movement when hooked
        hooked = true;

        // Add any specific hooked fish behavior here
    }
}
