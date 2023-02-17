using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] public Obstacle obsIdentity;
    [SerializeField] public int spawnNum;
    [SerializeField] public int laneNum;

    [SerializeField] private SpriteRenderer SR;


    [SerializeField] private GameObject singleLaneObj;
    [SerializeField] private GameObject doubleLaneObj;
    [SerializeField] private GameObject tripleLaneObj;

    // Start is called before the first frame update

    void Start()
    {
        name = obsIdentity.name + "_" + spawnNum;

        SR.sprite = obsIdentity.sprite;

        if (obsIdentity.laneSize == 1)
        {
            singleLaneObj.SetActive(true);
        }
        if (obsIdentity.laneSize == 2)
        {
            doubleLaneObj.SetActive(true);
        }
        if (obsIdentity.laneSize == 3)
        {
            tripleLaneObj.SetActive(true);
        }




        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
