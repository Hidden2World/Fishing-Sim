using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatController : MonoBehaviour
{

    public static BoatController instance;

    //The rigidbody variable
    public Rigidbody rb;

    public float moveSpeed = 12;
    public float turnSpeed;
    [SerializeField]
    private float moveInputValue;
    private float turnInputValue;
    public LayerMask collisionLayer;
    public string fishingSceneName;
    public bool lvlTwo;
    public bool lvlThree;

    public GameObject shop;
    public GameObject inv;
    public GameObject money;
    public bool invOn;
    public bool shopOn;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }


    void Update()
    {
        //When you reach level two the bool is activated which triggers this script to remove a layer from the collision layermask
        if (lvlTwo)
        {
            collisionLayer &= ~(1 << LayerMask.NameToLayer("LVL2"));
        }
        //When you reach level three the bool is activated which triggers this script to remove a layer from the collision layermask
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

        if (Input.GetKeyDown("i") && invOn == false)
        {
            shopOn = false;
            invOn = true;
            inv.SetActive(true);
            shop.SetActive(false);
            money.SetActive(true);
        }
        else if (Input.GetKeyDown("i") && invOn)
        {
            invOn = false;
            inv.SetActive(false);
            money.SetActive(false);
            shop.SetActive(false);
        }

        if (shopOn && Input.GetKeyDown("escape"))
        {
            shopOn = false;
            shop.SetActive(false);
            money.SetActive(false);
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
            if (Input.GetButtonDown("Submit") && shopOn == false)
            {
                invOn = false;
                shopOn = true;
                shop.SetActive(true);
                inv.SetActive(false);
                money.SetActive(true);
            }
        }
    }
}
