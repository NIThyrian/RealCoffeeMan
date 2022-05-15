using System;
using UnityEngine;
using Pathfinding;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] GameObject goldCoin;

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
        float randCa = UnityEngine.Random.Range(0f, 1f);
        float randGold = UnityEngine.Random.Range(0f, 1f);
        float randNotACube = UnityEngine.Random.Range(0f, 1f);
        float randPoop = UnityEngine.Random.Range(0f, 1f);
        float randRocket = UnityEngine.Random.Range(0f, 1f);
        
        Instantiate(goldCoin, transform.position, Quaternion.identity);
        Destroy(gameObject);

        /*
        if(randomAmmo < ammoDropChance && randomMedkit < medkitDropChance) 
        {
            Vector3 posLeft = new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z);
            Vector3 posRight = new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z);
            Instantiate(ammoBox, posLeft, Quaternion.identity);
            Instantiate(medkitBox, posRight, Quaternion.identity);
        }
        else if(randomMedkit < medkitDropChance) Instantiate(medkitBox, transform.position, Quaternion.identity);
        else if(randomAmmo < ammoDropChance) Instantiate(ammoBox, transform.position, Quaternion.identity);
        Destroy(gameObject);
        */
    }
}
