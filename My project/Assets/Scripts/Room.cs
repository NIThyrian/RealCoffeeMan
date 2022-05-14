using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public enum RoomType
    {
        Start, Normal, End
    }

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
    public GameObject[] props;
    public GameObject portal;
    public Vector3[] spawnPositions;

    public Color roomColor;
    public int maxBarilPerRoom = 4;
    public int minBarilPerRoom = 1;
    public RoomType roomType;

    private Vector2 roomSize = new Vector2(50.0f, 50.0f);
    private float wallThickness = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InitializeRoom();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetType(RoomType type)
    {
        roomType = type;
    }


    public void InitializeRoom()
    {

        if (roomType == RoomType.Normal)
        {
            // Normal room
            CreateBarils();
            CreateProps();
        }
        else if (roomType == RoomType.Start)
        {
            // Starting room
            CreateProps();
        }
        else
        {
            // Ending room
            CreatePortal();
        }

    }

    public void CreateProps()
    {
        foreach (Vector3 pos in spawnPositions)
        {
            int index = Random.Range(-1, props.Length);
            if (index < 0)
                continue;

            CreatePropAtPosition(props[index], pos);
        }
    }

    public void CreatePortal()
    {
        CreatePropAtPosition(portal, new Vector3(0, 0, 0));
    }

    /**
     * Creates a prop at a position where the origin is at the center of the room
     * The prop will spawn with its feet at the floor
     */
    public GameObject CreatePropAtPosition(GameObject prop, Vector3 pos)
    {
        var position = pos + transform.position;
        GameObject obj = Instantiate(prop, position, Quaternion.identity, transform);
        var objTransform = obj.GetComponent<Transform>();
        var size = obj.GetComponent<Collider>().bounds.size;
        objTransform.position = objTransform.position +
            new Vector3(0, size.z * 0.5f + wallThickness, 0); // Translation to floor (z direction because the prefab is rotated)
        return obj;
    }

    public void CreateBarils()
    {


        int nbObject = 1;// Random.Range(minBarilPerRoom, maxBarilPerRoom);
        int counter = 0;
        while (counter++ < nbObject)
        {
            float angle = Random.Range(0, 360);
            float dx = roomSize.x / 2.0f * 0.60f * Mathf.Cos(angle);  
            float dz = roomSize.y / 2.0f * 0.60f * Mathf.Sin(angle);

            Vector3 position = transform.position + new Vector3(dx, 0, dz);

            int numberGenerated = Random.Range(2, 2);
            int counterGenerated = 1;
            while (counterGenerated <= numberGenerated)
            {
                GameObject obj = Instantiate(baril, position, Quaternion.Euler(new Vector3(0, 0, 0)), transform);
                var objTransform = obj.GetComponent<Transform>();
                var size = obj.GetComponent<Collider>().bounds.size;
                Debug.Log(size);
                objTransform.position = objTransform.position + new Vector3(0, size.y * 0.5f + wallThickness / 2.0f, 0); // Translation to floor (z direction because the prefab is rotated)
                objTransform.position = objTransform.position + new Vector3(0, (counterGenerated - 1) * size.y, 0); // Baril on top of another
                counterGenerated++;
            }
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
