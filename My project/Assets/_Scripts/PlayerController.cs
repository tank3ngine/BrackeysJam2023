using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject GM;
    private GameManager GMScript;
    private SpriteRenderer SR;
    private CircleCollider2D CC2D;

    [Header("Player Lane Variabes")]
    [SerializeField] private int currentLane;
    [SerializeField] private int startLane;

    [Header("Player Movement Variables")]
    [SerializeField] private float vSpeed;
    [SerializeField] private float hSpeed;
    [SerializeField] private float laneSwitchInterval;
    [SerializeField] private float switchTimer;
    [SerializeField] private GameObject bounceBacker;
    [SerializeField] private float bounceSpeed;

    [Header("Player Movement checking")]
    [SerializeField] private bool isMoving;
    [SerializeField] private bool isMovingRight;
    [SerializeField] private bool isMovingLeft;

    // Start is called before the first frame update
    void Start()
    {
        //Component references
        SR = transform.GetComponent<SpriteRenderer>();
        CC2D = transform.GetComponent<CircleCollider2D>();

        //Game Manager references
        GM = GameObject.FindGameObjectWithTag("GameController");
        GMScript = GM.GetComponent<GameManager>();

        //bouncebacker references
        bounceBacker = GameObject.Find("BounceBack");

        //get the starting lane from the game manager and spawn start the player in that lane (3) at it's transform.position
        startLane = GMScript.startLane;
        transform.position = GMScript.AllLanes[startLane].transform.position;
        //set the current lane to the starting lane
        currentLane = startLane;
    }



    // Update is called once per frame
    void Update()
    {
        bounceBacker.transform.position = new Vector3(transform.position.x, bounceBacker.transform.position.y, bounceBacker.transform.position.z);
        #region Vertical Movement
        float verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetAxisRaw("Vertical") == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, bounceBacker.transform.position, bounceSpeed*Time.deltaTime);            
        }

        if (verticalInput != 0)
        {
            if (verticalInput < 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - (vSpeed*Time.deltaTime), transform.position.z);

            }
            if (verticalInput > 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + (vSpeed * Time.deltaTime), transform.position.z);
            }
        }
        #endregion

        #region Horizontal Movement
        //Timer that determines how fast player can switch lanes
        if (switchTimer > 0)
        {
            switchTimer -= Time.deltaTime;
        }
        if (switchTimer <= 0)
        {
            switchTimer = 0;
        }

        //Horizontal Movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (switchTimer <= 0)
        {
            if (horizontalInput == 0)
            {
                return;
            }

            if (currentLane != 0 && horizontalInput < 0 && !isMovingRight)
            {
                isMovingLeft = true;
            }

            if (currentLane != (GMScript.AllLanes.Length - 1) && horizontalInput > 0 && !isMovingLeft)
            {
                isMovingRight = true;
            }

            else
            {
                Debug.Log("Can't move this way");
            }
        }       
        
        if (isMovingLeft)
        {
            MoveLeft();            
        }

        if (isMovingRight)
        {
            MoveRight();
        }
        #endregion
    }
    private void MoveLeft()
    {
        transform.position = new Vector3(transform.position.x - hSpeed, transform.position.y, transform.position.z);

        int newLane = currentLane - 1;
        float newLanePositionx = GMScript.AllLanes[newLane].transform.position.x;
        if (transform.position.x - newLanePositionx <= 0)
        {
            isMovingLeft = false;
            transform.position = new Vector3(newLanePositionx, transform.position.y, transform.position.z);
            currentLane = newLane;
            switchTimer = laneSwitchInterval;
            Debug.Log("Move Left");
        }
    }
    private void MoveRight()
    {
        transform.position = new Vector3(transform.position.x + hSpeed, transform.position.y, transform.position.z);

        int newLane = currentLane + 1;
        float newLanePositionx = GMScript.AllLanes[newLane].transform.position.x;

        //doesn't work, movement is broken
        //transform.position = Vector3.MoveTowards(transform.position, GMScript.AllLanes[newLane].transform.position, hSpeed * Time.deltaTime);
        
        if (newLanePositionx - transform.position.x <= 0)
        {
            isMovingRight = false;
            transform.position = new Vector3(newLanePositionx, transform.position.y, transform.position.z);
            currentLane = newLane;
            switchTimer = laneSwitchInterval;
            Debug.Log("Move Right");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger!");
        if (collision.CompareTag("Pain"))
        {
            Debug.Log("Player hit");
            GMScript.PlayerHit();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (gameObject.CompareTag("Pain"))
        {
            Debug.Log("Player hit");
            GMScript.PlayerHit();
        }

        if (gameObject.CompareTag("Coin"))
        {

        }
    }
}
