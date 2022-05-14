using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int maxEnemy;
    public int enemyCounter = 0;
    [SerializeField]
    private GameObject meleeSwarmerPrefab;
    [SerializeField]
    private GameObject rangeSwarmerPrefab;

    [SerializeField]
    private float meleeSwarmerInterval = 3.5f;
    [SerializeField]
    private float rangeSwarmerInterval = 5f;
    public EnemySpawner(int maxEnemy)
    {
        this.maxEnemy = maxEnemy;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(meleeSwarmerInterval, meleeSwarmerPrefab));
        StartCoroutine(spawnEnemy(rangeSwarmerInterval, rangeSwarmerPrefab));
    }

    // Update is called once per frame
    private IEnumerator spawnEnemy(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(transform.position.x - 1f, transform.position.x + 1f), 2.86f, Random.Range(transform.position.z - 1f, transform.position.z + 1f)), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
        enemyCounter++;
    }
    void update()
    {
        if (enemyCounter >= maxEnemy)
            Destroy(this);
    }
}
