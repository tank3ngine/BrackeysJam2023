using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] public Obstacle obsIdentity;
    [SerializeField] public int spawnNum;
    [SerializeField] public int laneNum;
    [SerializeField] public bool startFalse;


    [SerializeField] private SpriteRenderer SR;


    [SerializeField] private GameObject singleLaneObj;
    [SerializeField] private GameObject doubleLaneObj;
    [SerializeField] private GameObject tripleLaneObj;

    // Start is called before the first frame update

    void Start()
    {
        name = obsIdentity.name + "_" + spawnNum;

        if (obsIdentity.laneSize == 1)
        {
            singleLaneObj.GetComponent<SpriteRenderer>().sprite = obsIdentity.sprite;
            singleLaneObj.SetActive(true);
        }
        if (obsIdentity.laneSize == 2)
        {
            doubleLaneObj.GetComponent<SpriteRenderer>().sprite = obsIdentity.sprite;
            if (laneNum == 0)
            {
                singleLaneObj.transform.position = new Vector3(0.5f, transform.position.y);
            }
            if (laneNum == 6)
            {
                singleLaneObj.transform.position = new Vector3(-0.5f, transform.position.y);
            }
            doubleLaneObj.SetActive(true);
        }
        if (obsIdentity.laneSize == 3)
        {
            tripleLaneObj.GetComponent<SpriteRenderer>().sprite = obsIdentity.sprite;
            if (laneNum == 0)
            {
                singleLaneObj.transform.position = new Vector3(1, transform.position.y);
            }
            if (laneNum == 6)
            {
                singleLaneObj.transform.position = new Vector3(-1f, transform.position.y);
            }
            tripleLaneObj.SetActive(true);
        }
        if (startFalse)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + obsIdentity.speed * Time.deltaTime);
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}
