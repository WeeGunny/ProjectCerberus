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

    void Start() {
        allMainRooms = mainRoomPrefabs;
        StartCoroutine("GenerateLevel");
    }
    private void Update() {
        if (Input.GetKey(KeyCode.LeftControl)) {
            ResetLevelGenerator();
        }

    }
    IEnumerator GenerateLevel() {
        // WaitForSeconds startup = new WaitForSeconds(1);
        WaitForFixedUpdate interval = new WaitForFixedUpdate();

        // yield return startup;

        //Place startRoom
        PlaceStartRoom();
        yield return interval;

        //Random iterations
        int iterations = Random.Range((int)iterationRange.x,
                                      (int)iterationRange.y);
        for (int i = 0; i < iterations; i++) {
            // Place random room from list
            PlaceMainRoom();
            i++;
            if(i<iterations)
            PlaceConnectingRoom();
            yield return interval;
        }

        //Place endRoom
        PlaceEndRoom();
        yield return interval;

        // Level Generation Finished
        Debug.Log("Level Generation complete. Jobs Done!");
        //once all rooms placed, spawn the player at the spawnpoint and remove loadscreen
        inGameUI.SetActive(true);
        player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        PlayerManager.playerExists = true;
        PlayerManager.instance.player = player;
        LoadScreen.SetActive(false);
        

        //uncomment these lines for frequent level building
        //yield return new WaitForSeconds(3);
        //ResetLevelGenerator();
    }

    void PlaceStartRoom() {
        //Instantiate Room at 0,0,0, rotation identity, and this transform as parent
        startRoom = Instantiate(startRoomPrefab, Vector3.zero, Quaternion.identity, transform) as StartRoom;
        availableDoorways.Add(startRoom.doorways[0]);
        Debug.Log("Placing Start Room! Wrrrrrrr");
    }
    void PlaceMainRoom()
    {
        //Instantiate Room
        int mainRoomIndex = Random.Range(0,mainRoomPrefabs.Count);
        Room currentRoom = Instantiate(mainRoomPrefabs[mainRoomIndex], transform) as Room;
        Debug.Log("Placing random Main room!: " + currentRoom.gameObject.name);
        bool roomPlaced = false;
        // Try all available doorways
        foreach (Doorway availableDoorway in availableDoorways) {
            // Try all available doorways in current room
            foreach (Doorway currentDoorway in currentRoom.doorways) {
                if (roomPlaced == false) {
                    PositionRoomAtDoorway(ref currentRoom, currentDoorway, availableDoorway);
                }
                //if the room has already been placed remaining doorways are added to available doorways.
                if (roomPlaced == true) {
                    availableDoorways.Add(currentDoorway);
                    availableMainDoorways.Add(currentDoorway);
                    
                }

                // Check for overlapping rooms false
                if (!CheckRoomOverlap(currentRoom) && roomPlaced == false) {
                    Debug.Log("Room Placed!: " + currentRoom.gameObject.name);
                    // Add room to global room list
                    placedRooms.Add(currentRoom);

                    // Remove doorway object in room
                    currentDoorway.gameObject.SetActive(false);
                    // Remove doorway object the room is connecting to
                    availableDoorway.gameObject.SetActive(false);
                    //remove doorway from all available doorways
                    availableDoorways.Remove(availableDoorway);
                    //if the door it connects to is in mainDoorways remove it from that list as well.
                    if (availableMainDoorways.Contains(availableDoorway)) {
                        availableMainDoorways.Remove(availableDoorway);
                    }
                    mainRoomPrefabs.Remove(currentRoom);

                    // Exit Loop if room has been placed
                    roomPlaced = true;
                }



            }

            //if the room is placed it no longer needs to check the remaining available doorways
            if (roomPlaced)
                break;
        }
        if (!roomPlaced) {
            Debug.LogError("Room Destroyed!" + currentRoom.gameObject.name);
            Destroy(currentRoom.gameObject);
            ResetLevelGenerator();
        }

    }
    
    void PlaceConnectingRoom() {
        //Instantiate Room
        Room currentRoom = Instantiate(connectingRoomPrefabs[Random.Range(0,connectingRoomPrefabs.Count)], transform) as Room;
        Debug.Log("Placing random Connecting room!: " + currentRoom.gameObject.name);
        bool roomPlaced = false;
        // Try all available doorways
        foreach (Doorway availableDoorway in availableMainDoorways) {
            // Try all available doorways in current room
            foreach (Doorway currentDoorway in currentRoom.doorways) {
                if (roomPlaced == false) {
                    PositionRoomAtDoorway(ref currentRoom, currentDoorway, availableDoorway);
                }
                //if the room has already been placed remaining doorways are added to available doorways.
                if (roomPlaced == true) {
                    availableDoorways.Add(currentDoorway);
                }

                // Check for overlapping rooms false
                if (!CheckRoomOverlap(currentRoom) && roomPlaced == false) {
                    Debug.Log("Room Placed!: " + currentRoom.gameObject.name);
                    // Add room to global room list
                    placedRooms.Add(currentRoom);

                    // Remove doorway object in room
                    currentDoorway.gameObject.SetActive(false);
                    // Remove doorway object the room is connecting to
                    availableDoorway.gameObject.SetActive(false);
                    availableMainDoorways.Remove(availableDoorway);
                    availableDoorways.Remove(availableDoorway);

                    // Exit Loop if room has been placed
                    roomPlaced = true;
                }



            }

            //if the room is placed it no longer needs to check the remaining available doorways
            if (roomPlaced)
                break;
        }
        if (!roomPlaced) {
            Debug.LogError("Room Destroyed!" + currentRoom.gameObject.name);
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



        Collider[] colliders = Physics.OverlapBox(bounds.center, bounds.size / 2, room.transform.rotation, roomLayerMask); // Create an array that contains anything this object is colliding with
        if (colliders.Length > 0) { // If there is anything within this arary
            
            foreach (Collider c in colliders) {
                if (c.transform.parent.gameObject.Equals(room.gameObject)) {    // Ignore collisions with current room
                    continue;
                }
                else {
                    Debug.LogError("Overlap Detected between " + c.gameObject.name + " " + room.gameObject.name);
                    return true;
                }
            }
        }
        return false;
    }
    void PlaceEndRoom() {
        Debug.Log("Placing the End Room! Wrrrrrr");

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
                break;
            }

        }
        if (!roomPlaced) {
            Destroy(endRoom.gameObject);
            ResetLevelGenerator();
        }

    }

    public void ResetLevelGenerator() {
        //// Clears the log so all logs are from current iteration of level gen, reduces clutter in log
        //Type.GetType("UnityEditor.LogEntries,UnityEditor.dll").GetMethod("Clear", BindingFlags.Static | BindingFlags.Public).Invoke(null, null);
        //Debug.Log("reset");
        Debug.Log("Could not place room anywhere, resetting levelGen");

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
        FindObjectOfType<InventoryUI>().ClearInventory();

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

    // WIP
    private Bounds CalculateLocalBounds() 
        // Move to Room.cs and make the bounds generated a public value OR
        // add in Room room as an argument, change 'this' to 'room'
        // ???
    {
        Quaternion currentRotation = this.transform.rotation; // Get whatever the current rotation is of this object
        this.transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Remove any rotation
        Bounds roomBounds = new Bounds(this.transform.position, this.transform.localScale); // Create a new Bounding Box centered on the objects position & the scale of the parent object

        foreach (Renderer renderer in GetComponentsInChildren<Renderer>()) // For every child GameObject of this Game Object, find a Renderer
        {
            roomBounds.Encapsulate(renderer.bounds);  // Make the bounds include the local bounds of the renderer
        }
        Vector3 localCenter = roomBounds.center - this.transform.position; // Return a new center point that is the center of the new bounds, minus the transform of the original object
        roomBounds.center = localCenter; // Assign this new center point to the variable "localCenter"
        Debug.Log("The local bounds of this model is " + roomBounds);
        this.transform.rotation = currentRotation;

        return roomBounds; // returns the new encapsulated bounds

    }


}


