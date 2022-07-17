using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    TextController _textChanger;
    MoveOnCurve _moveOnCurve;
    PanelController _panel;
    GameObject _clickedGameObject;
    string _tourCount;

    private void Start()
    {
        _textChanger = GameObject.FindObjectOfType(typeof(TextController)) as TextController;
        _panel = GameObject.FindObjectOfType(typeof(PanelController)) as PanelController;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // It sends a ray from the camera towards the clicked point. Captures the GameObject at the point where the sent ray hits.

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 500.0f))
            {
                if (hit.transform != null)
                {
                    //If the ray hits a GameObject, it causes the panel to show up and change the planet name in the panel.

                    _clickedGameObject = hit.transform.gameObject;

                    if(_clickedGameObject.name != "Sun")
                    {
                        _panel.OpenPanel();
                        _textChanger = GameObject.FindObjectOfType(typeof(TextController)) as TextController;
                        _tourCount = _clickedGameObject.GetComponent<MoveOnCurve>()._tour.ToString();
                        _textChanger.SetPlanetText(_clickedGameObject.name.ToString(), _tourCount);
                    }    
                }
            }
        }
    }
}
