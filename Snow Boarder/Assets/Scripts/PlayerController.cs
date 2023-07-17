using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 10f;
    [SerializeField] float boostSpeed = 50f;
    [SerializeField] float baseSpeed = 30f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType <SurfaceEffector2D>();
    }

    private void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    private void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow)) 
            surfaceEffector2D.speed = boostSpeed;
        else
            surfaceEffector2D.speed = baseSpeed;
    }

    private void RotatePlayer() 
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            rb2d.AddTorque(torqueAmount);

        else if (Input.GetKey(KeyCode.RightArrow))
            rb2d.AddTorque(-torqueAmount);
    }
}