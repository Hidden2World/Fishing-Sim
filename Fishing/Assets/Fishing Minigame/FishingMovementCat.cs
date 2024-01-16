using UnityEngine;

public class FishingMovementCat : MonoBehaviour
{
    public float sinkingSpeed = 2f;       // Speed at which the hook sinks
    public float reelingSpeed = 0.5f;     // Speed at which the hook is reeled up (adjust as needed)
    public float horizontalSpeed = 2f;    // Speed for left/right movement
    public float maxReelHeight = 10f;     // Maximum height to reel up

    private bool isReelingUp = false;
    private Transform reelTarget;

    private Rigidbody rb;

    public GameObject ui;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        reelTarget = GameObject.FindWithTag("ReelPoint").transform; // Find reel point by tag, adjust as needed
    }

    void Update()
    {
        if (!ui.gameObject.activeSelf)
        {
            // Left and right movement
            float horizontalInput = Input.GetAxis("Horizontal");
            float horizontalMovement = horizontalInput * horizontalSpeed * Time.deltaTime;
            rb.AddForce(Vector3.right * horizontalMovement, ForceMode.VelocityChange);

            // Space bar to reel up
            if (Input.GetKeyDown(KeyCode.Space) && !isReelingUp)
            {
                isReelingUp = true;
            }

            // Release space bar to resume sinking
            if (Input.GetKeyUp(KeyCode.Space) && isReelingUp)
            {
                isReelingUp = false;
                rb.velocity = Vector3.zero;

            }

            // Handle sinking and reeling up
            if (!isReelingUp)
            {
                SinkHook();
            }
            else
            {
                ReelUpHook();
            }
        }

        /*void SinkHook() //velocity + acceleration
        {
            // Move the hook downward
            float sinkAmount = sinkingSpeed * Time.deltaTime;
            rb.AddForce(Vector3.down * sinkAmount, ForceMode.VelocityChange);
        }
        */
        void SinkHook()
        {
            // Move the hook downward
            float sinkAmount = sinkingSpeed * Time.deltaTime;
            transform.position += Vector3.down * sinkAmount;
        }

        void ReelUpHook()
        {
            // Calculate the direction from the current position to the reel target
            Vector3 direction = (reelTarget.position - transform.position).normalized;

            // Apply a force to the rigidbody to move towards the target
            rb.AddForce(direction * reelingSpeed, ForceMode.VelocityChange);
        }



    }
 }
