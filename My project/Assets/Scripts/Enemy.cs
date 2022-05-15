using System;
using UnityEngine;
using Pathfinding;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] GameObject goldCoin;
    [SerializeField] GameObject caCoin;
    [SerializeField] GameObject notACubeCoin;
    [SerializeField] GameObject poopCoin;
    [SerializeField] GameObject rocketCoin;

    protected AIPath aiPath;
    protected AIDestinationSetter aiDest;
    protected float range;
    protected float shootInterval;
    public float health = 100f;
    protected void SetupPathfinding()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        aiPath = GetComponent<AIPath>();
        aiDest = GetComponent<AIDestinationSetter>();
        aiDest.target = player.transform;

        //game = GetComponentInParent<Game>();
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
