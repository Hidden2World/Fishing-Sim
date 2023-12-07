using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed;
    bool forward;
    bool backward;
    public bool hook;
    public Transform hookPos;
    bool hooked;


    FishTracker fishTracker;
    // Start is called before the first frame update
    void Start()
    {
        forward = true;
        backward = false;
        hookPos = GameObject.FindWithTag("hook").transform;
    }

    // Update is called once per frame
    void Update()
    {

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

        if (other.gameObject.tag == "wall")
        {
            speed = speed * -1;
            Debug.Log("swtich directions");
        }
        if (other.gameObject.tag == "hook" && !other.gameObject.GetComponent<hook>().isHooked)
        {
            Debug.Log("HOOKED");

            hook = true;
            other.gameObject.GetComponent<hook>().isHooked = true;

        }

    }
}
