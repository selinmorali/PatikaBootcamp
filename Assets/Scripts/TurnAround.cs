using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    [SerializeField] float _speedCoef; 

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, _speedCoef * Time.deltaTime); //It makes the object rotate around itself.
    }
}
