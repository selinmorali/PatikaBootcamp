using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject _panel;
    public static bool isActive = false;

    public void OpenPanel()
    {
        //Shows the UI panel.
        isActive = true;
        _panel.SetActive(isActive);
    }

    public void ClosePanel()
    {
        //Hides the UI panel.
        isActive = false;
        _panel.SetActive(isActive);
    }
}
