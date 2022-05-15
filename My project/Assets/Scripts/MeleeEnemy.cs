using UnityEngine;
using Pathfinding;

public class MeleeEnemy : Enemy
{

    // Start is called before the first frame update
    void Start()
    {
        Setup();
        SetupPathfinding();
        SetupDifficulty(4f);

    }

    void Update()
    {
        UpdateState();
        ApplyState();
    }


    protected override void Chase()
    {
    }

    protected override void Attack()
    {

    }
}
