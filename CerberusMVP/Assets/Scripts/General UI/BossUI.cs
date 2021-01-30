using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public TextMeshProUGUI BossName;
    public Image healthBar;
    // Start is called before the first frame update

    private void Awake() {
        BossController boss = FindObjectOfType<BossController>();
        if(boss == null) {
            gameObject.SetActive(false);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
