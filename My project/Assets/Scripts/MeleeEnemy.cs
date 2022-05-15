using UnityEngine;
using Pathfinding;

public class MeleeEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Setup();
        SetupPathfinding();
        SetupDifficulty(5f);
        damage = (int) (difficultyFactor * 5f);
    }

    void Update()
    {
        UpdateState();
        ApplyState();
    }

    protected override void Chase()
    {
    }

    public void AttackFront()
    {
        var dist = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log("Distance " + dist + " vs Range : " + range);
        if (dist <= range)
        {
            game.TakeDamage(damage);
        }
    }

    protected override void Attack()
    {
        var pos = player.GetComponent<Collider>().bounds.center;
        Vector3 direction = (pos - GetComponent<Collider>().bounds.center).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
