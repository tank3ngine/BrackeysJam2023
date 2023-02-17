using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject GM;
    private GameManager GMScript;

    [Header("Player Variables")]
    [SerializeField] private bool jumpToLane;
    [SerializeField] private int currentLane;
    [SerializeField] public int startLane;
    [SerializeField] public float vSpeed;
    [SerializeField] public float hSpeed;
    [SerializeField] public float laneSwitchInterval;
    [SerializeField] public float switchTimer;

    [SerializeField] public bool isMoving;
    [SerializeField] public bool isMovingRight;
    [SerializeField] public bool isMovingLeft;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameController");
        GMScript = GM.GetComponent<GameManager>();

        //get the starting lane from the game manager and spawn start the player in that lane (3) at it's transform.position
        startLane = GMScript.startLane;
        transform.position = GMScript.AllLanes[startLane].transform.position;
        //set the current lane to the starting lane
        currentLane = startLane;
    }



    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");

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

        if (switchTimer > 0)
        {
            switchTimer -= Time.deltaTime;
        }
        if (switchTimer <= 0)
        {
            switchTimer = 0;
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (switchTimer <= 0 && !isMoving)
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
        if (newLanePositionx - transform.position.x <= 0)
        {
            isMovingRight = false;
            transform.position = new Vector3(newLanePositionx, transform.position.y, transform.position.z);
            currentLane = newLane;
            switchTimer = laneSwitchInterval;
            Debug.Log("Move Left");
        }
    }
    private void MoveUpdate(float hInput)
    {
        if (hInput == 0)
        {
            return;
        }

        if (currentLane != 0 && hInput < 0)
        {
            isMoving = true;
            int newLane = currentLane - 1;
            var newLanePosition = GMScript.AllLanes[newLane].transform.position;

            

            //transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
            if (transform.position.x - newLanePosition.x <= 0)
            {
                currentLane = newLane;
                switchTimer = laneSwitchInterval;
                Debug.Log("Move Left");
            }
        }

        if (currentLane != (GMScript.AllLanes.Length - 1) && hInput > 0)
        {
            isMoving = true;
            int newLane = currentLane + 1;
            var newLanePosition = GMScript.AllLanes[newLane].transform.position.x;

            //transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);


            if (newLanePosition - transform.position.x <= 0)
            {
                currentLane = newLane;
                switchTimer = laneSwitchInterval;
                Debug.Log("Move Left");
            }
        }

        else
        {
            Debug.Log("Can't move");
        }
    }

    private int JumpLeft(float hInput)
    {
        
        if (currentLane != 0 && hInput < 0)
        {
            int newLane = currentLane - 1;
            var newLanePosition = GMScript.AllLanes[newLane].transform.position;

            transform.position = newLanePosition;

            currentLane = newLane;
            switchTimer = laneSwitchInterval;
            Debug.Log("Move Left");            

            return newLane;
        }

        if (currentLane != (GMScript.AllLanes.Length - 1) && hInput > 0)
        {
            int newLane = currentLane + 1;
            var newLanePosition = GMScript.AllLanes[newLane].transform.position;

            transform.position = newLanePosition;

            currentLane = newLane;
            switchTimer = laneSwitchInterval;
            Debug.Log("Move Right");
            return newLane;
        }

        else
        {
            Debug.Log("Can't move");
            return currentLane;
        }
    }
}
