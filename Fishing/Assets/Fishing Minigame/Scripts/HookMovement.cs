using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HookMovement : MonoBehaviour
{
    public GameObject watercollider;
    public Rigidbody rb;
    public float waterGravity;
    public float aboveGravity;
    bool inWater;
    public float maxWaterGraivity;
    



    // Start is called before the first frame update
    void Start()
    {
        waterGravity = waterGravity * 10;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void FixedUpdate()
    {
        if (inWater)
        {
            rb.AddForce(0, -waterGravity * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == watercollider)
        {
            //Debug.Log("in water");
            inWater = true;
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        inWater = false;
    }


}
