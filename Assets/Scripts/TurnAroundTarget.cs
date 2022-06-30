using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAroundTarget : MonoBehaviour
{
    [SerializeField] Transform _targetObject;
    Vector3 _startingPosition;
    [SerializeField] float _speedCoef;
    float _distanceCovered;
    float _journeyLength = 0f;
    int _tour = 0;

    void Start()
    {
        _startingPosition = transform.position;
        _journeyLength = Vector3.Distance(_startingPosition, _targetObject.position);
    }

    void Update()
    {     
        _distanceCovered += _speedCoef * Time.deltaTime;  //Calculates the distance traveled by the planet.

        if ( _distanceCovered > 360)
        {
            _distanceCovered = 0f;
            _tour++;
            Debug.Log(gameObject.name + " has complated it's " + _tour + " tour.");
        }

        transform.RotateAround(_targetObject.position, Vector3.up, _speedCoef * Time.deltaTime); //Causes the object to rotate around the target object.
    }
}
