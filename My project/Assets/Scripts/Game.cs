using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Color currentColor;
    public int level;
    public float difficultyFactor;
    public GameObject map;

    private GameObject mapReference; 

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        difficultyFactor = 1;
        currentColor = Random.ColorHSV();
        mapReference = Instantiate(map, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity, transform);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            ChangeLevel();
        }

    }

    void ChangeLevel()
    {
        Destroy(mapReference);
        currentColor = Random.ColorHSV();
        level++;
        difficultyFactor += 0.25f;
        mapReference = Instantiate(map, map.transform.position, Quaternion.identity, transform);
    }
}
