using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSphere : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float _sphereSpeed;
    [SerializeField] private float _rotateSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.velocity = (Vector3.down * _sphereSpeed);
        rb.transform.Rotate(Vector3.up * _rotateSpeed);
    }
}
