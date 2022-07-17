using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI _planetName;
    public TextMeshProUGUI _tourCounter;


    public void SetPlanetText(string name , string tour)
    {
        //Changes the planet name on UI Panel.
        _planetName.text = "Planet's Name: " + name;
        _tourCounter.text = "Tour Count: " + tour;
    }
}
