using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    [SerializeField] private Transform _target;
    [SerializeField][Range(1, 10)] private float _mouseSensitivity;
    float _speedCoef = 30f;
    float cooldown = 3;

    private void Start()
    {
        //Set current instance to variable
        instance = this;
    }

    private void Update()
    {
        //If user uses mouse wheel
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Zoom();
        }

        if (Input.GetMouseButton(0))
        {
            if (!EventSystem.current.currentSelectedGameObject)
            {
                RotateWithHand();
                cooldown = 3;
            }
        }

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            AutoCamera();
        }
    }

    private void RotateWithHand()
    {
        //Get mouses input value on X Axis.
        float mouseX = Input.GetAxis("Mouse X");

        //Rotate camera around the Sun on X axis with input direction.
        transform.RotateAround(_target.position, Vector3.up, mouseX * _mouseSensitivity);

        //Always looks through Sun.
        transform.LookAt(_target.position);
    }

    private void AutoCamera()
    {
        //Rotates camera around the Sun with given speed multiplier
        transform.RotateAround(_target.position, Vector3.up, _speedCoef * Time.deltaTime);

        //Always looks through Sun.
        transform.LookAt(_target.transform);
    }

    private void Zoom()
    {
        //Set Mouse Wheel value to variable.
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        //Check if current FOV greater than 9 and lesser than 61
        if (GetComponent<Camera>().fieldOfView > 9 && GetComponent<Camera>().fieldOfView < 61)
        {
            //Zoom out if current FOV lesser than 60
            if (scrollInput < 0 && GetComponent<Camera>().fieldOfView < 60)
            {
                GetComponent<Camera>().fieldOfView++;
            }
            //Zoom in if current FOV greater than 10
            if (scrollInput > 0 && GetComponent<Camera>().fieldOfView > 10)
            {
                GetComponent<Camera>().fieldOfView--;
            }
        }
    }
}