using UnityEngine;

public class EndRoom : Room {
    private void Update() {
        if(PlayerManager.player && RoomBounds.Contains(PlayerManager.player.transform.position)) {
            BossUI.bossUI.ShowUI();
        }
        else {
            BossUI.bossUI.HideUI();
        }
    }
}