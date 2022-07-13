using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    TextController _planetText;
    PanelController _panel;
    GameObject _clickGameObject;

    private void Start()
    {
        _planetText = GameObject.FindObjectOfType(typeof(TextController)) as TextController;
        _panel = GameObject.FindObjectOfType(typeof(PanelController)) as PanelController;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // It sends a ray from the camera towards the clicked point. Captures the GameObject at the point where the sent ray hits.

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    //If the ray hits a GameObject, it causes the panel to show up and change the planet name in the panel.

                    _clickGameObject = hit.transform.gameObject;
                    _panel.OpenPanel();
                    _planetText.SetPlanetName(_clickGameObject.name.ToString());
                }
            }
        }
    }
}
