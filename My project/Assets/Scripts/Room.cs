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


    // Start is called before the first frame update
    void Start()
    {
    }

    public void UpdateRooms(bool[] status)
    {
        for (int i = 0; i < status.Length; i++) {
            // doors[i].SetActive(status[i]);
            walls[i].SetActive(!status[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
