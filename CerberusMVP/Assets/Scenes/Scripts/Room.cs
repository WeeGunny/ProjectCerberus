using UnityEngine;

public class Room : MonoBehaviour {
    // Array of available doorways
    public Doorway[] doorways;
    public MeshCollider meshCollider;

    // Get the bounding box of a room
    public Bounds RoomBounds {
        get { return meshCollider.bounds; }
    }

}
