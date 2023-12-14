using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatController : MonoBehaviour
{

    public Rigidbody rb;
    public float moveSpeed = 12;
    public float turnSpeed;
    [SerializeField]
    private float moveInputValue;
    private float turnInputValue;
    public LayerMask collisionLayer;
    public string fishingSceneName;
    public bool lvlOne;
    public bool lvlTwo;
    public bool lvlThree;

    void Start()
    {
        
    }


    void Update()
    {
        if (lvlTwo)
        {
            collisionLayer &= ~(1 << LayerMask.NameToLayer("LVL2"));
        }
        if (lvlThree)
        {
            collisionLayer &= ~(1 << LayerMask.NameToLayer("LVL3"));
        }
        moveInputValue = Input.GetAxis("Vertical");
        turnInputValue = Input.GetAxis("Horizontal");
        if (moveInputValue <= 0)
        {
            //moveInputValue = 0;
            moveSpeed = 6;
        }
        if (moveInputValue >= 0)
        {
                moveSpeed = 12;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 direction = transform.forward * moveInputValue;
        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, 9, collisionLayer)) 
        {
            return;
        }
        else
        {
            Vector3 movement = transform.forward * moveInputValue * moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
        }
    }

    private void Turn()
    {
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("hotspot"))
        {
            if (Input.GetButtonDown("Submit")) 
            {
                SceneManager.LoadScene(fishingSceneName);
            }
        }
        else if (other.gameObject.CompareTag("dock"))
        {
            
        }
    }
}
