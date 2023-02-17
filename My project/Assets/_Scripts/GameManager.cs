using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public bool ContinuousSpawning;
    [SerializeField] public GameObject _NavLanes;
    [SerializeField] public GameObject[] AllLanes;

    [SerializeField] private GameObject ObstacleSpawner;
    private ObstacleSpawnerScript OSScript;

    [Header("Obstacle information holder (scrpObj)")]
    [SerializeField] public Obstacle[] round1_Obs;
    [SerializeField] public Obstacle[] round2_Obs;
    [SerializeField] public Obstacle[] round3_Obs;

    [Header("Background Sprites")]
    [SerializeField] public Sprite TartarusSprite;
    [SerializeField] public Sprite AsphodelSprite;
    [SerializeField] public Sprite ElysiumSprite;

    [Header("Obstacles in round")]
    [SerializeField] public GameObject ObstacleHolderObj;
    [SerializeField] public List<GameObject> ObstaclesInRound = new List<GameObject>();


    [Header("Round information")]
    [SerializeField] public int startLane = 3;

    [SerializeField] public float roundDuration;
    [SerializeField] public int currentRound;
    //obstacle spawning
    [SerializeField] public float obstacleSpawnInterval;
    [SerializeField] public float obstacleTimer;
    [SerializeField] public int spawnCounter = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        OSScript = ObstacleSpawner.GetComponent<ObstacleSpawnerScript>();
        currentRound = SceneManager.GetActiveScene().buildIndex;
        roundDuration = CalcRoundDuration();
        obstacleTimer = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (obstacleTimer > 0)
        {
            obstacleTimer -= Time.deltaTime;
        }
        else
        {
            if (!ContinuousSpawning)
            {
                ObstaclesInRound[spawnCounter].SetActive(true);
                spawnCounter++;
            }
            else
            {
                OSScript.KeepSpawning();
            }
            obstacleTimer = obstacleSpawnInterval;
        }
    }
    public int NumObstacles()
    {
        //Calculates the number of obstacles by checking the total 
        //round duration and dividing it by the spawn interval.
        int spawnCount = (int)Mathf.Floor(roundDuration / obstacleSpawnInterval);
        Debug.Log(spawnCount);
        return spawnCount;
    }
    public float CalcRoundDuration()
    {
        //Multiply the scene index by 30 seconds to get the total round duration.
        //edit 30f todo
        var time = currentRound * 30f;
        return time;
    }
    public void StartGame(float maxTime)
    {

    }

    public void PlayerHit()
    {
        SceneManager.LoadScene("FailScene");
    }

    public void Checkpoint()
    {

    }
}
