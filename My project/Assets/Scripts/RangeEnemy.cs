using UnityEngine;
using Pathfinding;

public class RangeEnemy : MonoBehaviour
{
    public AIPath aiPath;
    //private Game game;
    private float range;
    private float shootInterval;

    // Start is called before the first frame update
    void Start()
    {
        aiPath = GetComponent<AIPath>();
        //game = GetComponentInParent<Game>();
        float difficultyFactor = 1.25f;
        range = 11f * difficultyFactor;
        shootInterval = 2f / difficultyFactor;
        // On veut que le range puisse tirer avant d'etre a sa distance maximale
        aiPath.endReachedDistance = range - 1f;
        aiPath.maxSpeed = 2f * difficultyFactor;
        aiPath.slowdownDistance = 2 * aiPath.endReachedDistance;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
