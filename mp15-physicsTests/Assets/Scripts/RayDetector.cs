using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayDetector : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Rigidbody _rigidBody;
    private Vector3 _prevPosition;
    private bool isMoving = true;

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
        if (!isMoving) return;

        _rigidBody.velocity = Vector3.forward * _moveSpeed;
    }

    private void RayPrev()
    {
        float range = Vector3.Distance(transform.position, _prevPosition);
        Vector3 rayDirection = transform.position - _prevPosition;
        Ray ray = new Ray(_prevPosition, rayDirection.normalized * range);

        Debug.DrawRay(_prevPosition, rayDirection.normalized * range , Color.red);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.transform.gameObject != gameObject)
            {
                Debug.Log(hit.transform.name + ": 터널링 발생");
                isMoving = false;
                _rigidBody.velocity = Vector3.zero;
            }
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
