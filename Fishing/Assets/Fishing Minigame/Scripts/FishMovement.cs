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
        if (Input.GetKey(KeyCode.R) && hooked)
        {
            hook = false;
            hooked = false;
            transform.position =  new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
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

        if (other.gameObject.tag == "wall")
        {
            speed = speed * -1;
            Debug.Log("swtich directions");
        }

    }
}
