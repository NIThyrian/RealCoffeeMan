using System;
using UnityEngine;
using Pathfinding;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    protected AIPath aiPath;
    protected AIDestinationSetter aiDest;
    protected float range;
    protected float shootInterval;

    protected void SetupPathfinding()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        aiPath = GetComponent<AIPath>();
        aiDest = GetComponent<AIDestinationSetter>();
        // aiDest.target = player.transform;

        //game = GetComponentInParent<Game>();
    }

}
