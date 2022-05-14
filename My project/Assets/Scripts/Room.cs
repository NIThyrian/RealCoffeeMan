using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    /**
     * Directions of wall
     * 0 : x+ Forward
     * 1 : z+ Right
     * 2 : z- Left
     * 3 : x- Back
     */

    public GameObject[] walls;
    public GameObject[] doors;
    public GameObject baril;

    public Color roomColor;

    // Start is called before the first frame update
    void Start()
    {
        CreateObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateObjects()
    {
        int nbObject = Random.Range(0, 5);

        int counter = 0;
        Debug.Log("Center : " + transform.position);
        while (counter++ < nbObject)
        {
            float angle = Random.Range(0, 360);
            float dx = 25.0f * 0.75f * Mathf.Cos(angle);  
            float dz = 25.0f * 0.75f * Mathf.Sin(angle);

            Vector3 position = transform.position + new Vector3(dx, 0, dz);
            GameObject obj = Instantiate(baril, position, Quaternion.Euler(new Vector3(90, 90, 0)), transform);
            var objTransform = obj.GetComponent<Transform>();
            objTransform.position = objTransform.position + new Vector3(0, objTransform.localScale.y * 1.25f, 0);
        }
    }

    public void UpdateRooms(bool[] status)
    {
        for (int i = 0; i < status.Length; i++)
        {
            // doors[i].SetActive(status[i]);
            walls[i].SetActive(!status[i]);
        }
    }
}
