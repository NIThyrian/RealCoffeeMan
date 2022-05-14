using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MeleeEnemy : MonoBehaviour
{
    private AIPath aiPath;
    //private Game game;
    private AIDestinationSetter aiDest;
    private float range;
    private float shootInterval;
    // Start is called before the first frame update

    void Start()
    {
        aiPath = GetComponent<AIPath>();
        aiDest = GetComponent<AIDestinationSetter>();
        aiDest.target = GameObject.FindGameObjectWithTag("Player").transform;
        float difficultyFactor = 1.25f;
        range = 1f;
        shootInterval = 2f / difficultyFactor;
        // On veut que le range puisse tirer avant d'etre a sa distance maximale
        aiPath.endReachedDistance = range;
        aiPath.maxSpeed = 2f * difficultyFactor;
        aiPath.slowdownDistance = 2 * aiPath.endReachedDistance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
