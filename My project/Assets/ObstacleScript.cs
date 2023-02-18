using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] public Obstacle obsIdentity;
    [SerializeField] public int spawnNum;
    [SerializeField] public int laneNum;
    [SerializeField] public bool startFalse;
    private GameObject ObsSpawner;
    private ObstacleSpawnerScript ObsSpawnerScript;


    [SerializeField] private SpriteRenderer SR;


    [SerializeField] private GameObject singleLaneObj;
    [SerializeField] private GameObject doubleLaneObj;
    [SerializeField] private GameObject tripleLaneObj;

    // Start is called before the first frame update

    void Start()
    {
        ObsSpawner = GameObject.FindGameObjectWithTag("ObsSpawner");
        ObsSpawnerScript = ObsSpawner.GetComponent<ObstacleSpawnerScript>();
        name = obsIdentity.name;// + "_" + spawnNum;
        transform.localScale = new Vector3(0, 0, 0);

        singleLaneObj.SetActive(false);
        doubleLaneObj.SetActive(false);
        tripleLaneObj.SetActive(false);

        if (obsIdentity.laneSize == 1)
        {
            singleLaneObj.GetComponent<SpriteRenderer>().sprite = obsIdentity.sprite;
            singleLaneObj.SetActive(true);
        }
        if (obsIdentity.laneSize == 2)
        {
            doubleLaneObj.SetActive(true);
            doubleLaneObj.GetComponent<SpriteRenderer>().sprite = obsIdentity.sprite;
            //doubleLaneObj.transform.position = new Vector3(0.5f, transform.position.y);
            if (laneNum == ObsSpawnerScript.SpawnLocations.Length - 1)
            {
                transform.position = ObsSpawnerScript.SpawnLocations[5].transform.position;
            }
            
        }
        if (obsIdentity.laneSize == 3)
        {
            tripleLaneObj.GetComponent<SpriteRenderer>().sprite = obsIdentity.sprite;
            tripleLaneObj.SetActive(true);
            if (laneNum == 0)
            {
                transform.position = ObsSpawnerScript.SpawnLocations[1].transform.position;
            }
            if (laneNum == 6)
            {
                transform.position = ObsSpawnerScript.SpawnLocations[5].transform.position;
            }
        }
        if (startFalse)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.gameObject == null)
        {
            Debug.Log("Transform not found");
            return;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + obsIdentity.speed * Time.deltaTime);
        if (transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(0 + 0.05f, 0 + 0.05f, 0 + 0.05f);
        }
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}
