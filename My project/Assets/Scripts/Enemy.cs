using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    [SerializeField] GameObject goldCoin;

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
