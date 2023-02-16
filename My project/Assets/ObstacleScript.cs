using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] public Obstacle obsIdentity;
    [SerializeField] public int spawnNum;

    [SerializeField] private CapsuleCollider2D singleLaneCC;
    [SerializeField] private CapsuleCollider2D doubleLaneCC;
    [SerializeField] private CapsuleCollider2D tripleLaneCC;

    // Start is called before the first frame update

    void Start()
    {
        name = obsIdentity.name + "_" + spawnNum;








    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
