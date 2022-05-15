using UnityEngine;
using Pathfinding;

public abstract class Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        Chasing,
        Attacking,
        Idle
    }

    [SerializeField] GameObject goldCoin;
    [SerializeField] GameObject caCoin;
    [SerializeField] GameObject notACubeCoin;
    [SerializeField] GameObject poopCoin;
    [SerializeField] GameObject rocketCoin;

    protected AIPath aiPath;
    protected AIDestinationSetter aiDest;
    protected GameObject player;
    protected Game game;
    protected Rigidbody rb;
    protected float range;
    protected int difficultyFactor;
    protected float shootInterval;
    public float health = 100f;
    protected Animator animator;
    public int damage = 1;

    public EnemyState state;

    protected void Setup()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    protected void SetupPathfinding()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        aiPath = GetComponent<AIPath>();
        aiDest = GetComponent<AIDestinationSetter>();
        game = GetComponentInParent<Game>();
        aiDest.target = player.transform;
    }

    protected void SetupDifficulty(float rangeToStopFromPlayer)
    {
        difficultyFactor = game.difficultyFactor;
        range = rangeToStopFromPlayer;
        shootInterval = difficultyFactor;
        animator.speed = difficultyFactor * 0.5f + 0.5f;
        health = difficultyFactor * 2 + 25;

        aiPath.endReachedDistance = range;
        aiPath.maxSpeed = 10f * difficultyFactor;
        aiPath.slowdownDistance = 0;
        OnStartedIdle();
        state = EnemyState.Idle;
    }

    protected void UpdateState()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= range)
        {
            if (state != EnemyState.Attacking)
                OnStartedAttacking();
            state = EnemyState.Attacking;
        } else
        {
            if (state != EnemyState.Chasing)
                OnStartedChasing();
            state = EnemyState.Chasing;
        }

    }

    protected void ApplyState()
    {

        switch (state)
        {
            case EnemyState.Chasing:
                Chase();
                return;
            case EnemyState.Attacking:
                Attack();
                return;
            default:
                return;
        }
    }

    protected abstract void Chase();
    protected abstract void Attack();

    protected virtual void OnStartedChasing()
    {
        animator.SetInteger("state", (int)EnemyState.Chasing);

    }
    protected virtual void OnStartedAttacking()
    {
        animator.SetInteger("state", (int)EnemyState.Attacking);
    }

    protected virtual void OnStartedIdle()
    {
        animator.SetInteger("state", (int)EnemyState.Idle);
    }


    public void Die()
    {
        int randCa = UnityEngine.Random.Range(1, 100);
        int randGold = UnityEngine.Random.Range(1, 100);
        int randNotACube = UnityEngine.Random.Range(1, 100);
        int randPoop = UnityEngine.Random.Range(1, 100);
        int randRocket = UnityEngine.Random.Range(1, 100);
        int max = Mathf.Max(randCa, randGold, randNotACube, randPoop, randRocket);

        if(max == randCa) Instantiate(caCoin, transform.position + caCoin.transform.position, Quaternion.identity);
        else if(max == randGold) Instantiate(goldCoin, transform.position + goldCoin.transform.position, Quaternion.identity);
        else if(max == randNotACube) Instantiate(notACubeCoin, transform.position + notACubeCoin.transform.position, Quaternion.identity);
        else if(max == randPoop) Instantiate(poopCoin, transform.position + poopCoin.transform.position, Quaternion.identity);
        else if(max == randRocket) Instantiate(rocketCoin, transform.position + rocketCoin.transform.position, Quaternion.identity);
        
        Destroy(gameObject);
    }
}
