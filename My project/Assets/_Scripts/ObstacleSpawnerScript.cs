using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerScript : MonoBehaviour
{
    private GameObject GM;
    private GameManager GMScript;

    [SerializeField] private GameObject[] SpawnLocations;
    [SerializeField] private GameObject baseObsPrefab;

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

        for (int i = 0; i < targetSpawnCount; i++)
        {
            //var locationPicker = Random.Range(0, (SpawnLocations.Length - 1));
            var locationPicker = Random.Range(0, SpawnLocations.Length);//todo might need to -1 the length
            //Spawn a basic obstacle object
            GameObject baseObj= Instantiate(baseObsPrefab, SpawnLocations[locationPicker].transform.position, Quaternion.identity, SpawnLocations[locationPicker].transform);
            var objScript = GetComponent<ObstacleScript>();
            objScript.spawnNum = i;
            if (GMScript.currentRound == 1)
            {
                var typePicker = Random.Range(0, GMScript.round1_Obs.Length);
                objScript.obsIdentity = GMScript.round1_Obs[typePicker];
            }
            if (GMScript.currentRound == 2)
            {
                var typePicker = Random.Range(0, GMScript.round2_Obs.Length);
                objScript.obsIdentity = GMScript.round1_Obs[typePicker];
            }
            if (GMScript.currentRound == 3)
            {
                var typePicker = Random.Range(0, GMScript.round3_Obs.Length);
                objScript.obsIdentity = GMScript.round1_Obs[typePicker];
            }
        }
    }
}
