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
    public float maxWaterGravity;
    



    // Start is called before the first frame update
    void Start()
    {
        waterGravity = waterGravity * 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
            {
            SceneManager.LoadScene("SampleScene");
            Debug.Log("Load Scene");
            }
       
    }
    private void FixedUpdate()
    {
        if (inWater)
        {
            rb.AddForce(0, -waterGravity * Time.deltaTime, 0);
        }
        else { }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == watercollider)
        {
            //Debug.Log("in water");
            inWater = true;

            rb.AddForce(0, waterGravity, 0);


        }
    }

    private void OnCollisionExit(Collision collision)
    {
        inWater = false;
    }


}
