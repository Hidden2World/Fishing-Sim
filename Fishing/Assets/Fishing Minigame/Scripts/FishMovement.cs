using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishMovement : MonoBehaviour
{
    public float speed;
    bool forward;
    bool backward;
    public bool hook;
    public Transform hookPos;
    bool hooked;
    public int randomPercent;
    public int outOfPercent = 4; //what the chance is, if outOfPercent == 5, it is a 1 in 5 chance.
    public float timer = 0f;
    public float interval = 1f; //set the interval in seconds

    FishTracker fishTracker;
    // Start is called before the first frame update
    void Start()
    {
        forward = true;
        backward = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //hookPos = GameObject.FindWithTag("hook").transform;
        if (Input.GetKey(KeyCode.R) && hooked)
        {
            hook = false;
            hooked = false;
            transform.position =  new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
            Debug.Log("release");

        }
        // Increment the timer by the time since the last frame

        

        // Check if the interval has passed
        if (timer >= interval)
        {
            // Execute  code 
            randomPercent = Random.Range(0, outOfPercent);
            Debug.Log(randomPercent);

            // Reset the timer
            timer = 0f;
            
        }
      

    }

    private void FixedUpdate()
    {
        if (!hook)
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        else if (hook)
        {
            transform.position = hookPos.position;
            hooked = true;


        }
       
    }


       

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "wall" )
        {
            speed = speed * -1;
            
        }

    }
}
