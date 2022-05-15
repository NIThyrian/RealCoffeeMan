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
        damage = difficultyFactor * 5;
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
