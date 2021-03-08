using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using Random = UnityEngine.Random;
using UnityEngine.Rendering;

public class LevelGenerator : MonoBehaviour {

    //What rooms will be the start or end room
    public Room startRoomPrefab, endRoomPrefab;
    // List of room Prefabs between start and finish 
    [Header("Random Room Gen")]
    public List<Room> mainRoomPrefabs = new List<Room>();
    private List<Room> allMainRooms;
    public List<Room> connectingRoomPrefabs = new List<Room>();
    // Range of rooms to create
    public Vector2 iterationRange = new Vector2(3, 10);
    public LayerMask roomLayerMask;

    // List of Doorways we can access
    public List<Doorway> availableDoorways = new List<Doorway>();
    public List<Doorway> availableMainDoorways = new List<Doorway>();

    // create a startRoom, endRoom and placedRooms for easier referencing
    StartRoom startRoom;
    EndRoom endRoom;
    Room shopRoom;
    List<Room> placedRooms = new List<Room>();

    //Set up player
    [Header("Player")]
    public GameObject playerPrefab;
    public Transform spawnPoint;
    GameObject player;

    //UI Stuff
    [Header("UI References")]
    public GameObject LoadScreen;
    public GameObject WinScreen;
    public GameObject inGameUI;

    int roomNum = 0;

    void Start() {
        allMainRooms = mainRoomPrefabs;
        StartCoroutine("GenerateLevel");
    }
    private void Update() {

    }
    IEnumerator GenerateLevel() {
        WaitForFixedUpdate interval = new WaitForFixedUpdate();

        //Place startRoom
        PlaceStartRoom();
        yield return interval;

        //Random iterations
        int iterations = Random.Range((int)iterationRange.x, (int)iterationRange.y);
        int shopRoomNum = Random.Range(0, iterations);
        for (int i = 0; i < iterations; i++) {
            // Place random room from list
            if (i == shopRoomNum) {
            }
            if (i < iterations) PlaceMainRoom();
            yield return interval;
            i++;
            if (i < iterations) PlaceConnectingRoom();
            yield return interval;
        }

        //Place endRoom
        PlaceEndRoom();
        //Makes Sure that all end doors are marked to stay closed
        foreach (Doorway door in availableDoorways) {
            door.SetOutdoor();
        }
        foreach (Doorway door in availableMainDoorways) {
            door.SetOutdoor();
        }

        yield return interval;
        //once all rooms placed, spawn the player at the spawnpoint and remove loadscreen
        inGameUI.SetActive(true);
        player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        LoadScreen.SetActive(false);
    }

    void PlaceStartRoom() {
        //Instantiate Room at 0,0,0, rotation identity, and this transform as parent
        startRoom = Instantiate(startRoomPrefab, Vector3.zero, Quaternion.identity, transform) as StartRoom;
        availableDoorways.Add(startRoom.doorways[0]);
        startRoom.id = roomNum;
        roomNum++;
    }
    void PlaceMainRoom() {
        //Instantiate Room
        int mainRoomIndex = Random.Range(0, mainRoomPrefabs.Count);
        Room currentRoom = Instantiate(mainRoomPrefabs[mainRoomIndex], transform) as Room;
        bool roomPlaced = false;
        // Try all available doorways
        foreach (Doorway availableDoorway in availableDoorways) {
            // Try all available doorways in current room
            foreach (Doorway currentDoorway in currentRoom.doorways) {
                availableMainDoorways.Add(currentDoorway);
                if (roomPlaced == false) {
                    PositionRoomAtDoorway(ref currentRoom, currentDoorway, availableDoorway);

                }
                if (!CheckRoomOverlap(currentRoom) && roomPlaced == false) {
                    // Add room to global room list
                    placedRooms.Add(currentRoom);

                    // Remove doorway object in room
                    currentDoorway.gameObject.SetActive(false);
                    availableMainDoorways.Remove(currentDoorway);
                    // Remove doorway object the room is connecting to
                    availableDoorway.gameObject.SetActive(false);
                    mainRoomPrefabs.Remove(currentRoom);

                    // Exit Loop if room has been placed
                    roomPlaced = true;
                    currentRoom.id = roomNum;
                    roomNum++;
                }

            }
            //if the room is placed it no longer needs to check the remaining available doorways
            if (roomPlaced) {
                availableDoorway.UnlockDoor();
                //if the door it connects to is in mainDoorways remove it from that list as well.
                if (availableDoorways.Contains(availableDoorway)) availableDoorways.Remove(availableDoorway);
                if (availableMainDoorways.Contains(availableDoorway)) availableMainDoorways.Remove(availableDoorway);
                break;
            }
        }
        if (!roomPlaced) {
            Destroy(currentRoom.gameObject);
            ResetLevelGenerator(); // should we reset always? can we try again?
        }

    }

    void PlaceConnectingRoom() {
        //Instantiate Room
        Room currentRoom = Instantiate(connectingRoomPrefabs[Random.Range(0, connectingRoomPrefabs.Count)], transform) as Room;
        bool roomPlaced = false;
        // Try all available doorways
        foreach (Doorway availableDoorway in availableMainDoorways) {
            // Try all available doorways in current room
            foreach (Doorway currentDoorway in currentRoom.doorways) {
                availableDoorways.Add(currentDoorway);
                if (roomPlaced == false) {
                    PositionRoomAtDoorway(ref currentRoom, currentDoorway, availableDoorway);
                    // Check for overlapping rooms false
                    if (!CheckRoomOverlap(currentRoom)) {
                        // Add room to global room list
                        placedRooms.Add(currentRoom);
                        currentRoom.id = roomNum;
                        roomNum++;
                        // Remove doorway object in room
                        currentDoorway.UnlockDoor();
                        availableDoorways.Remove(currentDoorway);
                        // Exit Loop if room has been placed
                        roomPlaced = true;
                    }
                }
            }
            //if the room is placed it no longer needs to check the remaining available doorways
            if (roomPlaced) {
                if (availableMainDoorways.Contains(availableDoorway)) availableMainDoorways.Remove(availableDoorway);
                //if (availableDoorways.Contains(availableDoorway)) availableDoorways.Remove(availableDoorway);
                availableDoorway.UnlockDoor();
                break;
            }

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
        bounds.Expand(-0.1f);
        Collider[] colliders = Physics.OverlapBox(bounds.center, bounds.size / 2, room.transform.rotation, roomLayerMask); // Create an array that contains anything this object is colliding with
        if (colliders.Length > 0) { // If there is anything within this arary

            foreach (Collider c in colliders) {
                if (c.transform.IsChildOf(room.transform)) // Ignore collisions with parent object
                {
                    continue;
                }
                else {
                    return true;
                }
            }
        }
        return false;
    }
    void PlaceEndRoom() {

        // Instantiate Room
        endRoom = Instantiate(endRoomPrefab, transform) as EndRoom;

        // Add endRoom Doorway to index 0
        Doorway endDoorway = endRoom.doorways[0];

        bool roomPlaced = false;
        int doorToPlace = availableDoorways.Count - 1;
        // Try all available doorways
        for (int i = 0; i < availableDoorways.Count; i++) {
            // not sure why casting to room?
            Room room = endRoom;
            PositionRoomAtDoorway(ref room, endDoorway, availableDoorways[doorToPlace]);
            // Check for overlapping rooms
            if (CheckRoomOverlap(endRoom)) {
                doorToPlace--;
            }
            else {
                roomPlaced = true;
                // Remove occupied doorways
                endDoorway.gameObject.SetActive(false);
                availableDoorways.Remove(endDoorway);

                availableDoorways[doorToPlace].gameObject.SetActive(false);
                availableDoorways.Remove(availableDoorways[doorToPlace]);
                startRoom.id = roomNum;
                roomNum++;
                break;
            }

        }
        if (!roomPlaced) {
            Destroy(endRoom.gameObject);
            ResetLevelGenerator();
        }

    }

    public void ResetLevelGenerator() {

        StopCoroutine("GenerateLevel");

        //Remove all current rooms
        if (startRoom) {
            Destroy(startRoom.gameObject);
        }
        if (endRoom) {
            Destroy(endRoom.gameObject);
        }
        if (player) {
            PlayerManager.playerExists = false;
            Destroy(player);
        }

        foreach (Room room in placedRooms) {
            Destroy(room.gameObject);
        }

        // Clear lists

        placedRooms.Clear();
        availableDoorways.Clear();
        availableMainDoorways.Clear();
        roomNum = 0;
        // FindObjectOfType<InventoryUI>().ClearInventory();

        StartCoroutine("GenerateLevel");

    }

    public void Win() {
        WinScreen.SetActive(true);
    }

    public void ResetButton() {
        WinScreen.gameObject.SetActive(false);
        LoadScreen.gameObject.SetActive(true);
        ResetLevelGenerator();
    }


}


