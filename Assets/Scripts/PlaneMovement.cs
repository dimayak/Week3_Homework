using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlaneMovement : MonoBehaviour
{
    public float MovementSpeed = 1.0f;
    public float RotationSpeed = 1.0f;

    private Rigidbody _rb = default;
    float _movement = 0.0f;
    float _rotation = 0.0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        _rb.AddRelativeForce(_movement * Vector3.right * MovementSpeed, ForceMode.VelocityChange);
        _rb.AddRelativeTorque(0.0f, 0.0f, _rotation * RotationSpeed, ForceMode.VelocityChange);
    }

    private void HandleInput()
    {
        _movement = Input.GetAxis("Horizontal");
        _rotation = Input.GetAxis("Vertical");
    }
}
