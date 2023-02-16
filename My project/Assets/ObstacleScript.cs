using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] Obstacle obsIdentity;
    [SerializeField] int spawnNum;
    // Start is called before the first frame update

    void Start()
    {
        name = obsIdentity.name + "_"+spawnNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
