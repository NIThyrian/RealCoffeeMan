using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public enum Direction
    {
        Forward = 0,
        Right = 1,
        Left = 2,
        Back = 3,
        Max = 4 // Just to have the length of the enum
    }

    public static readonly Vector3[] directions =
    {
        new Vector3(1, 0, 0),
        new Vector3(0, 0, -1),
        new Vector3(0, 0, 1),
        new Vector3(-1, 0, 0)
    };

    public int maxRooms = 4;

    public GameObject room;
    public Vector2 roomSize;
    public GameObject player;

    private List<Room> rooms = new List<Room>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
        Instantiate(player, transform.position + new Vector3(0.0f, 5.0f, 0.0f), Quaternion.identity, transform);

        applyVibeToRooms();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void applyVibeToRooms()
    {

    }

    public void GenerateMap()
    {
        Debug.Assert(maxRooms > 2);

        List<Direction> map = new List<Direction>(GenerateDirections());

        Vector3 position = transform.position;
        Room spawnRoom = Instantiate(room, position, Quaternion.identity, transform).GetComponent<Room>();
        spawnRoom.SetType(Room.RoomType.Start);
        rooms.Add(spawnRoom);
        spawnRoom.UpdateRooms(new bool[] { true, false, false, false }); // Forward
        Vector3 dirVec = directions[(int)map[0]];
        dirVec.Scale(roomSize);

        position += dirVec;

        for (int i = 1; i < map.Count - 1; i++)
        {
            Direction direction = map[i];
            Direction previousDirection = map[i - 1];
            dirVec = directions[(int)direction];
            dirVec.Scale(new Vector3(roomSize.x, 1, roomSize.y));

            Room newRoom = Instantiate(room, position, Quaternion.identity, transform).GetComponent<Room>();
            newRoom.SetType(Room.RoomType.Normal);
            rooms.Add(newRoom);

            Direction[] openedDirection =
            {
                direction, GetOppositeDirection(previousDirection)
            };

            position = position + dirVec;

            bool[] activeDirections = GetActiveWallsFromDirection(openedDirection);
            newRoom.UpdateRooms(activeDirections);
        }

        Room endRoom = Instantiate(room, position, Quaternion.identity, transform).GetComponent<Room>();
        endRoom.SetType(Room.RoomType.End);
        rooms.Add(endRoom);

        endRoom.UpdateRooms(GetActiveWallsFromDirection(new Direction[] { GetOppositeDirection(map[map.Count - 2]) })); // Forward
    }

    public Direction[] GenerateDirections()
    {
        Direction[] map = new Direction[maxRooms];

        map[0] = Direction.Forward;
        for (int i = 1; i < map.Length - 1; i++)
        {
            Direction direction = (Direction)Random.Range(0, (int)Direction.Max);

            while (i > 0 && (direction.Equals(GetOppositeDirection(map[i - 1])) || direction.Equals(Direction.Back)))
                direction = (Direction)Random.Range(0, (int)Direction.Max);

            map[i] = direction;
        }
        map[map.Length - 1] = GetOppositeDirection(map[map.Length - 2]);

        return map;

    }

    Direction GetOppositeDirection(Direction d)
    {
        switch (d)
        {
            case Direction.Forward:
                return Direction.Back;
            case Direction.Back:
                return Direction.Forward;
            case Direction.Left:
                return Direction.Right;
            case Direction.Right:
                return Direction.Left;
            default:
                return Direction.Forward;
        }
    }

    bool[] GetActiveWallsFromDirection(Direction[] directions)
    {
        bool[] activeWalls = new bool[4];

        foreach (Direction direction in directions)
        {
            activeWalls[(int)direction] = true;
        }

        return activeWalls;
    }

}
