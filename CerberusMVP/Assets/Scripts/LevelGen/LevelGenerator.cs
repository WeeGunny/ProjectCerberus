using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using Random = UnityEngine.Random;
using UnityEngine.Rendering;

public class LevelGenerator : MonoBehaviour {

    //What rooms will be the start or end room
    public Room startRoomPrefab, endRoomPrefab, shopRoomPrefab;
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
    [SerializeField] List<Room> placedRooms = new List<Room>();

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
        //WaitForSeconds interval = new WaitForSeconds(0.33f);

        //Place startRoom
        PlaceStartRoom();
        yield return interval;

        //Random iterations
        int iterations = Random.Range((int)iterationRange.x, (int)iterationRange.y);
        for(int i = 0; i < iterations; i++) {
            // Place random room from list

            PlaceMainRoom();
            i++;
            yield return interval;
            if(i < iterations) {
                PlaceConnectingRoom();
            }

        }

        PlaceShopRoom();
        //Place endRoom
        PlaceEndRoom();
        yield return interval;
        //Makes Sure that all end doors are marked to stay closed
        foreach(Doorway door in availableDoorways) {
            door.SetOutdoor();
        }
        foreach(Doorway door in availableMainDoorways) {
            door.SetOutdoor();
        }

        //once all rooms placed, spawn the player at the spawnpoint and remove loadscreen
        inGameUI.SetActive(true);
        player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        LoadScreen.SetActive(false);
        Debug.Log("Level Gen complete");
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
        Room currentRoom = Instantiate(mainRoomPrefabs[Random.Range(0, mainRoomPrefabs.Count)], transform) as Room;
        bool roomPlaced = false;
        availableMainDoorways.AddRange(currentRoom.doorways);
        // Try all available doorways
        foreach(Doorway availableDoorway in availableDoorways) {
            // Try all available doorways in current room
            foreach(Doorway currentDoorway in currentRoom.doorways) {
                if(PlaceRoom(currentRoom, currentDoorway, availableDoorway)) {
                    availableMainDoorways.Remove(currentDoorway);
                    availableDoorways.Remove(availableDoorway);
                    mainRoomPrefabs.Remove(currentRoom);// this is to make it so main rooms dont repeat
                    roomPlaced = true;
                    break;
                }
            }
            if(roomPlaced) break;
        }
        if(!roomPlaced) {
            Destroy(currentRoom.gameObject);     
            ResetLevelGenerator(); // should we reset always? can we try again?
        }

    }

    void PlaceConnectingRoom() {
        //Instantiate Room
        Room currentRoom = Instantiate(connectingRoomPrefabs[Random.Range(0, connectingRoomPrefabs.Count)], transform) as Room;
        bool roomPlaced = false;
        availableDoorways.AddRange(currentRoom.doorways);
        // Try all available doorways
        foreach(Doorway availableMainDoorway in availableMainDoorways) {
            // Try all available doorways in current room
            foreach(Doorway currentDoorway in currentRoom.doorways) {

                if(PlaceRoom(currentRoom, currentDoorway, availableMainDoorway)) {
                    availableDoorways.Remove(currentDoorway);
                    availableMainDoorways.Remove(availableMainDoorway);
                    roomPlaced = true;
                    break;
                }
            }
            if(roomPlaced) break;
        }
        if(!roomPlaced) {
            Destroy(currentRoom.gameObject);
            ResetLevelGenerator();
        }
    }

    bool PlaceRoom(Room currentRoom, Doorway currentDoorway, Doorway availableDoorway) {
        PositionRoomAtDoorway(ref currentRoom, currentDoorway, availableDoorway);
        if(!CheckRoomOverlap(currentRoom)) {
            placedRooms.Add(currentRoom);
            currentRoom.id = roomNum;
            roomNum++;
            currentDoorway.UnlockDoor();
            availableDoorway.UnlockDoor();
            return true;
        }
        return false;
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
        if(colliders.Length > 0) { // If there is anything within this arary

            foreach(Collider c in colliders) {
                if(c.transform.IsChildOf(room.transform)) // Ignore collisions with parent object
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

    void PlaceShopRoom() {
        Room shopRoom = Instantiate(shopRoomPrefab, transform);
        Doorway shopDoor = shopRoom.doorways[0];
        bool roomPlaced = false;
        for(int i = availableDoorways.Count - 1; i >= 0; i--) {
            if(PlaceRoom(shopRoom, shopDoor, availableDoorways[i])) {
                availableDoorways.RemoveAt(i);
                roomPlaced = true;
                break;
            }
        }
        if(!roomPlaced) {
            Destroy(shopRoom.gameObject);
            ResetLevelGenerator();
        }
    }
    void PlaceEndRoom() {
        // Instantiate Room
        Room endRoom = Instantiate(endRoomPrefab, transform);
        // Add endRoom Doorway to index 0
        Doorway endDoorway = endRoom.doorways[0];
        bool roomPlaced = false;
        // Try all available doorways counting down from most recent
        for(int i = availableDoorways.Count - 1; i >= 0; i--) {
            if(PlaceRoom(endRoom, endDoorway, availableDoorways[i])) {
                availableDoorways.RemoveAt(i);
                roomPlaced = true;
                break;
            }
        }
        if(!roomPlaced) {
            Destroy(endRoom.gameObject);
            ResetLevelGenerator();
        }
    }

    public void ResetLevelGenerator() {
        StopCoroutine("GenerateLevel");
        Debug.Log("Resetting level");
        //Remove all current rooms
        if(startRoom) {
            Destroy(startRoom.gameObject);
        }
        if(player) {
            Destroy(player);
        }
        foreach(Room room in placedRooms) {
            Destroy(room.gameObject);
        }

        // Clear lists
        placedRooms.Clear();
        availableDoorways.Clear();
        availableMainDoorways.Clear();
        roomNum = 0;

        StartCoroutine("GenerateLevel");
    }
}