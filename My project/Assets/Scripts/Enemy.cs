using UnityEngine;
using Pathfinding;
using System.Collections.Generic;

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
    protected SkinnedMeshRenderer mesh;
    protected float range;
    protected int difficultyFactor;
    protected float shootInterval;
    public float health = 100f;
    protected Animator animator;
    public float damage = 1f;
    public float startFollowDistance = 60f;
    public EnemyState state;
    private bool hit = false;
    private float elapsedHit = 0f;
    private List<Color> savedColor = new List<Color>();

    protected void Setup()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
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
        health = difficultyFactor * 2 + 50;
        aiPath.canMove = false;
        aiPath.endReachedDistance = range;
        aiPath.maxSpeed = 10f + 2* difficultyFactor;
        aiPath.slowdownDistance = 0;
        OnStartedIdle();
        state = EnemyState.Idle;
    }

    protected void UpdateHitVibe(float dt)
    {
        if (hit)
        {

            elapsedHit += dt;
            
            if (elapsedHit > 0.25f)
            {
                hit = false;
                elapsedHit = 0f;
                for(int i = 0; i < mesh.materials.Length; i++)
                {
                    Material mat = mesh.materials[i];
                    mat.color = savedColor[i];
                }
            }
        }
    }

    protected void UpdateState()
    {
        float playerDistance = (Vector3.Distance(player.transform.position, transform.position));

        if (playerDistance <= range)
        {
            if (state != EnemyState.Attacking)
                OnStartedAttacking();
            state = EnemyState.Attacking;
        } else if(playerDistance < startFollowDistance)
        {
            aiPath.canMove = true;
            if (state != EnemyState.Chasing)
                OnStartedChasing();
            state = EnemyState.Chasing;
        }
        else
        {

            if (state != EnemyState.Idle)
                OnStartedIdle();
            aiPath.canMove = false;
            state = EnemyState.Idle;

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

    public void Hit()
    {
        hit = true;
        savedColor = new List<Color>();
        foreach(Material mat in mesh.materials)
        {
            savedColor.Add(mat.color);
        }

        foreach (Material mat in mesh.materials)
        {
            mat.color = Color.Lerp(Color.Lerp(Color.red, Color.clear, 0.5f), mat.color, 0.5f);
        }
    }

    public void Die()
    {
        int randCa = UnityEngine.Random.Range(1, 100);
        int randGold = UnityEngine.Random.Range(1, 100);
        int randNotACube = UnityEngine.Random.Range(1, 100);
        int randPoop = UnityEngine.Random.Range(1, 100);
        int randRocket = UnityEngine.Random.Range(1, 100);
        int max = Mathf.Max(randCa, randGold, randNotACube, randPoop, randRocket);

        GameObject instance = null;
        if(max == randCa) instance = Instantiate(caCoin, transform.position + caCoin.transform.position, Quaternion.identity);
        else if(max == randGold) instance = Instantiate(goldCoin, transform.position + goldCoin.transform.position, Quaternion.identity);
        else if(max == randNotACube) instance = Instantiate(notACubeCoin, transform.position + notACubeCoin.transform.position, Quaternion.identity);
        else if(max == randPoop) instance = Instantiate(poopCoin, transform.position + poopCoin.transform.position, Quaternion.identity);
        else if(max == randRocket) instance = Instantiate(rocketCoin, transform.position + rocketCoin.transform.position, Quaternion.identity);

        if (instance != null)
            instance.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0, 1), 1, Random.Range(0, 1)) * 5.0f, ForceMode.Impulse);

        Destroy(gameObject);
    }
}
