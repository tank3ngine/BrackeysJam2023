using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject _NavLanes;
    [SerializeField] public GameObject[] AllLanes;

    [SerializeField] private GameObject ObstacleSpawner;
    [SerializeField] private ObstacleSpawnerScript OSScript;
    [SerializeField] public GameObject[] round1_Obs;
    [SerializeField] public GameObject[] round2_Obs;
    [SerializeField] public GameObject[] round3_Obs;

    [SerializeField] public int startLane = 3;

    [SerializeField] public float roundDuration;
    [SerializeField] public int currentRound;
    [SerializeField] public float obstacleSpawnInterval;

    

    // Start is called before the first frame update
    void Start()
    {
        OSScript = ObstacleSpawner.GetComponent<ObstacleSpawnerScript>();
        currentRound = SceneManager.GetActiveScene().buildIndex;
        roundDuration = CalcRoundDuration();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void Checkpoint()
    {

    }
}
