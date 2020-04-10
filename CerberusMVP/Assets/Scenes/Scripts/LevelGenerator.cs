using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
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

    void Start() {
        roomLayerMask = LayerMask.GetMask("Ground");
        StartCoroutine("GenerateLevel");
    }
    IEnumerator GenerateLevel() {
        WaitForSeconds startup = new WaitForSeconds(1);
        WaitForFixedUpdate interval = new WaitForFixedUpdate();

        yield return startup;

        //Place startRoom
        PlaceStartRoom();
        yield return interval;

        //Random iterations
        int iterations = Random.Range((int)iterationRange.x,
                                      (int)iterationRange.y);
        for (int i = 0; i < iterations; i++) {
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
        ResetLevelGenerator();
    }

    void AddDoorwaysToList(Room room, ref List<Doorway> list) {
        foreach (Doorway doorway in room.doorways) {
            int r = Random.Range(0, list.Count);
            list.Insert(r, doorway);

        }
    }

    void PlaceStartRoom() {
        //Instantiate Room at 0,0,0, rotation identity, and this transform as parent
        startRoom = Instantiate(startRoomPrefab, Vector3.zero, Quaternion.identity, transform) as StartRoom;

        // Get doorways from current room & add to list of available doorways at random index
        AddDoorwaysToList(startRoom, ref availableDoorways);
        Debug.Log("Placing Start Room! Wrrrrrrr");
    }
    void PlaceRoom() {
        Debug.Log("Placing random room from list! Wrrrrr");
        //Instantiate Room
        Room currentRoom = Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Count)]) as Room;
        currentRoom.transform.parent = this.transform;
        bool roomPlaced = false;
        // Try all available doorways
        foreach (Doorway availableDoorway in availableDoorways) {
            // Try all available doorways in current room
            foreach (Doorway currentDoorway in currentRoom.doorways) {
                if (roomPlaced == false)
                    PositionRoomAtDoorway(ref currentRoom, currentDoorway, availableDoorway);

                // Check for overlapping rooms false
                if (!CheckRoomOverlap(currentRoom) && roomPlaced == false) {
                    //Position room

                    Debug.Log("Room Placed !");
                    // Add room to global room list
                    placedRooms.Add(currentRoom);

                    // Remove doorway in room
                    currentDoorway.gameObject.SetActive(false);
                    // Remove doorway room is connecting to
                    availableDoorway.gameObject.SetActive(false);
                    availableDoorways.Remove(availableDoorway);

                    // Exit Loop if room has been placed
                    roomPlaced = true;
                }

                //if the room has already been placed but another doorway would not cause an overlap it is added to available doorways.
                else if (!CheckRoomOverlap(currentRoom) && roomPlaced == true) {
                    availableDoorways.Add(currentDoorway);
                }

            }

            //if the room is placed it no longer needs to check the remaining available doorways
            if (roomPlaced)
                break;
        }
        if (!roomPlaced) {
            Destroy(currentRoom.gameObject);
            ResetLevelGenerator();
        }

    }

    void PositionRoomAtDoorway(ref Room room, Doorway roomDoorway, Doorway targetDoorway) {
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
    bool CheckRoomOverlap(Room room) {
        Bounds bounds = room.RoomBounds;
        bounds.center = room.transform.position;
        bounds.Expand(0.1f);

        Collider[] colliders = Physics.OverlapBox(bounds.center, bounds.size / 2, room.transform.rotation, roomLayerMask);
        if (colliders.Length > 0) {
            foreach (Collider c in colliders) {
                Debug.Log("Colliding with: " + c.gameObject.name + " Parent: " + c.transform.parent.name);
            }
        }
        if (colliders.Length > 0) {
            // Ignore collisions with current room
            foreach (Collider c in colliders) {
                if (c.transform.parent.gameObject.Equals(room.gameObject)) {
                    continue;
                }

                else {
                    Debug.LogError("Overlap Detected! " + c.gameObject.name);
                    return true;

                }
            }
        }
        return false;
    }
    void PlaceEndRoom() {
        Debug.Log("Placing the End Room! Wrrrrrr");

        // Instantiate Room
        endRoom = Instantiate(endRoomPrefab) as EndRoom;
        endRoom.transform.parent = this.transform;

        // Add endRoom Doorway to index 0
        Doorway endDoorway = endRoom.doorways[0];

        bool roomPlaced = false;
        int doorToPlace = availableDoorways.Count - 1;
        // Try all available doorways
        for (int i = 0; i < availableDoorways.Count; i++) {
            // not sure why casting to room?
            Room room = endRoom;

            // Check for overlapping rooms
            if (CheckRoomOverlap(endRoom)) {
                doorToPlace--;
            }
            else {
                PositionRoomAtDoorway(ref room, endDoorway, availableDoorways[doorToPlace]);
                roomPlaced = true;
                // Remove occupied doorways
                endDoorway.gameObject.SetActive(false);
                availableDoorways.Remove(endDoorway);

                availableDoorways[doorToPlace].gameObject.SetActive(false);
                availableDoorways.Remove(availableDoorways[doorToPlace]);
                break;
            }

        }
        if (!roomPlaced) {
            Destroy(endRoom.gameObject);
            ResetLevelGenerator();
        }

    }

    void ResetLevelGenerator() {
        Debug.LogError("Resetting Level Generator");

        StopCoroutine("GenerateLevel");

        //Remove all current rooms
        if (startRoom) {
            Destroy(startRoom.gameObject);
        }
        if (endRoom) {
            Destroy(endRoom.gameObject);
        }

        foreach (Room room in placedRooms) {
            Destroy(room.gameObject);
        }

        // Clear lists

        placedRooms.Clear();
        availableDoorways.Clear();

        StartCoroutine("GenerateLevel");

    }
}


