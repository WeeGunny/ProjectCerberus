using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public TextMeshProUGUI BossName;
    public Image healthBar;
    public static BossUI bossUI;
    // Start is called before the first frame update

    private void Awake() {
        if (!bossUI) {
            bossUI = this;
            HideUI();
        }
    }

    public void SetupBoss(string bossName) {
        BossName.text = bossName;
    }

    public void UpdateBossHealth(float health, float startHealth) {
        healthBar.fillAmount = health / startHealth;
    }

   public void ShowUI() {
        gameObject.SetActive(true);
    }

    public void HideUI() {
        gameObject.SetActive(false);
    }
}
