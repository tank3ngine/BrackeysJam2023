using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Obstacle", menuName = "Obstacle")]
public class Obstacle : ScriptableObject
{
    // Start is called before the first frame update

    public new string name;
    public Sprite sprite;
    public int laneSize;
    public float speed;

    [Header("Type of Collider")]
    public bool circleCollider;
    public bool boxCollider;

    public float colliderSize;
}
