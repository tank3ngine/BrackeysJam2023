using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerScript : MonoBehaviour
{
    private GameObject GM;
    private GameManager GMScript;

    [SerializeField] private GameObject[] SpawnLocations;

    [SerializeField] private int spawnCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Get references to other scripts and gameobjects
        GM = GameObject.FindGameObjectWithTag("GameController");
        GMScript = GM.GetComponent<GameManager>();
        calcSpawns();
    }
    private void Update()
    {

    }

    public void calcSpawns()
    {
        //The total number of obstacles to spawn for this round
        int targetSpawnCount = GMScript.NumObstacles();
        Debug.Log(GMScript.currentRound);
        if (GMScript.currentRound == 1)
        {
            for (int i = 0; i < targetSpawnCount; i++)
            {
                var typePicker = Random.Range(0, GMScript.round1_Obs.Length);
                Debug.Log(typePicker);
                //var locationPicker = Random.Range(0, (SpawnLocations.Length - 1));
                var locationPicker = Random.Range(0, SpawnLocations.Length);//todo might need to -1 the length

                GameObject obj = Instantiate(GMScript.round1_Obs[typePicker], SpawnLocations[locationPicker].transform.position, Quaternion.identity, SpawnLocations[locationPicker].transform);

                obj.name = "Obstacle " + i.ToString();
                //obj.transform.position = SpawnLocations[locationPicker].transform.position;
                //work todo on obstacles that cover multiple lanes
            }
        }

        if (GMScript.currentRound == 2)
        {
            for (int i = 0; i < targetSpawnCount; i++)
            {
                var picker = Random.Range(0, (GMScript.round2_Obs.Length - 1));
                GameObject obj = Instantiate(GMScript.round2_Obs[picker]);
                obj.name = "Obstacle " + i.ToString();
            }
        }

        if (GMScript.currentRound == 3)
        {
            for (int i = 0; i < targetSpawnCount; i++)
            {
                var typePicker = Random.Range(0, (GMScript.round3_Obs.Length - 1));
                Debug.Log(typePicker);
                //var locationPicker = Random.Range(0, (SpawnLocations.Length - 1));
                var locationPicker = Random.Range(0, (SpawnLocations.Length - 1));

                GameObject obj = Instantiate(GMScript.round3_Obs[typePicker]);
                obj.name = "Obstacle " + i.ToString();
                obj.transform.position = SpawnLocations[locationPicker].transform.position;
                //work todo on obstacles that cover multiple lanes
            }
        }
    }
}
