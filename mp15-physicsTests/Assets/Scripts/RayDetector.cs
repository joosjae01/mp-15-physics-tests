using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayDetector : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Rigidbody _rigidBody;
    private Vector3 _prevPosition;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _prevPosition = transform.position;
    }

    private void Update()
    {
        MoveForward();
        RayPrev();
    }

    private void MoveForward()
    {
        _rigidBody.velocity = Vector3.forward * _moveSpeed;
    }

    private void RayPrev()
    {
        float range = Vector3.Distance(transform.position, _prevPosition);
        Vector3 direction = _prevPosition - transform.position;
        Ray ray = new Ray(transform.position, direction.normalized);

        Debug.DrawRay(transform.position, direction.normalized * range , Color.red);

        if(Physics.Raycast(ray, out RaycastHit hit, range))
        {
            Debug.Log(hit.transform.name + ": 터널링 발생");
        }

        _prevPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name + ": 정상적 충돌");
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("인스턴스 파괴");
    }
}
