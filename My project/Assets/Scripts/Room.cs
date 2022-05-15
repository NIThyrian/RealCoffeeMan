using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    public GameObject shop;

    public Vector3[] spawnPositions;
    public float chanceRoomHavingDoor = 0.5f;

    public Color roomColor;
    public int maxBarilPerRoom = 4;
    public int minBarilPerRoom = 1;
    public RoomType roomType;

    private Vector2 roomSize = new Vector2(50.0f, 50.0f);
    private float wallThickness = 1.0f;
    private List<GameObject> obstacles = new List<GameObject>();

    void Start()
    {
        InitializeRoom();
    }

    public List<GameObject> GetObstacles()
    {
        return obstacles;
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
            // CreateBarils();
            CreateProps();
        }
        else if (roomType == RoomType.Start)
        {
            // Starting room
            CreateShop();
        }
        else
        {
            // Ending room
            //CreateShop();
            CreatePortal();
        }

    }

    public void CreateProps()
    {
        foreach (Vector3 pos in spawnPositions)
        {
            int index = Random.Range(0, props.Length);
            if (index < 0)
                continue;

            CreatePropAtPosition(props[index], pos);
        }
    }

    public static readonly int[] rotations = {0, -90, 90, -180 };
    public void CreatePortal()
    {
        GameObject p = CreatePropAtPosition(portal, new Vector3(0, 0, 0));
        for (int i = 0; i < walls.Length; i++)
        {
            if (walls[i].activeSelf == false){
                var transform = p.GetComponent<Transform>();
                transform.Rotate(new Vector3(0,rotations[i], 0));
            }
        }
    }

    public void CreateShop()
    {
        CreatePropAtPosition(shop, new Vector3(22, 0, 23));
    }

    /**
     * Creates a prop at a position where the origin is at the center of the room
     * The prop will spawn with its feet at the floor
     */
    public GameObject CreatePropAtPosition(GameObject prop, Vector3 pos)
    {
        var position = pos;
        GameObject obj = Instantiate(prop, transform.position + position, Quaternion.identity, transform);

        obstacles.Add(obj);
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
                var obj = CreatePropAtPosition(baril, new Vector3(dx, 0, dz));
                var objTransform = obj.GetComponent<Transform>();
                var size = obj.GetComponent<Collider>().bounds.size;
                objTransform.position = objTransform.position + new Vector3(0, (counterGenerated - 1) * size.y, 0); // Baril on top of another
                counterGenerated++;
            }
        }
    }

    public void UpdateRooms(bool[] status)
    {
        for (int i = 0; i < status.Length; i++)
        {
            float proba = Random.Range(0.0f, 1.0f);
            walls[i].SetActive(!status[i]);
            doors[i].SetActive(status[i] && proba < chanceRoomHavingDoor && roomType != RoomType.Start);
        }
    }
}
