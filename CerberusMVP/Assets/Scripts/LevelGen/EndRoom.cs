using UnityEngine;

public class EndRoom : Room {

    public BossDoor bossDoor;
    private void Start() {
        int RandomChest = Random.Range(0, Chest.spawnedChests.Count);
        Chest.bossKeyPlaced = false;
        for (int i = 0; i < Chest.spawnedChests.Count; i++) {
            if (i == RandomChest) {
                Chest.spawnedChests[i].containsBossKey = true;
                Chest.bossKeyPlaced = true;
                Debug.Log("boss key has been placed in chest #" + i);
            }
        }
        if (Chest.bossKeyPlaced == false) bossDoor.UnlockBossDoor();
    }
    private void Update() {
        if (PlayerManager.player && RoomBounds.Contains(PlayerManager.player.transform.position)) {
            BossUI.bossUI.ShowUI();
        }
        else {
            BossUI.bossUI.HideUI();
        }
    }
}