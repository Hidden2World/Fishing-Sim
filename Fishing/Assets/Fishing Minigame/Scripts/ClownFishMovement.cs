using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClownFishMovement : MonoBehaviour
{
    public float speed = 5;

    public bool hook;
    Transform hookPos;
    bool hooked;
    public int randomPercent;
    protected int outOfPercent = 4; //what the chance is, if outOfPercent == 5, it is a 1 in 5 chance.
    public float timer = 0f;
    public float interval = 1f; //set the interval in seconds

    FishTracker fishTracker;
    // Start is called before the first frame update
    void Start()
    {
        hook = false;
        hooked = false;
    }

    // Update is called once per frame
    void Update()
    {
        //hookPos = GameObject.FindWithTag("hook").transform;
        /*if (Input.GetKey(KeyCode.R) && hooked)
        {
            hook = false;
            hooked = false;
            transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
            Debug.Log("release");

        }
        */
         //Increment the timer by the time since the last frame



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
        if (hookPos == null)
        {
            hookPos = FindObjectOfType<hook>().transform;
        }

        if (!hook)
        {
            transform.position = new Vector3(transform.position.x + speed  * Time.deltaTime, transform.position.y, transform.position.z) ;
        }
        else if (hook)
        {

            transform.position = hookPos.position;
            hooked = true;
        }

    }

   
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "wall")
        {
            speed = speed * -1;
            Debug.Log("clownfishswitchmovement");

        }

    }
}
