using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour {
    public GameObject iconPrefab;
    public List<POIMarker> poiMarkers = new List<POIMarker>();

    public RawImage compassImage;
    public Transform player;
    public static Compass compass;

    //The maximum distance markers are tracked
    public float maxDistance = 200f;

    float compassUnit;

    private void Awake() {
        if (compass == null) {
            compass = this;
        }
        else {
            Destroy(this);
        }
    }

    private void Start() {
        compassUnit = compassImage.rectTransform.rect.width / 360f;
       
    }

    // Update is called once per frame
    private void Update() {
        if (player != null) {
            compassImage.uvRect = new Rect(player.localEulerAngles.y / 360f, 0f, 1f, 1f);
            if (poiMarkers.Count > 0) {
                foreach (POIMarker marker in poiMarkers) {
                    if (marker.image) {
                        marker.image.rectTransform.anchoredPosition = GetPosOnCompass(marker);

                        float dist = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.z), marker.position);
                        float scale = 0f;

                        if (dist < maxDistance) scale = 1f - (dist / maxDistance);
                        marker.image.rectTransform.localScale = Vector3.one * scale;
                    }
                }
            }
        }
        else if(player == null && PlayerManager.playerExists) {
            player = PlayerManager.player.transform;
        }

    }

    public  void AddPOIMarker(POIMarker marker) {
        GameObject newMarker = Instantiate(iconPrefab, compassImage.transform);
        marker.image = newMarker.GetComponent<Image>();
        marker.image.sprite = marker.icon;
        poiMarkers.Add(marker);
    }

    Vector2 GetPosOnCompass(POIMarker marker) {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 playerFwd = new Vector2(player.transform.forward.x, player.transform.forward.z);
        float angle = Vector2.SignedAngle(marker.position - playerPos, playerFwd);
        return new Vector2(compassUnit * angle, 0f);
    }
}
