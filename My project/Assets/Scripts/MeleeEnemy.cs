using UnityEngine;
using Pathfinding;

public class MeleeEnemy : Enemy
{
    private void Start() {
        GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Player").transform;
        float difficultyFactor = 1.25f;
        float range = 1f;
        float shootInterval = 2f / difficultyFactor;

        // On veut que le range puisse tirer avant d'etre a sa distance maximale
        AIPath aiPath = GetComponent<AIPath>();
        aiPath.endReachedDistance = range;
        aiPath.maxSpeed = 2f * difficultyFactor;
        aiPath.slowdownDistance = 2 * aiPath.endReachedDistance;
    }
}
