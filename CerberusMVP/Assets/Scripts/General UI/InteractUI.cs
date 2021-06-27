using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUI : MonoBehaviour
{

    public static InteractUI instance;

    private void Awake()
    {
        if (!instance) instance = this;
    }

    public void ToggleUI(bool state)
    {
        if (gameObject.activeInHierarchy != state) gameObject.SetActive(state);
    }
}
