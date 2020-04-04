using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //What rooms will be the start or end room
    public Room startRoomPrefab, endRoomPrefab;
    // List of room Prefabs between start and finish 
    public List<Room> roomPrefabs = new List<Room>();
    // Range of rooms to create
    public Vector2 iterationRange = new Vector2(3, 10);

    // List of Doorways we can access
    List<Doorway> availableDoorways = new List<Doorway>();

    StartRoom startRoom;
    EndRoom endRoom;
    List<Room> placedRooms = new List<Room>();

    LayerMask roomLayerMask;

    void Start()
    {
        roomLayerMask = LayerMask.GetMask("Room");
        StartCoroutine("GenerateLevel");
    }
    IEnumerator GenerateLevel()
    {
        WaitForSeconds startup = new WaitForSeconds(1);
        WaitForFixedUpdate interval = new WaitForFixedUpdate();

        yield return startup;

        //Place startRoom
        PlaceStartRoom();
        yield return interval;

        //Random iterations
        int iterations = Random.Range((int)iterationRange.x,
                                      (int)iterationRange.y);
        for (int i = 0; i < iterations; i++)
        {
            // Place random room from list
            PlaceRoom();
            yield return interval;
        }

        //Place endRoom
        PlaceEndRoom();
        yield return interval;

        // Level Generation Finished
        Debug.Log("Level Generation complete. Jobs Done!");
        yield return new WaitForSeconds(3);
        //ResetLevelGenerator();
    }
    void ResetLevelGenerator()
    {
        Debug.LogError("Resetting Level Generator");

        StopCoroutine("GenerateLevel");

        //Remove all current rooms
        if (startRoom)
        {
            Destroy(startRoom.gameObject);
        }
        if (endRoom)
        {
            Destroy(endRoom.gameObject);
        }

        foreach (Room room in placedRooms)
        {
            Destroy(room.gameObject);
        }

        // Clear lists

        placedRooms.Clear();
        availableDoorways.Clear();

        StartCoroutine("GenerateLevel");

    }
    void AddDoorwaysToList(Room room, ref List<Doorway> list) {
        foreach (Doorway doorway in room.doorways) {
            int r = Random.Range(0, list.Count);
            list.Insert(r, doorway);

        }
    }
    void PositionRoomAtDoorway(ref Room room, Doorway roomDoorway, Doorway targetDoorway)
    {
        // Reset room Pos & Rotation
        room.transform.position = Vector3.zero;
        room.transform.rotation = Quaternion.identity;

        // Rotate room to match target doorway orientation
        Vector3 targetDoorwayEuler = targetDoorway.transform.eulerAngles;
        Vector3 roomDoorwayEuler = roomDoorway.transform.eulerAngles;
        float deltaAngle = Mathf.DeltaAngle(roomDoorwayEuler.y, targetDoorwayEuler.y);
        Quaternion currentRoomTargetRotation = Quaternion.AngleAxis(deltaAngle, Vector3.up);
        room.transform.rotation = currentRoomTargetRotation * Quaternion.Euler(0, 180f, 0);

        // Position room by subtracting door origin by room Origin
        Vector3 roomPositionOffset = roomDoorway.transform.position - room.transform.position;
        room.transform.position = targetDoorway.transform.position - roomPositionOffset;


    }
    bool CheckRoomOverlap(Room room)
    {
        Bounds bounds = room.RoomBounds;
        bounds.Expand(-0.1f);

        Collider[] colliders = Physics.OverlapBox(bounds.center, bounds.size / 2, room.transform.rotation, roomLayerMask);
        if (colliders.Length < 0)
        {
            // Ignore collisions with current room
            foreach (Collider c in colliders)
            {
                if (c.transform.parent.gameObject.Equals(room.gameObject))
                {
                    continue;

                }
                else
                {
                    Debug.LogError("Overlap Detected!");
                    return true;

                }
            }
        }
        return false;
    }


    void PlaceStartRoom()
    {
        //Instantiate Room
        startRoom = Instantiate(startRoomPrefab) as StartRoom;
        startRoom.transform.parent = this.transform;

        // Get doorways from current room & add to list of available doorways at random index
        AddDoorwaysToList(startRoom, ref availableDoorways);

        // Position Room
        startRoom.transform.position = Vector3.zero;
        startRoom.transform.rotation = Quaternion.identity;

        Debug.Log("Placing Start Room! Wrrrrrrr");
    }
    void PlaceRoom()
    {
        Debug.Log("Placing random room from list! Wrrrrr");
        //Instantiate Room
        Room currentRoom = Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Count)]) as Room;
        currentRoom.transform.parent = this.transform;

        //Create doorway list
        List<Doorway> allAvailableDoorways = new List<Doorway>(availableDoorways);
        List<Doorway> doorwaysInCurrentRoom = new List<Doorway> ();
        AddDoorwaysToList(currentRoom, ref doorwaysInCurrentRoom);

        // Add current room's doorway list to global list at random index
        AddDoorwaysToList(currentRoom, ref availableDoorways);

        bool roomPlaced = false;

        // Try all available doorways
        foreach (Doorway availableDoorway in allAvailableDoorways) { 
            // Try all available doorways in current room
            foreach(Doorway currentDoorway in doorwaysInCurrentRoom)
            {
                //Position room
                PositionRoomAtDoorway(ref currentRoom, currentDoorway, availableDoorway);

                // Check for overlapping rooms
                if (CheckRoomOverlap(currentRoom))
                {
                    continue;
                }

                roomPlaced = true;

                // Add room to global room list
                placedRooms.Add(currentRoom);

                // Remove occupied doorways
                currentDoorway.gameObject.SetActive(false);
                availableDoorways.Remove(currentDoorway);

                availableDoorway.gameObject.SetActive(false);
                availableDoorways.Remove(availableDoorway);

                // Exit Loop if room has been placed
                if (roomPlaced) {
                    break;
                }

                // If room can't be placed, try again
                if (!roomPlaced) {
                    Destroy(currentRoom.gameObject);
                    ResetLevelGenerator();
                }
    }

            }
        }
    void PlaceEndRoom()
    {
        Debug.Log("Placing the End Room! Wrrrrrr");

        // Instantiate Room
        endRoom = Instantiate(endRoomPrefab) as EndRoom;
        endRoom.transform.parent = this.transform;

        // Add endRoom Doorway to index 0
        List<Doorway> allAvailableDoorways = new List<Doorway>(availableDoorways);
        Doorway doorway = endRoom.doorways[0];

        bool roomPlaced = false;

        // Try all available doorways
        foreach (Doorway availableDoorway in allAvailableDoorways) {
            Room room = (Room)endRoom;
            PositionRoomAtDoorway(ref room, doorway, availableDoorway);

            // Check for overlapping rooms
            if (CheckRoomOverlap(endRoom)) {
                continue;
            }

            roomPlaced = true;

            // Remove occupied doorways
            doorway.gameObject.SetActive(false);
            availableDoorways.Remove(doorway);

            availableDoorway.gameObject.SetActive(false);
            availableDoorways.Remove(availableDoorway);

            // Exit loop if room has been placed
            break;
        }

        if (!roomPlaced) {
 
            ResetLevelGenerator();
        }




    }
}


