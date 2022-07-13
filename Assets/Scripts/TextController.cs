using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI _textChanger;

    public void SetPlanetName(string name)
    {
        //Changes the planet name on UI Panel.
        _textChanger = FindObjectOfType<TextMeshProUGUI>();
        _textChanger.SetText("Planet's Name: " + name);
    }
}
