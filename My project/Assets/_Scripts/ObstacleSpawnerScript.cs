using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerScript : MonoBehaviour
{
    private GameObject GM;
    private GameManager GMScript;

    [SerializeField] public GameObject[] SpawnLocations;
    [SerializeField] private GameObject baseObsPrefab;

    [SerializeField] private int spawnCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Get references to other scripts and gameobjects
        GM = GameObject.FindGameObjectWithTag("GameController");
        GMScript = GM.GetComponent<GameManager>();
        if (!GMScript.ContinuousSpawning)
        {
            calcSpawns();
        }

    }
    private void Update()
    {

    }
    public void KeepSpawning()
    {
        var locationPicker = Random.Range(0, SpawnLocations.Length);
        GameObject baseObj = Instantiate(baseObsPrefab, SpawnLocations[locationPicker].transform.position, Quaternion.identity, GMScript.ObstacleHolderObj.transform);

        var objScript = baseObj.GetComponent<ObstacleScript>();
        objScript.laneNum = locationPicker;

        if (GMScript.currentRound == 1)
        {
            var typePicker = Random.Range(0, GMScript.round1_Obs.Length);
            objScript.obsIdentity = GMScript.round1_Obs[typePicker];
        }
        if (GMScript.currentRound == 2)
        {
            var typePicker = Random.Range(0, GMScript.round2_Obs.Length);
            Debug.Log(typePicker);
            objScript.obsIdentity = GMScript.round2_Obs[typePicker];
        }
        if (GMScript.currentRound == 3)
        {
            var typePicker = Random.Range(0, GMScript.round3_Obs.Length);
            objScript.obsIdentity = GMScript.round3_Obs[typePicker];
        }
    }
    public void calcSpawns()
    {
        //The total number of obstacles to spawn for this round
        int targetSpawnCount = GMScript.NumObstacles();
        Debug.Log(GMScript.currentRound);

        for (int i = 0; i < targetSpawnCount; i++)
        {
            //var locationPicker = Random.Range(0, (SpawnLocations.Length - 1));
            var locationPicker = Random.Range(0, SpawnLocations.Length);//todo might need to -1 the length
            //Spawn a basic obstacle object
            GameObject baseObj= Instantiate(baseObsPrefab, SpawnLocations[locationPicker].transform.position, Quaternion.identity, GMScript.ObstacleHolderObj.transform);
            
            //Write some information to the basic obstacle, like it's spawn order and which lane it is in
            var objScript = baseObj.GetComponent<ObstacleScript>();
            objScript.spawnNum = i;
            objScript.laneNum = locationPicker;

            GMScript.ObstaclesInRound.Add(baseObj);

            //Depending on which round it is in, choose which scriptable objects to use from an array
            if (GMScript.currentRound == 1)
            {
                var typePicker = Random.Range(0, GMScript.round1_Obs.Length-1);
                objScript.obsIdentity = GMScript.round1_Obs[typePicker];
            }
            if (GMScript.currentRound == 2)
            {
                var typePicker = Random.Range(0, GMScript.round2_Obs.Length-1);
                objScript.obsIdentity = GMScript.round2_Obs[typePicker];
            }
            if (GMScript.currentRound == 3)
            {
                var typePicker = Random.Range(0, GMScript.round3_Obs.Length-1);
                objScript.obsIdentity = GMScript.round3_Obs[typePicker];
            }
        }
    }
}
