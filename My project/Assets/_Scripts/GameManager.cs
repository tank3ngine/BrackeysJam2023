using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] public GameObject _NavLanes;
    [SerializeField] public GameObject[] AllLanes;

    [SerializeField] private GameObject ObstacleSpawner;
    private ObstacleSpawnerScript OSScript;

    [Header("Obstacle information holder (scrpObj)")]
    [SerializeField] public Obstacle[] round1_Obs;
    [SerializeField] public Obstacle[] round2_Obs;
    [SerializeField] public Obstacle[] round3_Obs;

    [Header("Background Sprites")]
    [SerializeField] public GameObject TartarusBG;
    [SerializeField] public GameObject AsphodelBG;
    [SerializeField] public GameObject ElysiumBG;

    [Header("Obstacles in round")]
    [SerializeField] public GameObject ObstacleHolderObj;
    [SerializeField] public List<GameObject> ObstaclesInRound = new List<GameObject>();
    
    [Header("Coin Objects")]
    [SerializeField] public GameObject coinHolder;
    [SerializeField] private TMP_Text coinUi;

    [Header("Round information")]
    [SerializeField] public bool ContinuousSpawning;
    [SerializeField] public int coinRequirement;
    [SerializeField] public int coinsCollected;

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
        
        roundDuration = CalcRoundDuration();
        obstacleTimer = 4f;

        if(currentRound == 1)
        {
            TartarusBG.SetActive(true);
        }
        if(currentRound == 2)
        {
            AsphodelBG.SetActive(true);
        }
        if(currentRound == 3)
        {
            ElysiumBG.SetActive(true);
        }

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

    public void CoinCollected(string coinType)
    {
        if (coinType == "Bronze")
        {
            coinsCollected += 1;
            updateCoinUi(1);
        }
        if (coinType == "Silver")
        {
            coinsCollected += 2;
            updateCoinUi(2);
        }
        if (coinType == "Gold")
        {
            coinsCollected += 3;
            updateCoinUi(3);
        }



        if (coinsCollected >= coinRequirement)
        {
            LevelCompelete();
        }
    }
    public void updateCoinUi(int type)
    {

        coinUi.text = coinsCollected + "/" + coinRequirement;
    }

    public void LevelCompelete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
