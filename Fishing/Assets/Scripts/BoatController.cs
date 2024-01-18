using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatController : MonoBehaviour
{

    public static BoatController instance;

    //The rigidbody variable
    public Rigidbody rb;

    public float baseMoveSpeed = 12;
    public float moveSpeed;
    public float turnSpeed;
    [SerializeField]
    private float moveInputValue;
    private float turnInputValue;
    public LayerMask collisionLayer;
    public string fishingSceneName1;
    public string fishingSceneName2;
    public string fishingSceneName3;

    public bool lvlTwo;
    public bool lvlThree;
    public GameObject levelOneBoat;
    public GameObject levelTwoBoat;
    public GameObject levelThreeBoat;
    public AudioSource boatMovementSound;

    public bool canShop;
    public bool canFish1;
    public bool canfish2;
        public bool canfish3;

    public GameObject shop;
    public GameObject inv;
    public GameObject money;
    public bool invOn;
    public bool shopOn;

    public GameObject upgradeButtonLv2;
    public GameObject upgradeButtonLv3;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }


    void Update()
    {



        if (Input.GetButtonDown("Submit") && shopOn)
        {
            invOn = false;
            inv.SetActive(false);
            shop.SetActive(false);
            shopOn = false;
            money.SetActive(true);
        }

        else if (canFish1 && Input.GetButtonDown("Submit") && invOn == false && shopOn == false && (levelOneBoat.activeSelf || levelTwoBoat.activeSelf || levelThreeBoat.activeSelf)

)
        {
            SceneManager.LoadScene(fishingSceneName1);
        }
        else if (canfish2 && Input.GetButtonDown("Submit") && invOn == false && shopOn == false && (levelTwoBoat.activeSelf || levelThreeBoat.activeSelf))
        {
            SceneManager.LoadScene(fishingSceneName2);
        }
        else if (canfish3 && Input.GetButtonDown("Submit") && invOn == false && shopOn == false && (levelThreeBoat.activeSelf))
        {
            SceneManager.LoadScene(fishingSceneName3);
        }

        else if (canShop && Input.GetButtonDown("Submit") && invOn == false && shopOn == false)
        {
            invOn = false;
            shopOn = true;
            shop.SetActive(true);
            inv.SetActive(false);
            money.SetActive(true);
        }
        else if (Input.GetButtonDown("Submit") && shopOn == false)
        {
            invOn = false;
            inv.SetActive(false);
            shop.SetActive(false);
            shopOn = false;
            money.SetActive(true);
        }

        //if (Input.GetKeyDown("1"))
        //{
        //    LevelTwo();
        //}
        //if (Input.GetKeyDown("2"))
        //{
        //    LevelThree();
        //}
        moveInputValue = Input.GetAxis("Vertical");
        turnInputValue = Input.GetAxis("Horizontal");
        if (moveInputValue <= 0)
        {
            //moveInputValue = 0;
            moveSpeed = 6;
        }
        if (moveInputValue >= 0)
        {
                moveSpeed = baseMoveSpeed;
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

        if (moveInputValue != 0)
        {

            boatMovementSound.volume = Mathf.Abs(moveInputValue);
            boatMovementSound.pitch = 1f + moveInputValue;

            boatMovementSound.Play();
        }
        

        else if (boatMovementSound.isPlaying)
        {
            boatMovementSound.Stop();
        }

    }

    private void Turn()
    {
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hotspot1"))
        {
            canFish1 = true;
        }
        if (other.gameObject.CompareTag("hotspot2"))
        {
            canfish2 = true;
        }
        if (other.gameObject.CompareTag("hotspot3"))
        {
            canfish3 = true;
        }

        if (other.gameObject.CompareTag("dock"))
        {
            canShop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("hotspot1"))
        {
            canFish1 = false;
        }
        if (other.gameObject.CompareTag("hotspot2"))
        {
            canfish2 = false;
        }
        if (other.gameObject.CompareTag("hotspot3"))
        {
            canfish3 = false;
        }

        if (other.gameObject.CompareTag("dock"))
        {
            canShop = false;
        }
    }

    public void LevelTwo()
    {
        //if player inventory money >= 100 

        PlayerInventory playerInventoryScript = FindObjectOfType<PlayerInventory>();
        if (playerInventoryScript.money >= 100)
        {
        levelOneBoat.SetActive(false);
        levelTwoBoat.SetActive(true);
        baseMoveSpeed = 17;
        collisionLayer &= ~(1 << LayerMask.NameToLayer("LVL2"));
            playerInventoryScript.money -= 100;
            upgradeButtonLv2.SetActive(false);

        }


        //decrease money by 100
    }

    public void LevelThree()
    {
        //if player inventory money >=500

        PlayerInventory playerInventoryScript = FindObjectOfType<PlayerInventory>();
        if (playerInventoryScript.money >= 500)
        {
            baseMoveSpeed = 20;
        levelTwoBoat.SetActive(false);
        levelOneBoat.SetActive(false);
        levelThreeBoat.SetActive(true);
        collisionLayer &= ~(1 << LayerMask.NameToLayer("LVL3"));

            playerInventoryScript.money -= 500;
            upgradeButtonLv3.SetActive(false);
        }


        //decrease money by 500
    }
}
