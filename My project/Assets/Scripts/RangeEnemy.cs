using UnityEngine;
using Pathfinding;
using System.Collections;

public class RangeEnemy : Enemy
{

    public EnemyBullet weapon;
    public float bulletSpeed = 100.0f;
    private SpawnPoint spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GetComponentInChildren<SpawnPoint>();
        Setup();
        SetupPathfinding();
        SetupDifficulty(40.0f);
        damage = (int) (difficultyFactor * 2);
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
        var pos = player.GetComponent<Collider>().bounds.center;
        Vector3 direction = (pos - spawnPoint.transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    public void SpawnWeapon()
    {
        var pos = player.GetComponent<Collider>().bounds.center - new Vector3(0, 6, 0);
        Vector3 direction = (pos - transform.position).normalized;
        EnemyBullet bullet = Instantiate(weapon, spawnPoint.transform.position, rb.rotation);
        bullet.tag = "EnemyBullet";
        bullet.damage = damage;
        bullet.GetComponent<Rigidbody>().velocity += direction * bulletSpeed;

    }

}
