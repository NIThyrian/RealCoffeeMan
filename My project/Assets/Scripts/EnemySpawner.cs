using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int maxEnemy;
    private int enemyCounter = 0;
    //private Game game;
    [SerializeField] private GameObject meleeSwarmerPrefab;
    [SerializeField] private GameObject rangeSwarmerPrefab;

    private float meleeSwarmerInterval = 5f;
    private float rangeSwarmerInterval = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //game = GetComponentInParent<Game>();
        maxEnemy = 10;//(int)game.difficultyFactor
        StartCoroutine(spawnEnemy(meleeSwarmerInterval, meleeSwarmerPrefab));
        StartCoroutine(spawnEnemy(rangeSwarmerInterval, rangeSwarmerPrefab));
    }

    // Update is called once per frame
    private IEnumerator spawnEnemy(float interval, GameObject enemy){
        enemyCounter++;
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-1f, 1f), 1, Random.Range(-1f, 1f)), Quaternion.identity, transform);
        if (enemyCounter >= maxEnemy)
        {
            StopAllCoroutines();
          
        }
        else { StartCoroutine(spawnEnemy(interval, enemy)); }
    }
    void update()
    {

    }
}
