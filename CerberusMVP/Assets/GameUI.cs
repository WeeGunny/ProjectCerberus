using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{

    static GameObject gameUI;

    private void Start()
    {
        if (!gameUI) gameUI = gameObject;
    }

    public static void ToggleUI(bool state)
    {
        if (gameUI) gameUI.SetActive(state);
    }

}
