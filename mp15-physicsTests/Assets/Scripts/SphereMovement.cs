using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 30f;
    Rigidbody _rigidBody;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _rigidBody.velocity = Vector3.forward * _moveSpeed;
    }

}
