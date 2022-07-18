using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject _impact;
    public GameObject _smoke;
    Rigidbody _rigidBody;
    [SerializeField] float _speedCoef;
    float _targetAngle = 30f;
    float _targetY = -15f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidBody.useGravity = true;
    }

    private void Update()
    {
        //Meteor falls to random position.
        Vector3 lookDirection = (FallingTargetPosition() - transform.position).normalized;
        _rigidBody.AddForce(lookDirection * _speedCoef);


        //Destroys meteor when reaches _targetY.
        if (gameObject.transform.position.y <= _targetY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroys meteor when collision with any planet or Sun.
        Destroy(gameObject);
        Particle();
    }

    void Particle()
    {
        //Create particles and destroys them after two seconds.
        GameObject _impactEffect = (GameObject)Instantiate(_impact, transform.position, transform.rotation);
        GameObject _smokeEffect = (GameObject)Instantiate(_smoke, transform.position, transform.rotation);  
        Destroy(_impactEffect, 2f);
        Destroy(_smokeEffect, 2f);
    }

    public Vector3 FallingTargetPosition()
    {
        // Meteor falls at a random x position within ranges.
        float spawnPositionX = Random.Range(-_targetAngle, _targetAngle);

        //Meteor falls from the specified height.
        float spawnPositionY = _targetY;

        // Meteor falls at a random z position within ranges.
        float spawnPositionZ = Random.Range(-_targetAngle, _targetAngle);

        Vector3 _fallingPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
        return _fallingPosition;
    }
}
